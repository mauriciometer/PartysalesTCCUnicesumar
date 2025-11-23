using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Util;
using PartySalesTUCG.ClassLib;
using PartySalesTUCG.dsTUCGTableAdapters;

namespace PartySalesTUCG
{
    public partial class FrmItensVenda : Form
    {

        TUCGDataAcess daTucg = new();
        FESTATableAdapter tbFesta = new FESTATableAdapter();
        ITENSTableAdapter tbItems = new ITENSTableAdapter();

        private int _idFesta;
        private string _nomeFesta;
        private double _valor;
        private int _idItem;
        private bool _ativo;

        public FrmItensVenda()
        {
            InitializeComponent();
            CarregaCmb();
            // CarregaDgv();
        }

        private void CarregaCmb()
        {
            cmbFesta.DataSource = tbFesta.GetDataByNomeFesta();
            cmbFesta.DisplayMember = "Nome";
        }
        private void CarregaDgv()
        {
            dgvItens.Rows.Clear();

            foreach (string[] item in daTucg.ItensVendaCad(_idFesta))
            {
                dgvItens.Rows.Add(item);
            }
            dgvItens.ClearSelection();
        }

        private void cmbFesta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbFesta.SelectedIndex != -1)
            {
                this._idFesta = (int)cmbFesta.SelectedValue;
                this._nomeFesta = cmbFesta.Text;
                limpa();
                CarregaDgv();

            }
        }

        private void dgvItens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dgvItens.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void dgvItens_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            Double.TryParse(dgvItens.Rows[e.RowIndex].Cells[3].Value.ToString(), out _valor);
            int.TryParse(dgvItens.Rows[e.RowIndex].Cells[0].Value.ToString(), out _idItem);

            groupBox1.Text = "Alterar item : ID=" + _idItem.ToString();

            txtDescricao.Text = dgvItens.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtValor.Text = _valor.ToString("C");
            cmbTipo.Text = dgvItens.Rows[e.RowIndex].Cells[4].Value.ToString();
            ckbAtivo.Checked =  Convert.ToBoolean(dgvItens.Rows[e.RowIndex].Cells[5].Value);

            this.btnNovo.Visible = true;
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            Double.TryParse(txtValor.Text.Replace("R$", ""), out _valor);
            txtValor.Text = _valor.ToString("C");

        }

        private void limpa()
        {
            this._idItem = new();
            this.txtDescricao.Text = string.Empty;
            this.txtValor.Text = string.Empty;
            this.cmbTipo.SelectedIndex = -1;
            this.btnNovo.Visible = false;
            this.ckbAtivo.Checked = true;
            groupBox1.Text = "Cadastrar Item";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (IsAllValid())
            {
                if (_idItem == 0)
                {
                    daTucg.RegistraItem(this._idFesta, txtDescricao.Text, this._valor, cmbTipo.Text, ckbAtivo.Checked);
                }
                else
                {
                    daTucg.AtualizaItem(this._idItem, txtDescricao.Text, this._valor, cmbTipo.Text, ckbAtivo.Checked);
                }


                CarregaDgv();

                limpa();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dgvItens.ClearSelection();
            limpa();
            groupBox1.Text = "Cadastrar Item";
        }

        private void txtDescricao_Validated(object sender, EventArgs e)
        {
            if (!IsDescricaoValid())
            {
                erroDescricao.SetError(this.txtDescricao, "Descricao é Obrigatoria");
            }
            else
            {
                erroDescricao.SetError(this.txtDescricao, string.Empty);
            }
        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            if (!IsValorValid())
            {
                erroValor.SetError(this.txtValor, "Valor não pode ser R$0,00");

            }
            else
            {
                erroValor.SetError(this.txtValor, string.Empty);
            }
        }

        private void cmbTipo_Validated(object sender, EventArgs e)
        {
            if (IsTipoValid())
            {
                erroTipo.SetError(this.cmbTipo, string.Empty);
            }
            else
            {
                erroTipo.SetError(this.cmbTipo, "É preciso definir o tipo");
            }
        }

        private bool IsDescricaoValid()
        {
            return (txtDescricao.Text.Length > 0);
        }

        private bool IsValorValid()
        {
            return (this._valor > 0);
        }

        private bool IsTipoValid()
        {
            return (cmbTipo.SelectedIndex >= 0);
        }

        private bool IsAllValid()
        {
            return (IsDescricaoValid() && IsValorValid() && IsTipoValid());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
