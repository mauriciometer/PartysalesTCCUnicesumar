namespace PartySalesTUCG
{
    partial class FrmCadPessoa
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
            groupBox1 = new GroupBox();
            txtTelefone = new MaskedTextBox();
            btnGrava = new Button();
            txtContato = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtNome = new TextBox();
            label1 = new Label();
            dgvPessoas = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            ContatoTerreiro = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPessoas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTelefone);
            groupBox1.Controls.Add(btnGrava);
            groupBox1.Controls.Add(txtContato);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNome);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(269, 217);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados";
            // 
            // txtTelefone
            // 
            txtTelefone.Font = new Font("Segoe UI", 11.25F);
            txtTelefone.Location = new Point(6, 94);
            txtTelefone.Mask = "(99)000000000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(257, 27);
            txtTelefone.TabIndex = 2;
            txtTelefone.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGrava
            // 
            btnGrava.Location = new Point(188, 179);
            btnGrava.Name = "btnGrava";
            btnGrava.Size = new Size(75, 23);
            btnGrava.TabIndex = 4;
            btnGrava.Text = "Salvar";
            btnGrava.UseVisualStyleBackColor = true;
            btnGrava.Click += btnGrava_Click;
            // 
            // txtContato
            // 
            txtContato.Font = new Font("Segoe UI", 11.25F);
            txtContato.Location = new Point(6, 146);
            txtContato.Name = "txtContato";
            txtContato.Size = new Size(257, 27);
            txtContato.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 128);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 4;
            label3.Text = "Contato no Terreiro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 75);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Telefone";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 11.25F);
            txtNome.Location = new Point(6, 37);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(257, 27);
            txtNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // dgvPessoas
            // 
            dgvPessoas.AllowUserToAddRows = false;
            dgvPessoas.AllowUserToDeleteRows = false;
            dgvPessoas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPessoas.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Telefone, ContatoTerreiro });
            dgvPessoas.Location = new Point(321, 29);
            dgvPessoas.Name = "dgvPessoas";
            dgvPessoas.ReadOnly = true;
            dgvPessoas.Size = new Size(467, 200);
            dgvPessoas.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            // 
            // Telefone
            // 
            Telefone.HeaderText = "Telefone";
            Telefone.Name = "Telefone";
            Telefone.ReadOnly = true;
            // 
            // ContatoTerreiro
            // 
            ContatoTerreiro.HeaderText = "Contato Terreiro";
            ContatoTerreiro.Name = "ContatoTerreiro";
            ContatoTerreiro.ReadOnly = true;
            // 
            // FrmCadPessoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 243);
            Controls.Add(dgvPessoas);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCadPessoa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastrar Pessoas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPessoas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnGrava;
        private TextBox txtContato;
        private Label label3;
        private Label label2;
        private TextBox txtNome;
        private Label label1;
        private DataGridView dgvPessoas;
        private MaskedTextBox txtTelefone;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Telefone;
        private DataGridViewTextBoxColumn ContatoTerreiro;
    }
}