using PartySalesTUCG.ClassLib;
using PartySalesTUCG.dsTUCGTableAdapters;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartySalesTUCG
{
    public partial class FrmConta : Form
    {

        private double _valor;
        private bool _pago = false;
        private int _idPessoa;
        private string _nome;
        private PESSOASTableAdapter tbPessoas = new PESSOASTableAdapter();
        private TUCGDataAcess daTucg = new();
        private double creditos = 0;
        private double gastos = 0;
        private double vlrCreditar = 0;
        private string IdentCredPix = "";
        private Relatorio relats = new Relatorio();

        public FrmConta()
        {
            while ((Globals.Current.IdFesta == null) || (Globals.Current.IdFesta == 0))
            {
                FrmInicio frm = new FrmInicio();
                frm.ShowDialog();
            }

            InitializeComponent();
            btnDinheiro.Enabled = Globals.Current.CaixaAberto;

            CarregaCmb();
        }

        public double Saldo
        {
            get
            {
                return (creditos - gastos);
            }

        }

        private void CarregaCmb()
        {
            cmbPessoa.DataSource = tbPessoas.GetData();
            cmbPessoa.DisplayMember = "Nome";
        }

        private void cmbPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPessoa.SelectedIndex != -1)
            {
                this._idPessoa = (int)cmbPessoa.SelectedValue;
                this._nome = cmbPessoa.Text;
                this.btnExportExcel.Enabled = true;
                this.btnExportPDF.Enabled = true;
                CarregaDgv();
            }
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            FrmCadPessoa frm = new FrmCadPessoa();
            frm.ShowDialog();
            CarregaCmb();
        }

        private void CarregaDgv()
        {
            dgvExtrato.Rows.Clear();
            this.creditos = 0;
            this.gastos = 0;

            foreach (string[] item in daTucg.ExtratoConta(Globals.Current.IdFesta, this._idPessoa))
            {
                dgvExtrato.Rows.Add(item);
                creditos += (!(item[4] == string.Empty) ? double.Parse(item[4]) : 0);
                gastos += (!(item[5] == string.Empty) ? double.Parse(item[5]) : 0);
            }

            txtCredito.Text = this.creditos.ToString("C");
            txtDebito.Text = this.gastos.ToString("C");
            txtSaldo.Text = this.Saldo.ToString("C");
        }

        private void txtCreditar_Validated(object sender, EventArgs e)
        {
            Double.TryParse(txtCreditar.Text.Replace("R$", ""), out vlrCreditar);
            txtCreditar.Text = vlrCreditar.ToString("C");
        }

        private void btnPix_Click(object sender, EventArgs e)
        {
            if (vlrCreditar > 0)
            {
                FrmPix frm = new FrmPix(QRPix(), vlrCreditar);

                //frm.ShowDialog();
                if (frm.recebePix())
                {
                    //this.txtRecebido.Text = this.VlrTotal.ToString("C");
                    //this.VlrRecebido += frm.Valor;
                    daTucg.RegistraCredito(this._idPessoa, "Credito na Conta pago a " + Globals.Current.UserName + " via Pix:" + IdentCredPix, vlrCreditar, "P");
                    CarregaDgv();
                    txtCreditar.Text = string.Empty;
                    vlrCreditar = 0;
                }
                else { IdentCredPix = ""; }
            }
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            if (vlrCreditar > 0)
            {
                if (MessageBox.Show("Confirma recebimento de " + vlrCreditar.ToString("C"), "Confirmar recebimento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    daTucg.RegistraCredito(this._idPessoa, "Credito na Conta pago a " + Globals.Current.UserName + " em dinheiro", vlrCreditar, "D");
                    CarregaDgv();
                    txtCreditar.Text = string.Empty;
                    vlrCreditar = 0;
                }
            }

        }

        private string QRPix()
        {
            string ValorOriginal = ((Decimal)(vlrCreditar)).ToString("0.00").Replace(',', '.');

            var dthora = DateTime.Now.ToString("yyMMddHHmm");
            var cobranca = new Cobranca(Globals.Current.ChavePix);
            cobranca.SolicitacaoPagador = "Credito para conta na " + Globals.Current.Festa + " - " + dthora;
            cobranca.Valor = new Valor();
            cobranca.Valor.Original = ValorOriginal;
            this.IdentCredPix = "CrdCnt_" + cmbPessoa.Text + dthora;
            var payload = cobranca.ToPayload(IdentCredPix, new Merchant("TUCG", "Curitiba"));
            return (payload.GenerateStringToQrCode());
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (cmbPessoa.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma pessoa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Busca os dados
            DataTable dtExtrato = daTucg.GetExtratoConta(Globals.Current.IdFesta, this._idPessoa);

            if (dtExtrato.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Pergunta onde salvar
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Arquivo Excel (*.xlsx)|*.xlsx";
            saveFile.FileName = $"Extrato_{this._nome.Replace(" ", "_")}.xlsx";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // **CHAMADA ÚNICA PARA A CLASSE DE RELATÓRIOS**
                    string titulo = $"Extrato de Conta: {this._nome} (Festa: {Globals.Current.Festa})";
                    relats.ExportarDataTableParaExcel(dtExtrato, saveFile.FileName, titulo);

                    MessageBox.Show($"Relatório salvo com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o Excel: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (cmbPessoa.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma pessoa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Busca os dados
            DataTable dtExtrato = daTucg.GetExtratoConta(Globals.Current.IdFesta, this._idPessoa);

            if (dtExtrato.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Pergunta onde salvar
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Arquivo PDF (*.pdf)|*.pdf";
            saveFile.FileName = $"Extrato_{this._nome.Replace(" ", "_")}.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // **CHAMADA ÚNICA PARA A CLASSE DE RELATÓRIOS**
                    string titulo = $"Extrato de Conta: {this._nome}";
                    string subtitulo = $"Festa: {Globals.Current.Festa} | Gerado em: {DateTime.Now.ToString("g")}";
                    relats.ExportarDataTableParaPDF(dtExtrato, saveFile.FileName, titulo, subtitulo);

                    MessageBox.Show($"Relatório salvo com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
