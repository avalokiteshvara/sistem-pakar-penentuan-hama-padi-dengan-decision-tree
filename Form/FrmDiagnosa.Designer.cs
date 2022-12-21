namespace DeteksiHama.Form
{
    partial class FrmDiagnosa
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
            this.lblPertanyaan = new System.Windows.Forms.Label();
            this.cmbJawaban = new System.Windows.Forms.ComboBox();
            this.lblOption = new System.Windows.Forms.Label();
            this.btnLanjut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPertanyaan
            // 
            this.lblPertanyaan.AutoSize = true;
            this.lblPertanyaan.Location = new System.Drawing.Point(12, 9);
            this.lblPertanyaan.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblPertanyaan.Name = "lblPertanyaan";
            this.lblPertanyaan.Size = new System.Drawing.Size(87, 13);
            this.lblPertanyaan.TabIndex = 0;
            this.lblPertanyaan.Text = "#PERTANYAAN";
            // 
            // cmbJawaban
            // 
            this.cmbJawaban.FormattingEnabled = true;
            this.cmbJawaban.Location = new System.Drawing.Point(79, 258);
            this.cmbJawaban.Name = "cmbJawaban";
            this.cmbJawaban.Size = new System.Drawing.Size(146, 21);
            this.cmbJawaban.TabIndex = 1;
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(9, 261);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(50, 13);
            this.lblOption.TabIndex = 2;
            this.lblOption.Text = "Jawaban";
            // 
            // btnLanjut
            // 
            this.btnLanjut.Location = new System.Drawing.Point(411, 261);
            this.btnLanjut.Name = "btnLanjut";
            this.btnLanjut.Size = new System.Drawing.Size(75, 23);
            this.btnLanjut.TabIndex = 3;
            this.btnLanjut.Text = "Lanjut =>";
            this.btnLanjut.UseVisualStyleBackColor = true;
            this.btnLanjut.Click += new System.EventHandler(this.btnLanjut_Click);
            // 
            // FrmDiagnosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 296);
            this.Controls.Add(this.btnLanjut);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.cmbJawaban);
            this.Controls.Add(this.lblPertanyaan);
            this.Name = "FrmDiagnosa";
            this.Text = "Form Diagnosa";
            this.Load += new System.EventHandler(this.FrmDiagnosa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPertanyaan;
        private System.Windows.Forms.ComboBox cmbJawaban;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Button btnLanjut;
    }
}