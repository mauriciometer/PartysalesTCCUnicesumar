namespace PartySalesTUCG
{
    partial class FrmPix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPix));
            pbPix = new PictureBox();
            btnPago = new Button();
            txtValor = new TextBox();
            btnCancela = new Button();
            ((System.ComponentModel.ISupportInitialize)pbPix).BeginInit();
            SuspendLayout();
            // 
            // pbPix
            // 
            pbPix.BorderStyle = BorderStyle.FixedSingle;
            pbPix.Location = new Point(197, 496);
            pbPix.Name = "pbPix";
            pbPix.Size = new Size(230, 230);
            pbPix.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPix.TabIndex = 0;
            pbPix.TabStop = false;
            // 
            // btnPago
            // 
            btnPago.FlatStyle = FlatStyle.Popup;
            btnPago.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPago.Location = new Point(462, 496);
            btnPago.Name = "btnPago";
            btnPago.Size = new Size(122, 87);
            btnPago.TabIndex = 1;
            btnPago.Text = "Pago!";
            btnPago.UseVisualStyleBackColor = true;
            btnPago.Click += btnPago_Click;
            // 
            // txtValor
            // 
            txtValor.Cursor = Cursors.IBeam;
            txtValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtValor.Location = new Point(142, 732);
            txtValor.Name = "txtValor";
            txtValor.ReadOnly = true;
            txtValor.Size = new Size(330, 39);
            txtValor.TabIndex = 2;
            txtValor.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCancela
            // 
            btnCancela.Location = new Point(482, 589);
            btnCancela.Name = "btnCancela";
            btnCancela.Size = new Size(75, 23);
            btnCancela.TabIndex = 3;
            btnCancela.Text = "Cancela";
            btnCancela.UseVisualStyleBackColor = true;
            btnCancela.Click += btnCancela_Click;
            // 
            // FrmPix
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(596, 816);
            ControlBox = false;
            Controls.Add(btnCancela);
            Controls.Add(txtValor);
            Controls.Add(btnPago);
            Controls.Add(pbPix);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FrmPix";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pbPix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPix;
        private Button btnPago;
        private TextBox txtValor;
        private Button btnCancela;
    }
}
