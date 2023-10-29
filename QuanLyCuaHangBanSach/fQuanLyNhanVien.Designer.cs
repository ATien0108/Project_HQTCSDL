namespace QuanLyCuaHangBanSach
{
    partial class fQuanLyNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQuanLyNhanVien));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNhanVien = new System.Windows.Forms.ToolStripButton();
            this.tsbPhanLoaiNhanVien = new System.Windows.Forms.ToolStripButton();
            this.tsbLuong = new System.Windows.Forms.ToolStripButton();
            this.pTongQLNV = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNhanVien,
            this.tsbPhanLoaiNhanVien,
            this.tsbLuong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1861, 110);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNhanVien
            // 
            this.tsbNhanVien.AutoSize = false;
            this.tsbNhanVien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("tsbNhanVien.Image")));
            this.tsbNhanVien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNhanVien.Name = "tsbNhanVien";
            this.tsbNhanVien.Size = new System.Drawing.Size(180, 60);
            this.tsbNhanVien.Text = "Nhân Viên";
            this.tsbNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNhanVien.Click += new System.EventHandler(this.tsbNhanVien_Click);
            // 
            // tsbPhanLoaiNhanVien
            // 
            this.tsbPhanLoaiNhanVien.AutoSize = false;
            this.tsbPhanLoaiNhanVien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbPhanLoaiNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("tsbPhanLoaiNhanVien.Image")));
            this.tsbPhanLoaiNhanVien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPhanLoaiNhanVien.Name = "tsbPhanLoaiNhanVien";
            this.tsbPhanLoaiNhanVien.Size = new System.Drawing.Size(180, 60);
            this.tsbPhanLoaiNhanVien.Text = "Phân Loại Nhân Viên";
            this.tsbPhanLoaiNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPhanLoaiNhanVien.Click += new System.EventHandler(this.tsbPhanLoaiNhanVien_Click);
            // 
            // tsbLuong
            // 
            this.tsbLuong.AutoSize = false;
            this.tsbLuong.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbLuong.Image = ((System.Drawing.Image)(resources.GetObject("tsbLuong.Image")));
            this.tsbLuong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLuong.Name = "tsbLuong";
            this.tsbLuong.Size = new System.Drawing.Size(180, 60);
            this.tsbLuong.Text = "Lương";
            this.tsbLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLuong.Click += new System.EventHandler(this.tsbLuong_Click);
            // 
            // pTongQLNV
            // 
            this.pTongQLNV.Location = new System.Drawing.Point(0, 110);
            this.pTongQLNV.Name = "pTongQLNV";
            this.pTongQLNV.Size = new System.Drawing.Size(1861, 818);
            this.pTongQLNV.TabIndex = 6;
            // 
            // fQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1862, 929);
            this.Controls.Add(this.pTongQLNV);
            this.Controls.Add(this.toolStrip1);
            this.Name = "fQuanLyNhanVien";
            this.Text = "fQuanLyNhanVien";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNhanVien;
        private System.Windows.Forms.ToolStripButton tsbPhanLoaiNhanVien;
        private System.Windows.Forms.ToolStripButton tsbLuong;
        private System.Windows.Forms.Panel pTongQLNV;
    }
}