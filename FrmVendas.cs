using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PartySalesTUCG.ClassLib;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;

namespace PartySalesTUCG
{
    public partial class FrmVendas : Form
    {

        private double VlrTotal = 0;
        private double VlrRecebido = 0;
        private double VlrFalta = 0;
        private Venda venda;
        private IList<Pagamento> pagamento = new List<Pagamento>();
        private IList<string[]> ItemsVenda = new List<string[]>();
        private TUCGDataAcess daTucg = new();
        private string IdentVendaPix = "";

        public FrmVendas()
        {
            while ((Globals.Current.IdFesta == null) || (Globals.Current.IdFesta == 0))
            {
                FrmInicio frm = new FrmInicio();
                frm.ShowDialog();
            }

            InitializeComponent();
            btnDinheiro.Enabled = Globals.Current.CaixaAberto;

            this.Text = "Vendas " + Globals.Current.Festa;
            ItemsVenda = daTucg.ItensVenda;
            addItensLista();
        }
        private void calculaTotal()
        {
            this.VlrTotal = 0;
            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                this.VlrTotal += int.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[5].Value.ToString());
            }
            txtTotal.Text = this.VlrTotal.ToString("C");
            atualizaVlrRecebido();
        }
        private void atualizaVlrRecebido()
        {
            VlrRecebido = 0;

            lsbRecebidos.Items.Clear();

            foreach (Pagamento pagto in pagamento)
            {
                VlrRecebido += pagto.Valor;
                lsbRecebidos.Items.Add(pagto.DescPagto);
            }

            txtRecebido.Text = VlrRecebido.ToString("C");

            VlrFalta = VlrTotal - VlrRecebido;

            txtFalta.Text = (VlrTotal - VlrRecebido).ToString("C");


            if (VlrFalta <= 0)
            {
                btnFinaliza.Enabled = true;
            }
            else
            {
                btnFinaliza.Enabled = false;
            }
        }
        private void zeraTudo()
        {
            this.VlrTotal = 0;
            this.VlrFalta = 0;
            this.VlrRecebido = 0;
            this.IdentVendaPix = string.Empty;
            this.lsbRecebidos.Items.Clear();
            this.lsbRecebidos.Refresh();
            this.pagamento.Clear();

            dgvPedido.Rows.Clear();
            atualizaVlrRecebido();
            btnFinaliza.Enabled = false;

        }

        #region Botoes
        private void btnCancela_Click(object sender, EventArgs e)
        {
            zeraTudo();
        }
        private void btnPix_Click(object sender, EventArgs e)
        {

            FrmPix frm = new FrmPix(QRPix(), VlrFalta);

            //frm.ShowDialog();
            if (frm.recebePix())
            {
                //this.txtRecebido.Text = this.VlrTotal.ToString("C");
                //this.VlrRecebido += frm.Valor;
                this.pagamento.Add(new Pagamento("PIX", VlrFalta, IdentVendaPix));

                atualizaVlrRecebido();
            }
            else { IdentVendaPix = ""; }

        }
        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            FrmDinheiro frm = new FrmDinheiro(VlrFalta);
            if (frm.recebeDinheiro())
            {
                this.pagamento.Add(new Pagamento("DINHEIRO", frm.Valor));
                atualizaVlrRecebido();
            }
        }
        private void btnConta_Click(object sender, EventArgs e)
        {
            //Formulario para selecionar a pessoa primeiro
            FrmPgConta frm = new FrmPgConta(VlrFalta);
            if (frm.PorNaConta())
            {
                //this.pagamento.Add(new Pagamento("Conta: "+frm.NomePessoa, VlrFalta));
                this.pagamento.Add(new Pagamento(VlrFalta, new Conta(frm.IdPessoa, frm.NomePessoa, VlrFalta)));
                atualizaVlrRecebido();
            }
            //selecionado pessoa, chamada da gravação da venda
            //gravada a venda, grava a conta
            //gravada a 

        }
       
        #endregion Botoes

        #region ItensFlowPanel

        private void addItensLista()
        {
            int count = 0;
            foreach (string[] item in ItemsVenda)
            {
                Button btnItem = new Button();
                //this.btnExemplo.Location = new System.Drawing.Point(228, 42);
                btnItem.Name = "btnItem";
                btnItem.Size = new System.Drawing.Size(95, 85);
                btnItem.TabIndex = 1;
                btnItem.Tag = count;
                btnItem.Text = item[2] + "\r\n" + Double.Parse(item[3]).ToString("C") + "\r\n";
                //btnItem.Text = descricao;
                btnItem.UseVisualStyleBackColor = true;
                btnItem.Click += new System.EventHandler(this.btnItem_Click);
                flpItensVenda.Controls.Add(btnItem);
                count++;
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            Button btnEnviado = sender as Button;

            insertItemVenda(int.Parse(btnEnviado.Tag.ToString()));
        }

        private void insertItemVenda(int item)
        {
            bool finded = false;
            int rowCount = 0;
            double valor = 0;
            double qtde = 0;

            foreach (DataGridViewRow row in dgvPedido.Rows)
            {

                if (row.Cells[0].Value.Equals(item.ToString()))
                {
                    finded = true;
                    qtde = int.Parse(row.Cells[2].Value.ToString());
                    qtde++;
                    valor = qtde * double.Parse(row.Cells[5].Value.ToString());
                    dgvPedido.Rows[rowCount].Cells[2].Value = qtde.ToString();
                    dgvPedido.Rows[rowCount].Cells[4].Value = valor.ToString("C");
                    break;
                }
                rowCount++;
            }

            if (!finded)
            {
                dgvPedido.Rows.Add(buscaItem(item));
            }

            this.calculaTotal();
        }

        private string[] buscaItem(int posicao)
        {
            string[] item = new string[7];
            item[0] = posicao.ToString();
            item[1] = ((string[])ItemsVenda.ElementAt(posicao))[2];
            item[2] = "1";
            item[3] = double.Parse(((string[])ItemsVenda.ElementAt(posicao))[3]).ToString("C");
            item[4] = double.Parse(((string[])ItemsVenda.ElementAt(posicao))[3]).ToString("C");
            item[5] = ((string[])ItemsVenda.ElementAt(posicao))[3];
            item[6] = ((string[])ItemsVenda.ElementAt(posicao))[0];
            return item;

        }

        private void dgvPedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.calculaTotal();

        }

        private void dgvPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvPedido.Rows[e.RowIndex];

            var qtde = int.Parse(row.Cells[2].Value.ToString());
            var valor = qtde * double.Parse(row.Cells[5].Value.ToString());

            dgvPedido.Rows[e.RowIndex].Cells[2].Value = qtde.ToString();
            dgvPedido.Rows[e.RowIndex].Cells[4].Value = valor.ToString("C");

            this.calculaTotal();

        }

        #endregion

        #region Pagamento

        private void btnFinaliza_Click(object sender, EventArgs e)
        {

            venda = new Venda(Globals.Current.IdFesta, Globals.Current.UserName);
            venda.IdentVenda = IdentVendaPix;

            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                ItensVenda itVendido = new ItensVenda(
                    int.Parse(row.Cells[6].Value.ToString()), //idItem 
                    int.Parse(row.Cells[2].Value.ToString()), //qtde
                    double.Parse(row.Cells[5].Value.ToString())
                    );
                venda.Itens.Add(itVendido);
            }

            venda.Pagamentos = pagamento;

            //MessageBox.Show(venda.ValorTotalPago);

            if (VlrFalta < 0)
            {
                MessageBox.Show("Troco de " + (VlrFalta * -1).ToString("C"), "Troco", MessageBoxButtons.OK);
            }

            if (venda.RegistraVenda())
            {
                MessageBox.Show("Feito!","Registro Venda",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

            zeraTudo();

        }
        private string QRPix()
        {
            string ValorOriginal = ((Decimal)(VlrTotal - VlrRecebido)).ToString("0.00").Replace(',', '.');

            var dthora = DateTime.Now.ToString("yyMMddHHmm");
            var cobranca = new Cobranca(Globals.Current.ChavePix);
            cobranca.SolicitacaoPagador = "Compra na " + Globals.Current.Festa + " - " + dthora;
            cobranca.Valor = new Valor();
            cobranca.Valor.Original = ValorOriginal;
            this.IdentVendaPix = "PedidoFesta" + dthora;
            var payload = cobranca.ToPayload(IdentVendaPix, new Merchant("TUCG", "Curitiba"));
            return (payload.GenerateStringToQrCode());
        }

        #endregion Pagamento


        
    }
}
