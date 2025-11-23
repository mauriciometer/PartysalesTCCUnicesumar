namespace PartySalesTUCG
{
    partial class FrmInicio
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
            bindingSource1 = new BindingSource(components);
            dgvFesta = new DataGridView();
            label1 = new Label();
            lbSelecao = new Label();
            label2 = new Label();
            txtNome = new TextBox();
            btnSalvar = new Button();
            btnCancela = new Button();
            grpSenha = new GroupBox();
            txtSenha = new MaskedTextBox();
            erroSenha = new ErrorProvider(components);
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFesta).BeginInit();
            grpSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)erroSenha).BeginInit();
            SuspendLayout();
            // 
            // dgvFesta
            // 
            dgvFesta.AllowUserToAddRows = false;
            dgvFesta.AllowUserToDeleteRows = false;
            dgvFesta.AllowUserToResizeColumns = false;
            dgvFesta.AllowUserToResizeRows = false;
            dgvFesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFesta.Location = new Point(12, 43);
            dgvFesta.MultiSelect = false;
            dgvFesta.Name = "dgvFesta";
            dgvFesta.ReadOnly = true;
            dgvFesta.RowHeadersVisible = false;
            dgvFesta.Size = new Size(480, 78);
            dgvFesta.TabIndex = 0;
            dgvFesta.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 20);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "Selecione a Festa:";
            // 
            // lbSelecao
            // 
            lbSelecao.AutoSize = true;
            lbSelecao.Location = new Point(13, 124);
            lbSelecao.Name = "lbSelecao";
            lbSelecao.Size = new Size(0, 15);
            lbSelecao.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 156);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 3;
            label2.Text = "Informe seu Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 174);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(396, 23);
            txtNome.TabIndex = 4;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(12, 209);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancela
            // 
            btnCancela.Location = new Point(438, 209);
            btnCancela.Name = "btnCancela";
            btnCancela.Size = new Size(75, 23);
            btnCancela.TabIndex = 6;
            btnCancela.Text = "Cancela";
            btnCancela.UseVisualStyleBackColor = true;
            btnCancela.Click += btnCancela_Click;
            // 
            // grpSenha
            // 
            grpSenha.Controls.Add(btnOk);
            grpSenha.Controls.Add(txtSenha);
            grpSenha.Location = new Point(143, 71);
            grpSenha.Name = "grpSenha";
            grpSenha.Size = new Size(200, 100);
            grpSenha.TabIndex = 7;
            grpSenha.TabStop = false;
            grpSenha.Text = "Senha de Acesso";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(27, 27);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(149, 23);
            txtSenha.TabIndex = 0;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.Validated += txtSenha_Validated;
            // 
            // erroSenha
            // 
            erroSenha.ContainerControl = this;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(63, 56);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 256);
            ControlBox = false;
            Controls.Add(grpSenha);
            Controls.Add(btnCancela);
            Controls.Add(btnSalvar);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(lbSelecao);
            Controls.Add(label1);
            Controls.Add(dgvFesta);
            MinimizeBox = false;
            Name = "FrmInicio";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar >>";
            Load += FrmInicio_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFesta).EndInit();
            grpSenha.ResumeLayout(false);
            grpSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)erroSenha).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource bindingSource1;
        private DataGridView dgvFesta;
        private Label label1;
        private Label lbSelecao;
        private Label label2;
        private TextBox txtNome;
        private Button btnSalvar;
        private Button btnCancela;
        private GroupBox grpSenha;
        private MaskedTextBox txtSenha;
        private Button btnOk;
        private ErrorProvider erroSenha;
    }
}