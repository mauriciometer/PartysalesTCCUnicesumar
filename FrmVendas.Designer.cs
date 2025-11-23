namespace PartySalesTUCG
{
    partial class FrmVendas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpItensVenda = new FlowLayoutPanel();
            dgvPedido = new DataGridView();
            posicao = new DataGridViewTextBoxColumn();
            Item = new DataGridViewTextBoxColumn();
            Qtde = new DataGridViewTextBoxColumn();
            VlrUnit = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            vUnitConta = new DataGridViewTextBoxColumn();
            idItem = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtRecebido = new TextBox();
            btnPix = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            btnConta = new Button();
            label2 = new Label();
            txtFalta = new TextBox();
            btnDinheiro = new Button();
            txtTotal = new TextBox();
            btnFinaliza = new Button();
            groupBox2 = new GroupBox();
            lsbRecebidos = new ListBox();
            btnCancela = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // flpItensVenda
            // 
            flpItensVenda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpItensVenda.AutoScroll = true;
            flpItensVenda.BorderStyle = BorderStyle.Fixed3D;
            flpItensVenda.Location = new Point(0, 0);
            flpItensVenda.Name = "flpItensVenda";
            flpItensVenda.Size = new Size(487, 641);
            flpItensVenda.TabIndex = 0;
            // 
            // dgvPedido
            // 
            dgvPedido.AllowUserToAddRows = false;
            dgvPedido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.Columns.AddRange(new DataGridViewColumn[] { posicao, Item, Qtde, VlrUnit, Total, vUnitConta, idItem });
            dgvPedido.Location = new Point(563, 12);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.Size = new Size(511, 334);
            dgvPedido.TabIndex = 1;
            dgvPedido.CellEndEdit += dgvPedido_CellEndEdit;
            dgvPedido.RowsRemoved += dgvPedido_RowsRemoved;
            // 
            // posicao
            // 
            posicao.HeaderText = "posicao";
            posicao.Name = "posicao";
            posicao.Visible = false;
            // 
            // Item
            // 
            Item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Item.HeaderText = "Item";
            Item.Name = "Item";
            Item.ReadOnly = true;
            // 
            // Qtde
            // 
            Qtde.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Qtde.HeaderText = "Qtde";
            Qtde.Name = "Qtde";
            Qtde.Resizable = DataGridViewTriState.True;
            // 
            // VlrUnit
            // 
            VlrUnit.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VlrUnit.HeaderText = "Vlr. Unit. ";
            VlrUnit.Name = "VlrUnit";
            VlrUnit.ReadOnly = true;
            // 
            // Total
            // 
            Total.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // vUnitConta
            // 
            vUnitConta.HeaderText = "vUnitConta";
            vUnitConta.Name = "vUnitConta";
            vUnitConta.Visible = false;
            // 
            // idItem
            // 
            idItem.HeaderText = "idItem";
            idItem.Name = "idItem";
            idItem.ReadOnly = true;
            idItem.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(879, 360);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 2;
            label1.Text = "Total:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRecebido
            // 
            txtRecebido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRecebido.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRecebido.Location = new Point(110, 22);
            txtRecebido.Name = "txtRecebido";
            txtRecebido.ReadOnly = true;
            txtRecebido.Size = new Size(147, 29);
            txtRecebido.TabIndex = 3;
            txtRecebido.TextAlign = HorizontalAlignment.Right;
            // 
            // btnPix
            // 
            btnPix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPix.Location = new Point(18, 125);
            btnPix.Name = "btnPix";
            btnPix.Size = new Size(75, 23);
            btnPix.TabIndex = 4;
            btnPix.Text = "PIX";
            btnPix.UseVisualStyleBackColor = true;
            btnPix.Click += btnPix_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnConta);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtFalta);
            groupBox1.Controls.Add(btnDinheiro);
            groupBox1.Controls.Add(txtRecebido);
            groupBox1.Controls.Add(btnPix);
            groupBox1.Location = new Point(811, 392);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(263, 162);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pagamento:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(34, 30);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 9;
            label3.Text = "Recebido:";
            // 
            // btnConta
            // 
            btnConta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConta.Location = new Point(182, 125);
            btnConta.Name = "btnConta";
            btnConta.Size = new Size(75, 23);
            btnConta.TabIndex = 8;
            btnConta.Text = "CONTA";
            btnConta.UseVisualStyleBackColor = true;
            btnConta.Click += btnConta_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(34, 77);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 7;
            label2.Text = "Troco/Falta:";
            // 
            // txtFalta
            // 
            txtFalta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFalta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFalta.Location = new Point(110, 69);
            txtFalta.Name = "txtFalta";
            txtFalta.ReadOnly = true;
            txtFalta.Size = new Size(147, 29);
            txtFalta.TabIndex = 6;
            txtFalta.TextAlign = HorizontalAlignment.Right;
            // 
            // btnDinheiro
            // 
            btnDinheiro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDinheiro.Location = new Point(101, 125);
            btnDinheiro.Name = "btnDinheiro";
            btnDinheiro.Size = new Size(75, 23);
            btnDinheiro.TabIndex = 5;
            btnDinheiro.Text = "Dinheiro";
            btnDinheiro.UseVisualStyleBackColor = true;
            btnDinheiro.Click += btnDinheiro_Click;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(921, 352);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(147, 29);
            txtTotal.TabIndex = 9;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnFinaliza
            // 
            btnFinaliza.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFinaliza.Enabled = false;
            btnFinaliza.Location = new Point(643, 560);
            btnFinaliza.Name = "btnFinaliza";
            btnFinaliza.Size = new Size(75, 23);
            btnFinaliza.TabIndex = 10;
            btnFinaliza.Text = "Finaliza!";
            btnFinaliza.UseVisualStyleBackColor = true;
            btnFinaliza.Click += btnFinaliza_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(lsbRecebidos);
            groupBox2.Location = new Point(563, 392);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(222, 162);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Recebidos:";
            // 
            // lsbRecebidos
            // 
            lsbRecebidos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lsbRecebidos.BackColor = SystemColors.Control;
            lsbRecebidos.FormattingEnabled = true;
            lsbRecebidos.Location = new Point(6, 22);
            lsbRecebidos.Name = "lsbRecebidos";
            lsbRecebidos.SelectionMode = SelectionMode.None;
            lsbRecebidos.Size = new Size(210, 139);
            lsbRecebidos.TabIndex = 0;
            // 
            // btnCancela
            // 
            btnCancela.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancela.Location = new Point(1007, 606);
            btnCancela.Name = "btnCancela";
            btnCancela.Size = new Size(75, 23);
            btnCancela.TabIndex = 12;
            btnCancela.Text = "Cancelar";
            btnCancela.UseVisualStyleBackColor = true;
            btnCancela.Click += btnCancela_Click;
            // 
            // FrmVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 641);
            Controls.Add(btnCancela);
            Controls.Add(groupBox2);
            Controls.Add(btnFinaliza);
            Controls.Add(txtTotal);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dgvPedido);
            Controls.Add(flpItensVenda);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVendas";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vendas Festa";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpItensVenda;
        private DataGridView dgvPedido;
        private Label label1;
        private TextBox txtRecebido;
        private Button btnPix;
        private GroupBox groupBox1;
        private Button btnConta;
        private Label label2;
        private TextBox txtFalta;
        private Button btnDinheiro;
        private TextBox txtTotal;
        private Label label3;
        private Button btnFinaliza;
        private DataGridViewTextBoxColumn posicao;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn Qtde;
        private DataGridViewTextBoxColumn VlrUnit;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn vUnitConta;
        private DataGridViewTextBoxColumn idItem;
        private GroupBox groupBox2;
        private ListBox lsbRecebidos;
        private Button btnCancela;
    }
}
