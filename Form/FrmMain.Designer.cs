namespace DeteksiHama.Form
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tentangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pertanyaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solusiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ruleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikasiToolStripMenuItem,
            this.formToolStripMenuItem,
            this.diagnosaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(633, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // aplikasiToolStripMenuItem
            // 
            this.aplikasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tentangToolStripMenuItem,
            this.keluarToolStripMenuItem});
            this.aplikasiToolStripMenuItem.Name = "aplikasiToolStripMenuItem";
            this.aplikasiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.aplikasiToolStripMenuItem.Text = "Aplikasi";
            // 
            // tentangToolStripMenuItem
            // 
            this.tentangToolStripMenuItem.Name = "tentangToolStripMenuItem";
            this.tentangToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tentangToolStripMenuItem.Text = "Tentang";
            this.tentangToolStripMenuItem.Click += new System.EventHandler(this.tentangToolStripMenuItem_Click);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keluarToolStripMenuItem.Text = "Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pertanyaanToolStripMenuItem,
            this.solusiToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ruleToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // pertanyaanToolStripMenuItem
            // 
            this.pertanyaanToolStripMenuItem.Name = "pertanyaanToolStripMenuItem";
            this.pertanyaanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pertanyaanToolStripMenuItem.Text = "Pertanyaan";
            this.pertanyaanToolStripMenuItem.Click += new System.EventHandler(this.pertanyaanToolStripMenuItem_Click);
            // 
            // solusiToolStripMenuItem
            // 
            this.solusiToolStripMenuItem.Name = "solusiToolStripMenuItem";
            this.solusiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.solusiToolStripMenuItem.Text = "Solusi";
            this.solusiToolStripMenuItem.Click += new System.EventHandler(this.solusiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // ruleToolStripMenuItem
            // 
            this.ruleToolStripMenuItem.Name = "ruleToolStripMenuItem";
            this.ruleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ruleToolStripMenuItem.Text = "Rule";
            this.ruleToolStripMenuItem.Click += new System.EventHandler(this.ruleToolStripMenuItem_Click);
            // 
            // diagnosaToolStripMenuItem
            // 
            this.diagnosaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diagnosaToolStripMenuItem1,
            this.treeGraphToolStripMenuItem});
            this.diagnosaToolStripMenuItem.Name = "diagnosaToolStripMenuItem";
            this.diagnosaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.diagnosaToolStripMenuItem.Text = "Proses";
            this.diagnosaToolStripMenuItem.Click += new System.EventHandler(this.diagnosaToolStripMenuItem_Click);
            // 
            // diagnosaToolStripMenuItem1
            // 
            this.diagnosaToolStripMenuItem1.Name = "diagnosaToolStripMenuItem1";
            this.diagnosaToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.diagnosaToolStripMenuItem1.Text = "Diagnosa";
            this.diagnosaToolStripMenuItem1.Click += new System.EventHandler(this.diagnosaToolStripMenuItem1_Click);
            // 
            // treeGraphToolStripMenuItem
            // 
            this.treeGraphToolStripMenuItem.Name = "treeGraphToolStripMenuItem";
            this.treeGraphToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.treeGraphToolStripMenuItem.Text = "Tree Graph";
            this.treeGraphToolStripMenuItem.Click += new System.EventHandler(this.treeGraphToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 504);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aplikasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tentangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pertanyaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solusiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ruleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagnosaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagnosaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem treeGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
    }
}