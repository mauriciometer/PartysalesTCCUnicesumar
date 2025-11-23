using PartySalesTUCG.ClassLib;

namespace PartySalesTUCG
{
    public partial class FrmCaixa : Form
    {
        TUCGDataAcess daTucg = new();
        double _vlrAbertura;

        double _saidas = 0;
        double _entradas = 0;
        string _tipomovreg = string.Empty;
        double _vlrMovReg = 0;
        public FrmCaixa()
        {
            while ((Globals.Current.IdFesta == null) || (Globals.Current.IdFesta == 0))
            {
                FrmInicio frm = new FrmInicio();
                frm.ShowDialog();
            }


            InitializeComponent();

            if (!(Globals.Current.CaixaAberto == null))
            {
                VerificaCaixa();
            }

            lbFechado.Visible = (!(Globals.Current.CaixaAberto));
            btnAbrir.Visible = (!(Globals.Current.CaixaAberto));
            grpFecha.Visible = ((Globals.Current.CaixaAberto));
            grpRegMov.Visible = ((Globals.Current.CaixaAberto));

            CarregaDgv();
        }

        private void VerificaCaixa()
        {
            double vlAbertura = daTucg.VerificaCaixa(Globals.Current.IdFesta);

            if (vlAbertura > 0)
            {
                Globals.Current.CaixaAberto = true;
                lbVlrAbertura.Text = vlAbertura.ToString("C");
                lbVlrAbertura.Visible = true;
            }
            else
            {
                Globals.Current.CaixaAberto = false;
            }

        }

        private void btnAbreCaixa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma abertura com " + _vlrAbertura.ToString("C"), "Confirmar abertura do caixa!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                daTucg.RegistraMovCaixa(Globals.Current.IdFesta, "Abertura do caixa", _vlrAbertura, "A", Globals.Current.UserName);
                VerificaCaixa();
            }

            grpAbrir.Visible = false;
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            Double.TryParse(txtVlrAbertura.Text.Replace("R$", ""), out _vlrAbertura);
            txtVlrAbertura.Text = _vlrAbertura.ToString("C");

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            _vlrAbertura = 0;
            grpAbrir.Visible = true;
            txtVlrAbertura.Text = string.Empty;

        }

        private void CarregaDgv()
        {
            dgvCaixa.Rows.Clear();
            this._entradas = 0;
            this._saidas = 0;

            foreach (string[] item in daTucg.MovimentoCaixa(Globals.Current.IdFesta))
            {
                dgvCaixa.Rows.Add(item);
                _entradas += (!(item[1] == string.Empty) ? double.Parse(item[1].Replace("R$", "")) : 0);
                _saidas += (!(item[2] == string.Empty) ? double.Parse(item[2].Replace("R$", "")) : 0);
            }

            lbSaldoTeorico.Text = (_entradas - _saidas).ToString("C");
            //           txtCredito.Text = this.creditos.ToString("C");
            //         txtDebito.Text = this.gastos.ToString("C");
            //       txtSaldo.Text = this.Saldo.ToString("C");
        }

        private void btnRegMovimento(object sender, EventArgs e)
        {
            /*
             * E - entrada
             * R - retirada
             */
            this._tipomovreg = ((Button)sender).Tag.ToString();
            if (this._tipomovreg.Equals("E"))
            {
                btnRegSaida.Enabled = false;
            }
            else
            {
                btnRegEntrada.Enabled = false;
            }

            grpRegistro.Visible = true;

        }

        private void btnCancelaReg_Click(object sender, EventArgs e)
        {

            LimpaRegMov();

        }

        private void LimpaRegMov()
        {
            this._tipomovreg = string.Empty;
            txtDescMov.Text = string.Empty;
            txtVlrMov.Text = string.Empty;
            this._vlrMovReg = 0;
            grpRegistro.Visible = false;
            btnRegEntrada.Enabled = true;
            btnRegSaida.Enabled = true;
            erroTxtVlr.SetError(this.txtVlrMov, string.Empty);
            erroTxtMov.SetError(this.txtDescMov, string.Empty);
        }

        private void btnGravaMov_Click(object sender, EventArgs e)
        {
            txtDescMov_Validated(sender, e);
            txtVlrMov_Validated(sender, e);

            if (this.ValidaMov)
            {
                if (MessageBox.Show("Confirma movimento com " + this._vlrMovReg.ToString("C"), "Registra Movimento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    daTucg.RegistraMovCaixa(Globals.Current.IdFesta, txtDescMov.Text, this._vlrMovReg, this._tipomovreg, Globals.Current.UserName);
                    CarregaDgv();
                    LimpaRegMov();
                }

            }
        }

        private void txtDescMov_Validated(object sender, EventArgs e)
        {
            if (txtDescMov.Text.Length <= 0)
            {
                erroTxtMov.SetError(this.txtDescMov, "Descrição é Obrigatória");
            }
            else
            {
                erroTxtMov.SetError(this.txtDescMov, string.Empty);
            }
        }

        private void txtVlrMov_Validated(object sender, EventArgs e)
        {
            Double.TryParse(txtVlrMov.Text.Replace("R$", ""), out _vlrMovReg);
            txtVlrMov.Text = _vlrMovReg.ToString("C");

            if (this._vlrMovReg <= 0)
            {
                erroTxtVlr.SetError(this.txtVlrMov, "Valor é Obrigatório");
            }
            else
            {
                erroTxtVlr.SetError(this.txtVlrMov, string.Empty);
            }

        }

        private void btnFechaCaixa_Click(object sender, EventArgs e)
        {
            if (SaldoTeorico < 0)
            {
                MessageBox.Show("Não é possível realizar fechamento com saldo negativo", "Erro de caixa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show("Confirma saldo em caixa de " + SaldoTeorico.ToString("C"), "Fechamento do Caixa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    daTucg.RegistraMovCaixa(Globals.Current.IdFesta, "Fechamento do caixa!", SaldoTeorico, "F", Globals.Current.UserName);
                    CarregaDgv();
                    LimpaRegMov();
                }
            }
        }

        private bool ValidaMov
        {
            get
            {

                return ((txtDescMov.Text.Length > 0 && this._vlrMovReg > 0) ? true : false);

            }
        }

        private double SaldoTeorico
        {
            get
            {
                return (_entradas - _saidas);
            }
        }
    }
}
