namespace PartySalesTUCG
{
    partial class FrmDinheiro
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
            txtValor = new TextBox();
            btnCancela = new Button();
            btnPago = new Button();
            SuspendLayout();
            // 
            // txtValor
            // 
            txtValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            txtValor.Location = new Point(12, 12);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(330, 39);
            txtValor.TabIndex = 0;
            // 
            // btnCancela
            // 
            btnCancela.Location = new Point(141, 121);
            btnCancela.Name = "btnCancela";
            btnCancela.Size = new Size(75, 23);
            btnCancela.TabIndex = 5;
            btnCancela.Text = "Cancela";
            btnCancela.UseVisualStyleBackColor = true;
            btnCancela.Click += btnCancela_Click;
            // 
            // btnPago
            // 
            btnPago.FlatStyle = FlatStyle.Popup;
            btnPago.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPago.Location = new Point(12, 57);
            btnPago.Name = "btnPago";
            btnPago.Size = new Size(330, 48);
            btnPago.TabIndex = 4;
            btnPago.Text = "Pago!";
            btnPago.UseVisualStyleBackColor = true;
            btnPago.Click += btnPago_Click;
            // 
            // FrmDinheiro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 161);
            ControlBox = false;
            Controls.Add(btnCancela);
            Controls.Add(btnPago);
            Controls.Add(txtValor);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "FrmDinheiro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagamento em Dinheiro!";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtValor;
        private Button btnCancela;
        private Button btnPago;
    }
}