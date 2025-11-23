namespace PartySalesTUCG
{
    partial class FrmItensVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            cmbFesta = new ComboBox();
            fESTATableAdapterBindingSource = new BindingSource(components);
            label2 = new Label();
            dgvItens = new DataGridView();
            groupBox1 = new GroupBox();
            ckbAtivo = new CheckBox();
            btnNovo = new Button();
            txtValor = new TextBox();
            btnGravar = new Button();
            cmbTipo = new ComboBox();
            txtDescricao = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            toolTip1 = new ToolTip(components);
            erroDescricao = new ErrorProvider(components);
            erroValor = new ErrorProvider(components);
            erroTipo = new ErrorProvider(components);
            ID = new DataGridViewTextBoxColumn();
            ID_FESTA = new DataGridViewTextBoxColumn();
            Descricao = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewComboBoxColumn();
            Ativo = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)fESTATableAdapterBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)erroDescricao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)erroValor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)erroTipo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione a Festa";
            // 
            // cmbFesta
            // 
            cmbFesta.DataSource = fESTATableAdapterBindingSource;
            cmbFesta.DisplayMember = "Nome";
            cmbFesta.FormattingEnabled = true;
            cmbFesta.Location = new Point(12, 27);
            cmbFesta.Name = "cmbFesta";
            cmbFesta.Size = new Size(303, 23);
            cmbFesta.TabIndex = 1;
            cmbFesta.ValueMember = "ID";
            cmbFesta.SelectedValueChanged += cmbFesta_SelectedValueChanged;
            // 
            // fESTATableAdapterBindingSource
            // 
            fESTATableAdapterBindingSource.DataMember = "FESTA";
            fESTATableAdapterBindingSource.DataSource = typeof(dsTUCG);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Itens";
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvItens.BorderStyle = BorderStyle.None;
            dgvItens.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvItens.Columns.AddRange(new DataGridViewColumn[] { ID, ID_FESTA, Descricao, Valor, Tipo, Ativo });
            dgvItens.Location = new Point(12, 80);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvItens.Size = new Size(544, 232);
            dgvItens.TabIndex = 3;
            dgvItens.CellEndEdit += dgvItens_CellEndEdit;
            dgvItens.RowEnter += dgvItens_RowEnter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ckbAtivo);
            groupBox1.Controls.Add(btnNovo);
            groupBox1.Controls.Add(txtValor);
            groupBox1.Controls.Add(btnGravar);
            groupBox1.Controls.Add(cmbTipo);
            groupBox1.Controls.Add(txtDescricao);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 346);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(517, 199);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastrar Item";
            // 
            // ckbAtivo
            // 
            ckbAtivo.AutoSize = true;
            ckbAtivo.Checked = true;
            ckbAtivo.CheckState = CheckState.Checked;
            ckbAtivo.Location = new Point(6, 172);
            ckbAtivo.Name = "ckbAtivo";
            ckbAtivo.Size = new Size(54, 19);
            ckbAtivo.TabIndex = 9;
            ckbAtivo.Text = "Ativo";
            ckbAtivo.UseVisualStyleBackColor = true;
            ckbAtivo.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(436, 22);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 8;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Visible = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(6, 90);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(297, 23);
            txtValor.TabIndex = 7;
            txtValor.TextAlign = HorizontalAlignment.Right;
            txtValor.Leave += txtValor_Leave;
            txtValor.Validated += txtValor_Validated;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(436, 160);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "1 - Porções", "2 - Bebidas", "3 - Combo", "4 - Sobremesa", "5 - Zera Estoque" });
            cmbTipo.Location = new Point(6, 143);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(297, 23);
            cmbTipo.TabIndex = 5;
            cmbTipo.Validated += cmbTipo_Validated;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(6, 37);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(297, 23);
            txtDescricao.TabIndex = 3;
            toolTip1.SetToolTip(txtDescricao, "Descrição Obrigatoria");
            txtDescricao.Validated += txtDescricao_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 125);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 2;
            label5.Text = "Tipo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 72);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 1;
            label4.Text = "Valor Venda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 0;
            label3.Text = "Descricação";
            // 
            // toolTip1
            // 
            toolTip1.Active = false;
            // 
            // erroDescricao
            // 
            erroDescricao.ContainerControl = this;
            // 
            // erroValor
            // 
            erroValor.BlinkRate = 150;
            erroValor.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            erroValor.ContainerControl = this;
            // 
            // erroTipo
            // 
            erroTipo.BlinkRate = 150;
            erroTipo.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            erroTipo.ContainerControl = this;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.Width = 5;
            // 
            // ID_FESTA
            // 
            ID_FESTA.HeaderText = "ID_FESTA";
            ID_FESTA.Name = "ID_FESTA";
            ID_FESTA.ReadOnly = true;
            ID_FESTA.Visible = false;
            ID_FESTA.Width = 5;
            // 
            // Descricao
            // 
            Descricao.HeaderText = "Descricao";
            Descricao.MinimumWidth = 250;
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 250;
            // 
            // Valor
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            Valor.DefaultCellStyle = dataGridViewCellStyle1;
            Valor.HeaderText = "Valor";
            Valor.MinimumWidth = 85;
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            Valor.Width = 85;
            // 
            // Tipo
            // 
            Tipo.HeaderText = "Tipo";
            Tipo.Items.AddRange(new object[] { "1 - Porções", "2 - Bebidas", "3 - Combo", "4 - Sobremesa", "5 - Zera Estoque" });
            Tipo.MinimumWidth = 120;
            Tipo.Name = "Tipo";
            Tipo.ReadOnly = true;
            Tipo.Width = 120;
            // 
            // Ativo
            // 
            Ativo.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Ativo.FalseValue = "\"False\"";
            Ativo.HeaderText = "Ativo";
            Ativo.Name = "Ativo";
            Ativo.ReadOnly = true;
            Ativo.TrueValue = "\"True\"";
            Ativo.Width = 41;
            // 
            // FrmItensVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 567);
            Controls.Add(groupBox1);
            Controls.Add(dgvItens);
            Controls.Add(label2);
            Controls.Add(cmbFesta);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmItensVenda";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Itens";
            ((System.ComponentModel.ISupportInitialize)fESTATableAdapterBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)erroDescricao).EndInit();
            ((System.ComponentModel.ISupportInitialize)erroValor).EndInit();
            ((System.ComponentModel.ISupportInitialize)erroTipo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbFesta;
        private Label label2;
        private DataGridView dgvItens;
        private GroupBox groupBox1;
        private TextBox txtDescricao;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnGravar;
        private ComboBox cmbTipo;
        private BindingSource fESTATableAdapterBindingSource;
        private TextBox txtValor;
        private Button btnNovo;
        private ToolTip toolTip1;
        private ErrorProvider erroDescricao;
        private ErrorProvider erroValor;
        private ErrorProvider erroTipo;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ID_FESTA;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Valor;
        private DataGridViewComboBoxColumn Tipo;
        private DataGridViewCheckBoxColumn Ativo;
        private CheckBox ckbAtivo;
    }
}