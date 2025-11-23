using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartySalesTUCG.ClassLib;


namespace PartySalesTUCG
{
    public partial class FrmPartySales : Form
    {
        private int childFormNumber = 0;

        public FrmPartySales()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            FrmCadFesta frm = new FrmCadFesta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmPartySales_Load(object sender, EventArgs e)
        {

        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["frmVendas"];

            if (f != null)
            {
                f.BringToFront();
            }
            else
            {
                FrmVendas frmVendas = new FrmVendas();
                // frmVendas.Parent = this;    
                frmVendas.MdiParent = this;
                frmVendas.MaximizeBox = true;
                frmVendas.Show();
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.MdiParent = this;
            frmInicio.Show();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmCadPessoa frm = new FrmCadPessoa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void extratoContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmItensVenda frm = new FrmItensVenda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {
            FrmConta frm = new FrmConta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmCaixa frm = new FrmCaixa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void geralDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se uma festa está selecionada
            if (Globals.Current.IdFesta == 0)
            {
                MessageBox.Show("Por favor, selecione uma festa primeiro (Menu Cadastro > Iniciar Vendas).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instancia as classes (você pode querer fazer isso no topo do seu Form)
            TUCGDataAcess daTucg = new TUCGDataAcess();
            Relatorio relatorios = new Relatorio();

            // 1. Busca os dados
            DataTable dtVendas = daTucg.GetRelatorioVendasGeral(Globals.Current.IdFesta);

            if (dtVendas.Rows.Count == 0)
            {
                MessageBox.Show("Não há vendas registradas para esta festa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Pergunta onde salvar
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Arquivo PDF (*.pdf)|*.pdf|Arquivo Excel (*.xlsx)|*.xlsx";
            saveFile.FileName = $"VendasGerais_{Globals.Current.Festa.Replace(" ", "_")}.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string titulo = "Relatório Geral de Vendas";
                    string subtitulo = $"Festa: {Globals.Current.Festa} | Gerado em: {DateTime.Now.ToString("g")}";

                    // 3. Verifica se o usuário quer PDF ou Excel e chama o método correto
                    if (saveFile.FilterIndex == 1) // PDF
                    {
                        relatorios.ExportarVendasGeralPDF(dtVendas, saveFile.FileName, titulo, subtitulo);
                    }
                    else // Excel
                    {
                        relatorios.ExportarVendasGeralExcel(dtVendas, saveFile.FileName, titulo);
                    }

                    MessageBox.Show($"Relatório salvo com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void extratoContaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {// Verifica se uma festa está selecionada
            if (Globals.Current.IdFesta == 0)
            {
                MessageBox.Show("Por favor, selecione uma festa primeiro (Menu Cadastro > Iniciar Vendas).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instancia as classes
            TUCGDataAcess daTucg = new TUCGDataAcess();
            Relatorio relatorios = new Relatorio();

            // 1. Busca os dados
            DataTable dtExtrato = daTucg.GetExtratoContaGeral(Globals.Current.IdFesta);


            if (dtExtrato.Rows.Count == 0)
            {
                MessageBox.Show("Não há lançamentos em conta para esta festa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Pergunta onde salvar
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Arquivo PDF (*.pdf)|*.pdf|Arquivo Excel (*.xlsx)|*.xlsx";
            saveFile.FileName = $"ExtratoGeralContas_{Globals.Current.Festa.Replace(" ", "_")}.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string titulo = "Relatório Geral de Contas por Pessoa";
                    string subtitulo = $"Festa: {Globals.Current.Festa} | Gerado em: {DateTime.Now.ToString("g")}";

                    // 3. Chama o método correto (PDF ou Excel)
                    if (saveFile.FilterIndex == 1) // PDF
                    {
                        relatorios.ExportarExtratoGeralPDF(dtExtrato, saveFile.FileName, titulo, subtitulo);
                    }
                    else // Excel
                    {
                        relatorios.ExportarExtratoGeralExcel(dtExtrato, saveFile.FileName, titulo);
                    }

                    MessageBox.Show($"Relatório salvo com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void extratoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se uma festa está selecionada
            if (Globals.Current.IdFesta == 0)
            {
                MessageBox.Show("Por favor, selecione uma festa primeiro (Menu Cadastro > Iniciar Vendas).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instancia as classes
            TUCGDataAcess daTucg = new TUCGDataAcess();
            Relatorio relatorios = new Relatorio();

            // 1. Busca os dados
            DataTable dtCaixa = daTucg.GetRelatorioCaixa(Globals.Current.IdFesta);

            if (dtCaixa.Rows.Count == 0)
            {
                MessageBox.Show("Não há movimentos de caixa para esta festa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Pergunta onde salvar
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Arquivo PDF (*.pdf)|*.pdf";
            saveFile.FileName = $"RelatorioCaixa_{Globals.Current.Festa.Replace(" ", "_")}.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string titulo = "Relatório de Caixa";
                    string subtitulo = $"Festa: {Globals.Current.Festa} | Gerado em: {DateTime.Now.ToString("g")}";

                    relatorios.ExportarCaixaPDF(dtCaixa, saveFile.FileName, titulo, subtitulo);
                  

                    MessageBox.Show($"Relatório salvo com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
