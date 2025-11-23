namespace PartySalesTUCG
{
    partial class FrmCaixa
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            lbVlrAbertura = new Label();
            btnAbrir = new Button();
            lbFechado = new Label();
            groupBox2 = new GroupBox();
            grpAbrir = new GroupBox();
            btnAbreCaixa = new Button();
            txtVlrAbertura = new TextBox();
            label1 = new Label();
            dgvCaixa = new DataGridView();
            DESCRICAO = new DataGridViewTextBoxColumn();
            ENTRADA = new DataGridViewTextBoxColumn();
            SAIDA = new DataGridViewTextBoxColumn();
            OPERADOR = new DataGridViewTextBoxColumn();
            grpFecha = new GroupBox();
            btnFechaCaixa = new Button();
            lbSaldoTeorico = new Label();
            label2 = new Label();
            btnRegEntrada = new Button();
            grpRegMov = new GroupBox();
            btnRegSaida = new Button();
            grpRegistro = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            btnCancelaReg = new Button();
            btnGravaMov = new Button();
            txtVlrMov = new TextBox();
            txtDescMov = new TextBox();
            erroTxtMov = new ErrorProvider(components);
            erroTxtVlr = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            grpAbrir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCaixa).BeginInit();
            grpFecha.SuspendLayout();
            grpRegMov.SuspendLayout();
            grpRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)erroTxtMov).BeginInit();
            ((System.ComponentModel.ISupportInitialize)erroTxtVlr).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbVlrAbertura);
            groupBox1.Controls.Add(btnAbrir);
            groupBox1.Controls.Add(lbFechado);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(805, 84);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Abertura";
            // 
            // lbVlrAbertura
            // 
            lbVlrAbertura.AutoSize = true;
            lbVlrAbertura.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbVlrAbertura.Location = new Point(337, 28);
            lbVlrAbertura.Name = "lbVlrAbertura";
            lbVlrAbertura.Size = new Size(76, 32);
            lbVlrAbertura.TabIndex = 2;
            lbVlrAbertura.Text = "label1";
            lbVlrAbertura.TextAlign = ContentAlignment.MiddleCenter;
            lbVlrAbertura.Visible = false;
            // 
            // btnAbrir
            // 
            btnAbrir.BackColor = Color.Blue;
            btnAbrir.FlatStyle = FlatStyle.Flat;
            btnAbrir.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAbrir.ForeColor = Color.Yellow;
            btnAbrir.Location = new Point(639, 25);
            btnAbrir.Margin = new Padding(1);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(122, 41);
            btnAbrir.TabIndex = 1;
            btnAbrir.Text = "ABRIR";
            btnAbrir.TextAlign = ContentAlignment.TopCenter;
            btnAbrir.UseVisualStyleBackColor = false;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // lbFechado
            // 
            lbFechado.AutoSize = true;
            lbFechado.BackColor = Color.Black;
            lbFechado.BorderStyle = BorderStyle.Fixed3D;
            lbFechado.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFechado.ForeColor = Color.Red;
            lbFechado.Location = new Point(41, 28);
            lbFechado.Name = "lbFechado";
            lbFechado.Size = new Size(122, 34);
            lbFechado.TabIndex = 0;
            lbFechado.Text = "FECHADO";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(grpAbrir);
            groupBox2.Controls.Add(dgvCaixa);
            groupBox2.Location = new Point(12, 102);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(805, 232);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Movimento";
            // 
            // grpAbrir
            // 
            grpAbrir.BackColor = Color.White;
            grpAbrir.Controls.Add(btnAbreCaixa);
            grpAbrir.Controls.Add(txtVlrAbertura);
            grpAbrir.Controls.Add(label1);
            grpAbrir.FlatStyle = FlatStyle.Flat;
            grpAbrir.Location = new Point(226, 41);
            grpAbrir.Name = "grpAbrir";
            grpAbrir.Size = new Size(311, 164);
            grpAbrir.TabIndex = 2;
            grpAbrir.TabStop = false;
            grpAbrir.Visible = false;
            // 
            // btnAbreCaixa
            // 
            btnAbreCaixa.Location = new Point(111, 109);
            btnAbreCaixa.Name = "btnAbreCaixa";
            btnAbreCaixa.Size = new Size(75, 23);
            btnAbreCaixa.TabIndex = 2;
            btnAbreCaixa.Text = "Abrir!";
            btnAbreCaixa.UseVisualStyleBackColor = true;
            btnAbreCaixa.Click += btnAbreCaixa_Click;
            // 
            // txtVlrAbertura
            // 
            txtVlrAbertura.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtVlrAbertura.Location = new Point(6, 65);
            txtVlrAbertura.Name = "txtVlrAbertura";
            txtVlrAbertura.Size = new Size(299, 29);
            txtVlrAbertura.TabIndex = 1;
            txtVlrAbertura.TextAlign = HorizontalAlignment.Center;
            txtVlrAbertura.Validated += textBox1_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 47);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Valor de abertura:";
            // 
            // dgvCaixa
            // 
            dgvCaixa.AllowUserToAddRows = false;
            dgvCaixa.AllowUserToDeleteRows = false;
            dgvCaixa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCaixa.Columns.AddRange(new DataGridViewColumn[] { DESCRICAO, ENTRADA, SAIDA, OPERADOR });
            dgvCaixa.Location = new Point(6, 22);
            dgvCaixa.Name = "dgvCaixa";
            dgvCaixa.ReadOnly = true;
            dgvCaixa.Size = new Size(793, 204);
            dgvCaixa.TabIndex = 3;
            // 
            // DESCRICAO
            // 
            DESCRICAO.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DESCRICAO.HeaderText = "DESCRICAO";
            DESCRICAO.Name = "DESCRICAO";
            DESCRICAO.ReadOnly = true;
            DESCRICAO.SortMode = DataGridViewColumnSortMode.NotSortable;
            DESCRICAO.Width = 76;
            // 
            // ENTRADA
            // 
            ENTRADA.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            ENTRADA.DefaultCellStyle = dataGridViewCellStyle4;
            ENTRADA.HeaderText = "ENTRADA";
            ENTRADA.Name = "ENTRADA";
            ENTRADA.ReadOnly = true;
            ENTRADA.SortMode = DataGridViewColumnSortMode.NotSortable;
            ENTRADA.Width = 66;
            // 
            // SAIDA
            // 
            SAIDA.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            SAIDA.DefaultCellStyle = dataGridViewCellStyle5;
            SAIDA.HeaderText = "SAIDA";
            SAIDA.Name = "SAIDA";
            SAIDA.ReadOnly = true;
            SAIDA.SortMode = DataGridViewColumnSortMode.NotSortable;
            SAIDA.Width = 46;
            // 
            // OPERADOR
            // 
            OPERADOR.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            OPERADOR.DefaultCellStyle = dataGridViewCellStyle6;
            OPERADOR.HeaderText = "OPERADOR";
            OPERADOR.Name = "OPERADOR";
            OPERADOR.ReadOnly = true;
            OPERADOR.SortMode = DataGridViewColumnSortMode.NotSortable;
            OPERADOR.Width = 74;
            // 
            // grpFecha
            // 
            grpFecha.Controls.Add(btnFechaCaixa);
            grpFecha.Controls.Add(lbSaldoTeorico);
            grpFecha.Controls.Add(label2);
            grpFecha.Location = new Point(12, 340);
            grpFecha.Name = "grpFecha";
            grpFecha.Size = new Size(413, 84);
            grpFecha.TabIndex = 1;
            grpFecha.TabStop = false;
            grpFecha.Text = "Fechamento";
            // 
            // btnFechaCaixa
            // 
            btnFechaCaixa.Location = new Point(332, 22);
            btnFechaCaixa.Name = "btnFechaCaixa";
            btnFechaCaixa.Size = new Size(75, 47);
            btnFechaCaixa.TabIndex = 4;
            btnFechaCaixa.Text = "Fechar Caixa";
            btnFechaCaixa.UseVisualStyleBackColor = true;
            btnFechaCaixa.Click += btnFechaCaixa_Click;
            // 
            // lbSaldoTeorico
            // 
            lbSaldoTeorico.AutoSize = true;
            lbSaldoTeorico.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSaldoTeorico.Location = new Point(93, 21);
            lbSaldoTeorico.Name = "lbSaldoTeorico";
            lbSaldoTeorico.Size = new Size(0, 32);
            lbSaldoTeorico.TabIndex = 3;
            lbSaldoTeorico.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 35);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 0;
            label2.Text = "Saldo Teórico:";
            // 
            // btnRegEntrada
            // 
            btnRegEntrada.Location = new Point(118, 35);
            btnRegEntrada.Name = "btnRegEntrada";
            btnRegEntrada.Size = new Size(75, 23);
            btnRegEntrada.TabIndex = 2;
            btnRegEntrada.Tag = "E";
            btnRegEntrada.Text = "Entrada";
            btnRegEntrada.UseVisualStyleBackColor = true;
            btnRegEntrada.Click += btnRegMovimento;
            // 
            // grpRegMov
            // 
            grpRegMov.Controls.Add(btnRegSaida);
            grpRegMov.Controls.Add(btnRegEntrada);
            grpRegMov.Location = new Point(431, 340);
            grpRegMov.Name = "grpRegMov";
            grpRegMov.Size = new Size(386, 84);
            grpRegMov.TabIndex = 3;
            grpRegMov.TabStop = false;
            grpRegMov.Text = "Registrar movimento";
            // 
            // btnRegSaida
            // 
            btnRegSaida.Location = new Point(220, 35);
            btnRegSaida.Name = "btnRegSaida";
            btnRegSaida.Size = new Size(75, 23);
            btnRegSaida.TabIndex = 3;
            btnRegSaida.Tag = "R";
            btnRegSaida.Text = "Saída";
            btnRegSaida.UseVisualStyleBackColor = true;
            btnRegSaida.Click += btnRegMovimento;
            // 
            // grpRegistro
            // 
            grpRegistro.Controls.Add(label4);
            grpRegistro.Controls.Add(label3);
            grpRegistro.Controls.Add(btnCancelaReg);
            grpRegistro.Controls.Add(btnGravaMov);
            grpRegistro.Controls.Add(txtVlrMov);
            grpRegistro.Controls.Add(txtDescMov);
            grpRegistro.Location = new Point(12, 430);
            grpRegistro.Name = "grpRegistro";
            grpRegistro.Size = new Size(805, 72);
            grpRegistro.TabIndex = 4;
            grpRegistro.TabStop = false;
            grpRegistro.Text = "Registro ->";
            grpRegistro.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(537, 21);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 5;
            label4.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 21);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Descrição";
            // 
            // btnCancelaReg
            // 
            btnCancelaReg.Location = new Point(720, 42);
            btnCancelaReg.Name = "btnCancelaReg";
            btnCancelaReg.Size = new Size(75, 23);
            btnCancelaReg.TabIndex = 3;
            btnCancelaReg.Text = "Cancela!";
            btnCancelaReg.UseVisualStyleBackColor = true;
            btnCancelaReg.Click += btnCancelaReg_Click;
            // 
            // btnGravaMov
            // 
            btnGravaMov.Location = new Point(720, 13);
            btnGravaMov.Name = "btnGravaMov";
            btnGravaMov.Size = new Size(75, 23);
            btnGravaMov.TabIndex = 2;
            btnGravaMov.Text = "Ok!";
            btnGravaMov.UseVisualStyleBackColor = true;
            btnGravaMov.Click += btnGravaMov_Click;
            // 
            // txtVlrMov
            // 
            txtVlrMov.Location = new Point(537, 42);
            txtVlrMov.Name = "txtVlrMov";
            txtVlrMov.Size = new Size(177, 23);
            txtVlrMov.TabIndex = 1;
            txtVlrMov.Validated += txtVlrMov_Validated;
            // 
            // txtDescMov
            // 
            txtDescMov.Location = new Point(6, 42);
            txtDescMov.Name = "txtDescMov";
            txtDescMov.Size = new Size(525, 23);
            txtDescMov.TabIndex = 0;
            txtDescMov.Validated += txtDescMov_Validated;
            // 
            // erroTxtMov
            // 
            erroTxtMov.BlinkRate = 50;
            erroTxtMov.ContainerControl = this;
            // 
            // erroTxtVlr
            // 
            erroTxtVlr.BlinkRate = 100;
            erroTxtVlr.ContainerControl = this;
            // 
            // FrmCaixa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 525);
            Controls.Add(grpRegistro);
            Controls.Add(grpRegMov);
            Controls.Add(grpFecha);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCaixa";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Caixa da Festa";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            grpAbrir.ResumeLayout(false);
            grpAbrir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCaixa).EndInit();
            grpFecha.ResumeLayout(false);
            grpFecha.PerformLayout();
            grpRegMov.ResumeLayout(false);
            grpRegistro.ResumeLayout(false);
            grpRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)erroTxtMov).EndInit();
            ((System.ComponentModel.ISupportInitialize)erroTxtVlr).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lbFechado;
        private GroupBox groupBox2;
        private GroupBox grpFecha;
        private Button btnAbrir;
        private Label lbVlrAbertura;
        private GroupBox grpAbrir;
        private Button btnAbreCaixa;
        private TextBox txtVlrAbertura;
        private Label label1;
        private DataGridView dgvCaixa;
        private DataGridViewTextBoxColumn DESCRICAO;
        private DataGridViewTextBoxColumn ENTRADA;
        private DataGridViewTextBoxColumn SAIDA;
        private DataGridViewTextBoxColumn OPERADOR;
        private Label lbSaldoTeorico;
        private Label label2;
        private Button btnRegEntrada;
        private GroupBox grpRegMov;
        private Button btnRegSaida;
        private GroupBox grpRegistro;
        private TextBox txtVlrMov;
        private TextBox txtDescMov;
        private Button btnCancelaReg;
        private Button btnGravaMov;
        private Label label4;
        private Label label3;
        private ErrorProvider erroTxtMov;
        private ErrorProvider erroTxtVlr;
        private Button btnFechaCaixa;
    }
}