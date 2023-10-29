namespace QuanLyCuaHangBanSach
{
    partial class fTroGiup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTroGiup));
            this.panelQLDM = new System.Windows.Forms.Panel();
            this.lbDMSS = new System.Windows.Forms.Label();
            this.panelTroGiup = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panelQLDM.SuspendLayout();
            this.panelTroGiup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQLDM
            // 
            this.panelQLDM.Controls.Add(this.lbDMSS);
            this.panelQLDM.Controls.Add(this.panelTroGiup);
            this.panelQLDM.Location = new System.Drawing.Point(6, 4);
            this.panelQLDM.Name = "panelQLDM";
            this.panelQLDM.Size = new System.Drawing.Size(1846, 895);
            this.panelQLDM.TabIndex = 6;
            // 
            // lbDMSS
            // 
            this.lbDMSS.AutoSize = true;
            this.lbDMSS.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbDMSS.Font = new System.Drawing.Font("Palatino Linotype", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDMSS.ForeColor = System.Drawing.Color.Coral;
            this.lbDMSS.Location = new System.Drawing.Point(779, 4);
            this.lbDMSS.Name = "lbDMSS";
            this.lbDMSS.Size = new System.Drawing.Size(227, 55);
            this.lbDMSS.TabIndex = 2;
            this.lbDMSS.Text = "TRỢ GIÚP";
            // 
            // panelTroGiup
            // 
            this.panelTroGiup.BackColor = System.Drawing.SystemColors.Control;
            this.panelTroGiup.Controls.Add(this.label1);
            this.panelTroGiup.Controls.Add(this.richTextBox1);
            this.panelTroGiup.Location = new System.Drawing.Point(3, 62);
            this.panelTroGiup.Name = "panelTroGiup";
            this.panelTroGiup.Size = new System.Drawing.Size(1840, 826);
            this.panelTroGiup.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(741, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thông Tin Liên Lạc";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1809, 354);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // fTroGiup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1859, 904);
            this.Controls.Add(this.panelQLDM);
            this.Name = "fTroGiup";
            this.Text = "fTroGiup";
            this.panelQLDM.ResumeLayout(false);
            this.panelQLDM.PerformLayout();
            this.panelTroGiup.ResumeLayout(false);
            this.panelTroGiup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelQLDM;
        private System.Windows.Forms.Label lbDMSS;
        private System.Windows.Forms.Panel panelTroGiup;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
    }
}