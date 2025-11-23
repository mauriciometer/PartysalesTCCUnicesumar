using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartySalesTUCG.ClassLib;

namespace PartySalesTUCG
{
    public partial class FrmInicio : Form
    {
        private OleDbDataAdapter dtBdFesta = new OleDbDataAdapter();


        public FrmInicio()
        {
            InitializeComponent();
            dgvFesta.DataSource = bindingSource1;
            //  GetData("select * from FESTA where DataFesta >= Now()");
            GetData("select * from FESTA");
            grpSenha.Visible = false;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            dgvFesta.DataSource = bindingSource1;
            //  GetData("select * from FESTA where DataFesta >= Now()");
            GetData("select * from FESTA");
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string.
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString = Globals.Current.ConnectionString;

                // Create a new data adapter based on the specified query.
                //  dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
                dtBdFesta = new OleDbDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand.
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dtBdFesta);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dtBdFesta.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dgvFesta.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dgvFesta.DataSource = bindingSource1;
            GetData("select ID,Nome from FESTA where DataFesta >= Now()");
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbSelecao.Text = dgvFesta.CurrentCell.Value.ToString();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaSenha)
            {

                if (!txtNome.Text.Equals(String.Empty))
                {
                    Globals.Current.SetUserName(txtNome.Text);
                    Globals.Current.SetFesta(dgvFesta.CurrentCell.Value.ToString());
                    Globals.Current.SetIdFesta(int.Parse(dgvFesta.CurrentRow.Cells[0].Value.ToString()));
                    this.Close();
                }
                else { MessageBox.Show("É necessário selecionar a festa e informar seu nome!"); }
            }
            else
            {
                grpSenha.Visible = true;
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidaSenha
        {
            get
            {
                {
                    return (txtSenha.Text.Equals("tucg@2025"));
                }
            }
        }
        private void txtSenha_Validated(object sender, EventArgs e)
        {
            if (txtSenha.Text.Length <= 0 || !ValidaSenha)
            {
                erroSenha.SetError(this.txtSenha, "senha errada!");
            }
            else
            {
                erroSenha.SetError(this.txtSenha, string.Empty);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidaSenha)
            {
                grpSenha.Visible = false;
                btnSalvar.Text = "Iniciar!";
            }
        }
    }
}
