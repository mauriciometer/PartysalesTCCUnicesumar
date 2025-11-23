namespace PartySalesTUCG
{
    partial class FrmPgConta
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
            label1 = new Label();
            cmbPessoa = new ComboBox();
            pESSOASBindingSource = new BindingSource(components);
            btnConfirma = new Button();
            btnCancela = new Button();
            label2 = new Label();
            txtValor = new TextBox();
            btnCadastra = new Button();
            txtSaldo = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pESSOASBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione a Pessoa:";
            // 
            // cmbPessoa
            // 
            cmbPessoa.DataSource = pESSOASBindingSource;
            cmbPessoa.DisplayMember = "Nome";
            cmbPessoa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPessoa.FormattingEnabled = true;
            cmbPessoa.Location = new Point(12, 27);
            cmbPessoa.Name = "cmbPessoa";
            cmbPessoa.Size = new Size(250, 29);
            cmbPessoa.TabIndex = 1;
            cmbPessoa.ValueMember = "ID";
            cmbPessoa.SelectedIndexChanged += cmbPessoa_SelectedIndexChanged;
            cmbPessoa.SelectionChangeCommitted += cmbPessoa_SelectionChangeCommitted;
            cmbPessoa.SelectedValueChanged += cmbPessoa_SelectedValueChanged;
            // 
            // pESSOASBindingSource
            // 
            pESSOASBindingSource.AllowNew = false;
            pESSOASBindingSource.DataMember = "PESSOAS";
            pESSOASBindingSource.DataSource = typeof(dsTUCG);
            // 
            // btnConfirma
            // 
            btnConfirma.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirma.Location = new Point(106, 176);
            btnConfirma.Name = "btnConfirma";
            btnConfirma.Size = new Size(156, 32);
            btnConfirma.TabIndex = 2;
            btnConfirma.Text = "Vai pra conta!!";
            btnConfirma.UseVisualStyleBackColor = true;
            btnConfirma.Click += btnConfirma_Click;
            // 
            // btnCancela
            // 
            btnCancela.Location = new Point(171, 214);
            btnCancela.Name = "btnCancela";
            btnCancela.Size = new Size(91, 23);
            btnCancela.TabIndex = 3;
            btnCancela.Text = "Melhor não!";
            btnCancela.UseVisualStyleBackColor = true;
            btnCancela.Click += btnCancela_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 109);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 4;
            label2.Text = "Valor";
            // 
            // txtValor
            // 
            txtValor.BorderStyle = BorderStyle.FixedSingle;
            txtValor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtValor.Location = new Point(12, 127);
            txtValor.Name = "txtValor";
            txtValor.ReadOnly = true;
            txtValor.Size = new Size(250, 29);
            txtValor.TabIndex = 5;
            txtValor.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCadastra
            // 
            btnCadastra.Location = new Point(12, 214);
            btnCadastra.Name = "btnCadastra";
            btnCadastra.Size = new Size(75, 23);
            btnCadastra.TabIndex = 6;
            btnCadastra.Text = "Cadastrar";
            btnCadastra.UseVisualStyleBackColor = true;
            btnCadastra.Click += btnCadastra_Click;
            // 
            // txtSaldo
            // 
            txtSaldo.BorderStyle = BorderStyle.FixedSingle;
            txtSaldo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSaldo.Location = new Point(12, 77);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new Size(250, 29);
            txtSaldo.TabIndex = 8;
            txtSaldo.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 59);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 7;
            label3.Text = "Saldo atual:";
            // 
            // FrmPgConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 251);
            ControlBox = false;
            Controls.Add(txtSaldo);
            Controls.Add(label3);
            Controls.Add(btnCadastra);
            Controls.Add(txtValor);
            Controls.Add(label2);
            Controls.Add(btnCancela);
            Controls.Add(btnConfirma);
            Controls.Add(cmbPessoa);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPgConta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Por na Conta!!";
            ((System.ComponentModel.ISupportInitialize)pESSOASBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbPessoa;
        private Button btnConfirma;
        private Button btnCancela;
        private Label label2;
        private TextBox txtValor;
        private BindingSource pESSOASBindingSource;
        private Button btnCadastra;
        private TextBox txtSaldo;
        private Label label3;
    }
}