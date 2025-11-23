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
    public partial class FrmCadPessoa : Form
    {
        TUCGDataAcess daTucg = new TUCGDataAcess();

        public FrmCadPessoa()
        {
            InitializeComponent();
            CarregaDgv();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            bool _valido = true;
            int _id = 0;

            if (txtNome.Text == string.Empty)
            {
                MessageBox.Show("Nome é obrigatório!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _valido = false;
                return;
            }
            if (txtTelefone.Text == string.Empty)
            {
                MessageBox.Show("Telefone é obrigatório!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _valido = false;
                return;
            }
            if (txtContato.Text == string.Empty)
            {
                MessageBox.Show("Contato no Terreiro é obrigatório!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _valido = false;
                return;
            }
            if (_valido)
            {
                _id = (int)daTucg.RegistraPessoa(new string[] { txtNome.Text, txtTelefone.Text.Replace("(","").Replace(")",""), txtContato.Text });
                if (_id > 0)
                { CarregaDgv(); }
            }
           
        }

        private void CarregaDgv()
        {
            dgvPessoas.Rows.Clear();    

            foreach (string[] pessoa in daTucg.Pessoas)
            {
                dgvPessoas.Rows.Add(pessoa);
            }
        }
    }
}
