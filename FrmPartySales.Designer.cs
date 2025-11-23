namespace PartySalesTUCG
{
    partial class FrmPartySales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPartySales));
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editMenu = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            toolsMenu = new ToolStripMenuItem();
            extratoContaToolStripMenuItem = new ToolStripMenuItem();
            geralDeVendasToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            extratoCaixaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu, toolsMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Size = new Size(1184, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, toolStripMenuItem1, toolStripMenuItem2, toolStripSeparator1, toolStripMenuItem3, toolStripMenuItem4, toolStripSeparator3, exitToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(66, 20);
            fileMenu.Text = "&Cadastro";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Black;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "&Festas";
            newToolStripMenuItem.Click += ShowNewForm;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "&Itens de Venda";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(180, 22);
            toolStripMenuItem2.Text = "&Pessoas";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(180, 22);
            toolStripMenuItem3.Text = "&Caixa";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(180, 22);
            toolStripMenuItem4.Text = "Iniciar &Vendas";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolsStripMenuItem_Click;
            // 
            // editMenu
            // 
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(56, 20);
            editMenu.Text = "&Vendas";
            editMenu.Click += editMenu_Click;
            // 
            // viewMenu
            // 
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(51, 20);
            viewMenu.Text = "&Conta";
            viewMenu.Click += viewMenu_Click;
            // 
            // toolsMenu
            // 
            toolsMenu.DropDownItems.AddRange(new ToolStripItem[] { extratoContaToolStripMenuItem, geralDeVendasToolStripMenuItem, extratoCaixaToolStripMenuItem });
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new Size(71, 20);
            toolsMenu.Text = "&Relatorios";
            // 
            // extratoContaToolStripMenuItem
            // 
            extratoContaToolStripMenuItem.Name = "extratoContaToolStripMenuItem";
            extratoContaToolStripMenuItem.Size = new Size(180, 22);
            extratoContaToolStripMenuItem.Text = "Extrato Conta";
            extratoContaToolStripMenuItem.Click += extratoContaToolStripMenuItem_Click_1;
            // 
            // geralDeVendasToolStripMenuItem
            // 
            geralDeVendasToolStripMenuItem.Name = "geralDeVendasToolStripMenuItem";
            geralDeVendasToolStripMenuItem.Size = new Size(180, 22);
            geralDeVendasToolStripMenuItem.Text = "Geral de Vendas";
            geralDeVendasToolStripMenuItem.Click += geralDeVendasToolStripMenuItem_Click;
            // 
            // extratoCaixaToolStripMenuItem
            // 
            extratoCaixaToolStripMenuItem.Name = "extratoCaixaToolStripMenuItem";
            extratoCaixaToolStripMenuItem.Size = new Size(180, 22);
            extratoCaixaToolStripMenuItem.Text = "Extrato Caixa";
            extratoCaixaToolStripMenuItem.Click += extratoCaixaToolStripMenuItem_Click;
            // 
            // FrmPartySales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 711);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmPartySales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PartySales - TUCG - Terreiro Caboclo Guaraci";
            Load += frmPartySales_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem extratoContaToolStripMenuItem;
        private ToolStripMenuItem geralDeVendasToolStripMenuItem;
        private ToolStripMenuItem extratoCaixaToolStripMenuItem;
    }
}



