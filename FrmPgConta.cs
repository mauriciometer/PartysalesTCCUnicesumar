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
using PartySalesTUCG.dsTUCGTableAdapters;

namespace PartySalesTUCG
{
    public partial class FrmPgConta : Form
    {
        private double _valor;
        private bool _pago = false;
        private int _idPessoa;
        private string _nome;
        private PESSOASTableAdapter tbPessoas = new PESSOASTableAdapter();
        TUCGDataAcess daTucg = new();
        public FrmPgConta(double Valor)
        {
            _valor = Valor;
            InitializeComponent();
            txtValor.Text = Valor.ToString("C");
            CarregaCmb();
        }

        private void CarregaCmb()
        {
            cmbPessoa.DataSource = tbPessoas.GetData();
            cmbPessoa.DisplayMember = "Nome";
        }

        public bool PorNaConta()
        {
            this.ShowDialog();
            return this._pago;
        }

        public int IdPessoa { get { return this._idPessoa; } }
        public string NomePessoa { get { return this._nome; } }

        private void cmbPessoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            this._pago = true;
            this.Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this._pago = false;
            this.Close();
        }

        private void cmbPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPessoa.SelectedIndex != -1)
            {
                this._idPessoa = (int)cmbPessoa.SelectedValue;
                this._nome = cmbPessoa.Text;
                txtSaldo.Text = daTucg.SaldoConta(Globals.Current.IdFesta, this._idPessoa).ToString("C");
            }
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            FrmCadPessoa frm = new FrmCadPessoa();
            frm.ShowDialog();
            CarregaCmb();
        }
    }
}
