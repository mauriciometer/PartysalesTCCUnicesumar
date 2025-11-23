namespace PartySalesTUCG
{
    partial class FrmCadFesta
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
            dgvFestas = new DataGridView();
            dtpDataFesta = new DateTimePicker();
            txtNomeFesta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFestas).BeginInit();
            SuspendLayout();
            // 
            // dgvFestas
            // 
            dgvFestas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFestas.Location = new Point(12, 12);
            dgvFestas.Name = "dgvFestas";
            dgvFestas.Size = new Size(415, 150);
            dgvFestas.TabIndex = 0;
            // 
            // dtpDataFesta
            // 
            dtpDataFesta.Location = new Point(227, 212);
            dtpDataFesta.Name = "dtpDataFesta";
            dtpDataFesta.Size = new Size(200, 23);
            dtpDataFesta.TabIndex = 1;
            // 
            // txtNomeFesta
            // 
            txtNomeFesta.Location = new Point(12, 212);
            txtNomeFesta.Name = "txtNomeFesta";
            txtNomeFesta.Size = new Size(209, 23);
            txtNomeFesta.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 194);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 194);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "Data";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(352, 250);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FrmCadFesta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 288);
            Controls.Add(btnSalvar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNomeFesta);
            Controls.Add(dtpDataFesta);
            Controls.Add(dgvFestas);
            Name = "FrmCadFesta";
            Text = "Cadastro Festas";
            ((System.ComponentModel.ISupportInitialize)dgvFestas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFestas;
        private DateTimePicker dtpDataFesta;
        private TextBox txtNomeFesta;
        private Label label1;
        private Label label2;
        private Button btnSalvar;
    }
}