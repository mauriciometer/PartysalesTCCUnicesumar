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
    public partial class FrmCadFesta : Form
    {
        // Instancia a classe de acesso a dados
        TUCGDataAcess daTucg = new TUCGDataAcess();

        public FrmCadFesta()
        {
            InitializeComponent();
            CarregaDgv(); // Carrega as festas quando o form abre
        }

        private void CarregaDgv()
        {
            // Busca os dados e define a fonte do DataGridView
            dgvFestas.DataSource = daTucg.GetFestas();
            // Formata as colunas (opcional, mas recomendado)
            dgvFestas.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFestas.Columns["DataFesta"].HeaderText = "Data da Festa";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeFesta.Text))
            {
                MessageBox.Show("O nome da festa é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pega os valores da UI
            string nome = txtNomeFesta.Text;
            DateTime data = dtpDataFesta.Value;

            // Chama o método da camada de dados
            int id = daTucg.RegistraFesta(nome, data);

            if (id > 0)
            {
                MessageBox.Show("Festa registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeFesta.Clear();
                CarregaDgv(); // Atualiza a lista de festas
            }
        }
    }
}
