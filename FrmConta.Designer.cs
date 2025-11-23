namespace PartySalesTUCG
{
    partial class FrmConta
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cmbPessoa = new ComboBox();
            label1 = new Label();
            dgvExtrato = new DataGridView();
            id_festa = new DataGridViewTextBoxColumn();
            id_pessoa = new DataGridViewTextBoxColumn();
            id_venda = new DataGridViewTextBoxColumn();
            Descricao = new DataGridViewTextBoxColumn();
            Credito = new DataGridViewTextBoxColumn();
            Gasto = new DataGridViewTextBoxColumn();
            DtHora = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            txtSaldo = new TextBox();
            txtDebito = new TextBox();
            txtCredito = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnDinheiro = new Button();
            btnPix = new Button();
            label5 = new Label();
            txtCreditar = new TextBox();
            btnExportPDF = new Button();
            btnExportExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExtrato).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbPessoa
            // 
            cmbPessoa.DisplayMember = "Nome";
            cmbPessoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPessoa.FormattingEnabled = true;
            cmbPessoa.Location = new Point(12, 27);
            cmbPessoa.Name = "cmbPessoa";
            cmbPessoa.Size = new Size(451, 25);
            cmbPessoa.TabIndex = 3;
            cmbPessoa.ValueMember = "ID";
            cmbPessoa.SelectedValueChanged += cmbPessoa_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 2;
            label1.Text = "Selecione a Pessoa:";
            // 
            // dgvExtrato
            // 
            dgvExtrato.AllowUserToAddRows = false;
            dgvExtrato.AllowUserToDeleteRows = false;
            dgvExtrato.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvExtrato.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExtrato.Columns.AddRange(new DataGridViewColumn[] { id_festa, id_pessoa, id_venda, Descricao, Credito, Gasto, DtHora });
            dgvExtrato.Location = new Point(12, 58);
            dgvExtrato.Name = "dgvExtrato";
            dgvExtrato.ReadOnly = true;
            dgvExtrato.Size = new Size(774, 404);
            dgvExtrato.TabIndex = 4;
            // 
            // id_festa
            // 
            id_festa.HeaderText = "id_festa";
            id_festa.Name = "id_festa";
            id_festa.ReadOnly = true;
            id_festa.Visible = false;
            // 
            // id_pessoa
            // 
            id_pessoa.HeaderText = "id_pessoa";
            id_pessoa.Name = "id_pessoa";
            id_pessoa.ReadOnly = true;
            id_pessoa.Visible = false;
            // 
            // id_venda
            // 
            id_venda.HeaderText = "id_venda";
            id_venda.Name = "id_venda";
            id_venda.ReadOnly = true;
            id_venda.Visible = false;
            // 
            // Descricao
            // 
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            // 
            // Credito
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            Credito.DefaultCellStyle = dataGridViewCellStyle1;
            Credito.HeaderText = "Créditos";
            Credito.Name = "Credito";
            Credito.ReadOnly = true;
            // 
            // Gasto
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            Gasto.DefaultCellStyle = dataGridViewCellStyle2;
            Gasto.HeaderText = "Gastos";
            Gasto.Name = "Gasto";
            Gasto.ReadOnly = true;
            // 
            // DtHora
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            DtHora.DefaultCellStyle = dataGridViewCellStyle3;
            DtHora.HeaderText = "DtHora";
            DtHora.Name = "DtHora";
            DtHora.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSaldo);
            groupBox1.Controls.Add(txtDebito);
            groupBox1.Controls.Add(txtCredito);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 483);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(355, 100);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Saldo da Conta";
            // 
            // txtSaldo
            // 
            txtSaldo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            txtSaldo.Location = new Point(241, 49);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new Size(100, 27);
            txtSaldo.TabIndex = 5;
            txtSaldo.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDebito
            // 
            txtDebito.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            txtDebito.Location = new Point(125, 49);
            txtDebito.Name = "txtDebito";
            txtDebito.ReadOnly = true;
            txtDebito.Size = new Size(100, 27);
            txtDebito.TabIndex = 4;
            txtDebito.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCredito
            // 
            txtCredito.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            txtCredito.Location = new Point(8, 49);
            txtCredito.Name = "txtCredito";
            txtCredito.ReadOnly = true;
            txtCredito.Size = new Size(100, 27);
            txtCredito.TabIndex = 3;
            txtCredito.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(241, 31);
            label4.Name = "label4";
            label4.Size = new Size(47, 17);
            label4.TabIndex = 2;
            label4.Text = "Saldos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(125, 31);
            label3.Name = "label3";
            label3.Size = new Size(48, 17);
            label3.TabIndex = 1;
            label3.Text = "Gastos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(8, 31);
            label2.Name = "label2";
            label2.Size = new Size(57, 17);
            label2.TabIndex = 0;
            label2.Text = "Créditos";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDinheiro);
            groupBox2.Controls.Add(btnPix);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtCreditar);
            groupBox2.Location = new Point(479, 483);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(307, 100);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Creditar";
            // 
            // btnDinheiro
            // 
            btnDinheiro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDinheiro.Location = new Point(226, 52);
            btnDinheiro.Name = "btnDinheiro";
            btnDinheiro.Size = new Size(75, 23);
            btnDinheiro.TabIndex = 7;
            btnDinheiro.Text = "Dinheiro";
            btnDinheiro.UseVisualStyleBackColor = true;
            btnDinheiro.Click += btnDinheiro_Click;
            // 
            // btnPix
            // 
            btnPix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPix.Location = new Point(135, 53);
            btnPix.Name = "btnPix";
            btnPix.Size = new Size(75, 23);
            btnPix.TabIndex = 6;
            btnPix.Text = "PIX";
            btnPix.UseVisualStyleBackColor = true;
            btnPix.Click += btnPix_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 25);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 1;
            label5.Text = "Valor a Creditar:";
            // 
            // txtCreditar
            // 
            txtCreditar.Location = new Point(135, 22);
            txtCreditar.Name = "txtCreditar";
            txtCreditar.Size = new Size(166, 23);
            txtCreditar.TabIndex = 0;
            txtCreditar.TextAlign = HorizontalAlignment.Right;
            txtCreditar.Validated += txtCreditar_Validated;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Enabled = false;
            btnExportPDF.Location = new Point(630, 27);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(75, 23);
            btnExportPDF.TabIndex = 7;
            btnExportPDF.Text = "PDF";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Enabled = false;
            btnExportExcel.Location = new Point(711, 27);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(75, 23);
            btnExportExcel.TabIndex = 8;
            btnExportExcel.Text = "Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // FrmConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 595);
            Controls.Add(btnExportExcel);
            Controls.Add(btnExportPDF);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvExtrato);
            Controls.Add(cmbPessoa);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmConta";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Extrato Conta";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvExtrato).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPessoa;
        private Label label1;
        private DataGridView dgvExtrato;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtSaldo;
        private TextBox txtDebito;
        private TextBox txtCredito;
        private DataGridViewTextBoxColumn id_festa;
        private DataGridViewTextBoxColumn id_pessoa;
        private DataGridViewTextBoxColumn id_venda;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Credito;
        private DataGridViewTextBoxColumn Gasto;
        private DataGridViewTextBoxColumn DtHora;
        private GroupBox groupBox2;
        private TextBox txtCreditar;
        private Label label5;
        private Button btnDinheiro;
        private Button btnPix;
        private Button btnExportPDF;
        private Button btnExportExcel;
    }
}