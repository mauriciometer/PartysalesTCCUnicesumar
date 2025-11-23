using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PartySalesTUCG
{
    public partial class FrmDinheiro : Form
    {

        private double _valor;
        private bool _pago = false;

        public FrmDinheiro(double Valor)
        {
            this._valor = Valor;

            InitializeComponent();
            txtValor.Text = Valor.ToString("C");

        }

        public bool recebeDinheiro()
        {
            this.ShowDialog();
            return this._pago;
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            Double.TryParse(txtValor.Text.Replace("R$", ""), out _valor);

            this._pago = (this._valor > 0); 
            this.Close();
            
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this._valor = 0;

            this._pago = (this._valor > 0);
            this.Close();
        }

        public double Valor { get { return _valor; } }
    }
}
