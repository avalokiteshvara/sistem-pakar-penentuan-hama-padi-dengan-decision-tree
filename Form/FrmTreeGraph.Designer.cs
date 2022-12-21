namespace DeteksiHama.Form
{
    partial class FrmTreeGraph
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
            this.graphControl1 = new NetronLight.GraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTutup = new System.Windows.Forms.Button();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.graphControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.SuspendLayout();
            // 
            // graphControl1
            // 
            this.graphControl1.Controls.Add(this.picTree);
            this.graphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphControl1.Location = new System.Drawing.Point(0, 0);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.ShowGrid = true;
            this.graphControl1.Size = new System.Drawing.Size(672, 522);
            this.graphControl1.TabIndex = 1;
            this.graphControl1.Text = "graphControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 31);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnTutup
            // 
            this.btnTutup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTutup.Location = new System.Drawing.Point(594, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 1;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // picTree
            // 
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(0, 0);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(672, 522);
            this.picTree.TabIndex = 0;
            this.picTree.TabStop = false;
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.picTree_Paint);
            // 
            // FrmTreeGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.graphControl1);
            this.Name = "FrmTreeGraph";
            this.Text = "Form Tree-Graph";
            this.Load += new System.EventHandler(this.FrmTreeGraph_Load);
            this.graphControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NetronLight.GraphControl graphControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.PictureBox picTree;
    }
}