namespace QuanLyCuaHangBanSach
{
    partial class fViTriSach
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
            this.panelDMSS = new System.Windows.Forms.Panel();
            this.lsvDanhGia = new System.Windows.Forms.ListView();
            this.MaSach1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenSach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuongDaBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbWorstSell = new System.Windows.Forms.RadioButton();
            this.rbBestSell = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPhanLoai = new System.Windows.Forms.ComboBox();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvVTS = new System.Windows.Forms.ListView();
            this.MaViTri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaSach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ke = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ngan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNgan = new System.Windows.Forms.TextBox();
            this.lbNgan = new System.Windows.Forms.Label();
            this.btnLuuVTS = new System.Windows.Forms.Button();
            this.btnHuyVTS = new System.Windows.Forms.Button();
            this.btnSuaVTS = new System.Windows.Forms.Button();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.txtKe = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtMaViTri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMaViTri = new System.Windows.Forms.Label();
            this.lbTang = new System.Windows.Forms.Label();
            this.lbKe = new System.Windows.Forms.Label();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDMSS.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDMSS
            // 
            this.panelDMSS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelDMSS.Controls.Add(this.lsvDanhGia);
            this.panelDMSS.Controls.Add(this.panel4);
            this.panelDMSS.Controls.Add(this.panel1);
            this.panelDMSS.Controls.Add(this.lsvVTS);
            this.panelDMSS.Controls.Add(this.panel3);
            this.panelDMSS.Controls.Add(this.panel2);
            this.panelDMSS.Location = new System.Drawing.Point(4, 3);
            this.panelDMSS.Name = "panelDMSS";
            this.panelDMSS.Size = new System.Drawing.Size(1846, 796);
            this.panelDMSS.TabIndex = 3;
            // 
            // lsvDanhGia
            // 
            this.lsvDanhGia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaSach1,
            this.TenSach,
            this.SoLuongDaBan});
            this.lsvDanhGia.HideSelection = false;
            this.lsvDanhGia.Location = new System.Drawing.Point(1196, 251);
            this.lsvDanhGia.Name = "lsvDanhGia";
            this.lsvDanhGia.Size = new System.Drawing.Size(635, 531);
            this.lsvDanhGia.TabIndex = 32;
            this.lsvDanhGia.UseCompatibleStateImageBehavior = false;
            this.lsvDanhGia.View = System.Windows.Forms.View.Details;
            // 
            // MaSach1
            // 
            this.MaSach1.Text = "Mã Sách";
            this.MaSach1.Width = 100;
            // 
            // TenSach
            // 
            this.TenSach.Text = "Tên Sách";
            this.TenSach.Width = 200;
            // 
            // SoLuongDaBan
            // 
            this.SoLuongDaBan.Text = "Số Lượng Đã Bán";
            this.SoLuongDaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoLuongDaBan.Width = 100;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.rbWorstSell);
            this.panel4.Controls.Add(this.rbBestSell);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(1196, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(635, 227);
            this.panel4.TabIndex = 31;
            // 
            // rbWorstSell
            // 
            this.rbWorstSell.AutoSize = true;
            this.rbWorstSell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWorstSell.Location = new System.Drawing.Point(375, 118);
            this.rbWorstSell.Name = "rbWorstSell";
            this.rbWorstSell.Size = new System.Drawing.Size(208, 30);
            this.rbWorstSell.TabIndex = 16;
            this.rbWorstSell.TabStop = true;
            this.rbWorstSell.Text = "Top 10 Worst Sell";
            this.rbWorstSell.UseVisualStyleBackColor = true;
            this.rbWorstSell.CheckedChanged += new System.EventHandler(this.rbWorstSell_CheckedChanged);
            // 
            // rbBestSell
            // 
            this.rbBestSell.AutoSize = true;
            this.rbBestSell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBestSell.Location = new System.Drawing.Point(79, 118);
            this.rbBestSell.Name = "rbBestSell";
            this.rbBestSell.Size = new System.Drawing.Size(195, 30);
            this.rbBestSell.TabIndex = 15;
            this.rbBestSell.TabStop = true;
            this.rbBestSell.Text = "Top 10 Best Sell";
            this.rbBestSell.UseVisualStyleBackColor = true;
            this.rbBestSell.CheckedChanged += new System.EventHandler(this.rbBestSell_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(215, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 37);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đánh Giá Sách";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cbPhanLoai);
            this.panel1.Controls.Add(this.btnHienThi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(591, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 227);
            this.panel1.TabIndex = 28;
            // 
            // cbPhanLoai
            // 
            this.cbPhanLoai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPhanLoai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPhanLoai.DropDownHeight = 60;
            this.cbPhanLoai.FormattingEnabled = true;
            this.cbPhanLoai.IntegralHeight = false;
            this.cbPhanLoai.Location = new System.Drawing.Point(30, 134);
            this.cbPhanLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPhanLoai.Name = "cbPhanLoai";
            this.cbPhanLoai.Size = new System.Drawing.Size(349, 28);
            this.cbPhanLoai.TabIndex = 17;
            // 
            // btnHienThi
            // 
            this.btnHienThi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHienThi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThi.Location = new System.Drawing.Point(418, 108);
            this.btnHienThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(133, 76);
            this.btnHienThi.TabIndex = 14;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = false;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(131, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 33);
            this.label2.TabIndex = 14;
            this.label2.Text = "Phân Loại Vị Trí Sách";
            // 
            // lsvVTS
            // 
            this.lsvVTS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaViTri,
            this.MaSach,
            this.Ke,
            this.Tang,
            this.Ngan});
            this.lsvVTS.FullRowSelect = true;
            this.lsvVTS.HideSelection = false;
            this.lsvVTS.Location = new System.Drawing.Point(591, 251);
            this.lsvVTS.Name = "lsvVTS";
            this.lsvVTS.Size = new System.Drawing.Size(589, 531);
            this.lsvVTS.TabIndex = 30;
            this.lsvVTS.UseCompatibleStateImageBehavior = false;
            this.lsvVTS.View = System.Windows.Forms.View.Details;
            this.lsvVTS.SelectedIndexChanged += new System.EventHandler(this.lsvVTS_SelectedIndexChanged);
            // 
            // MaViTri
            // 
            this.MaViTri.Text = "Mã Vị Trí";
            this.MaViTri.Width = 80;
            // 
            // MaSach
            // 
            this.MaSach.Text = "Mã Sách";
            this.MaSach.Width = 80;
            // 
            // Ke
            // 
            this.Ke.Text = "Kệ";
            // 
            // Tang
            // 
            this.Tang.Text = "Tầng";
            // 
            // Ngan
            // 
            this.Ngan.Text = "Ngăn";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.txtNgan);
            this.panel3.Controls.Add(this.lbNgan);
            this.panel3.Controls.Add(this.btnLuuVTS);
            this.panel3.Controls.Add(this.btnHuyVTS);
            this.panel3.Controls.Add(this.btnSuaVTS);
            this.panel3.Controls.Add(this.txtTang);
            this.panel3.Controls.Add(this.txtKe);
            this.panel3.Controls.Add(this.txtMaSach);
            this.panel3.Controls.Add(this.txtMaViTri);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lbMaViTri);
            this.panel3.Controls.Add(this.lbTang);
            this.panel3.Controls.Add(this.lbKe);
            this.panel3.Controls.Add(this.lbMaSach);
            this.panel3.Location = new System.Drawing.Point(8, 251);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(568, 531);
            this.panel3.TabIndex = 28;
            // 
            // txtNgan
            // 
            this.txtNgan.Location = new System.Drawing.Point(150, 366);
            this.txtNgan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgan.Name = "txtNgan";
            this.txtNgan.Size = new System.Drawing.Size(404, 26);
            this.txtNgan.TabIndex = 16;
            // 
            // lbNgan
            // 
            this.lbNgan.AutoSize = true;
            this.lbNgan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgan.Location = new System.Drawing.Point(52, 364);
            this.lbNgan.Name = "lbNgan";
            this.lbNgan.Size = new System.Drawing.Size(73, 26);
            this.lbNgan.TabIndex = 15;
            this.lbNgan.Text = "Ngăn:";
            // 
            // btnLuuVTS
            // 
            this.btnLuuVTS.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnLuuVTS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuVTS.Location = new System.Drawing.Point(206, 425);
            this.btnLuuVTS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuVTS.Name = "btnLuuVTS";
            this.btnLuuVTS.Size = new System.Drawing.Size(150, 80);
            this.btnLuuVTS.TabIndex = 11;
            this.btnLuuVTS.Text = "Lưu";
            this.btnLuuVTS.UseVisualStyleBackColor = false;
            this.btnLuuVTS.Click += new System.EventHandler(this.btnLuuVTS_Click);
            // 
            // btnHuyVTS
            // 
            this.btnHuyVTS.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuyVTS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyVTS.Location = new System.Drawing.Point(397, 425);
            this.btnHuyVTS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyVTS.Name = "btnHuyVTS";
            this.btnHuyVTS.Size = new System.Drawing.Size(150, 80);
            this.btnHuyVTS.TabIndex = 12;
            this.btnHuyVTS.Text = "Hủy";
            this.btnHuyVTS.UseVisualStyleBackColor = false;
            this.btnHuyVTS.Click += new System.EventHandler(this.btnHuyVTS_Click);
            // 
            // btnSuaVTS
            // 
            this.btnSuaVTS.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSuaVTS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaVTS.Location = new System.Drawing.Point(18, 425);
            this.btnSuaVTS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaVTS.Name = "btnSuaVTS";
            this.btnSuaVTS.Size = new System.Drawing.Size(150, 80);
            this.btnSuaVTS.TabIndex = 9;
            this.btnSuaVTS.Text = "Sửa";
            this.btnSuaVTS.UseVisualStyleBackColor = false;
            this.btnSuaVTS.Click += new System.EventHandler(this.btnSuaVTS_Click);
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(151, 293);
            this.txtTang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTang.Name = "txtTang";
            this.txtTang.Size = new System.Drawing.Size(404, 26);
            this.txtTang.TabIndex = 4;
            // 
            // txtKe
            // 
            this.txtKe.Location = new System.Drawing.Point(151, 222);
            this.txtKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKe.Name = "txtKe";
            this.txtKe.Size = new System.Drawing.Size(404, 26);
            this.txtKe.TabIndex = 3;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(151, 150);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(403, 26);
            this.txtMaSach.TabIndex = 2;
            // 
            // txtMaViTri
            // 
            this.txtMaViTri.Location = new System.Drawing.Point(151, 81);
            this.txtMaViTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaViTri.Name = "txtMaViTri";
            this.txtMaViTri.Size = new System.Drawing.Size(404, 26);
            this.txtMaViTri.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(125, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thông Tin Vị Trí Sách";
            // 
            // lbMaViTri
            // 
            this.lbMaViTri.AutoSize = true;
            this.lbMaViTri.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaViTri.Location = new System.Drawing.Point(17, 79);
            this.lbMaViTri.Name = "lbMaViTri";
            this.lbMaViTri.Size = new System.Drawing.Size(108, 26);
            this.lbMaViTri.TabIndex = 0;
            this.lbMaViTri.Text = "Mã Vị Trí:";
            // 
            // lbTang
            // 
            this.lbTang.AutoSize = true;
            this.lbTang.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTang.Location = new System.Drawing.Point(53, 291);
            this.lbTang.Name = "lbTang";
            this.lbTang.Size = new System.Drawing.Size(72, 26);
            this.lbTang.TabIndex = 3;
            this.lbTang.Text = "Tầng:";
            // 
            // lbKe
            // 
            this.lbKe.AutoSize = true;
            this.lbKe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKe.Location = new System.Drawing.Point(78, 222);
            this.lbKe.Name = "lbKe";
            this.lbKe.Size = new System.Drawing.Size(47, 26);
            this.lbKe.TabIndex = 2;
            this.lbKe.Text = "Kệ:";
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(19, 148);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(106, 26);
            this.lbMaSach.TabIndex = 1;
            this.lbMaSach.Text = "Mã Sách:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cbTimKiem);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(8, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 227);
            this.panel2.TabIndex = 27;
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTimKiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTimKiem.DropDownHeight = 60;
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.IntegralHeight = false;
            this.cbTimKiem.Location = new System.Drawing.Point(30, 134);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(349, 28);
            this.cbTimKiem.TabIndex = 17;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnTimKiem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(400, 108);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(133, 76);
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(131, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tìm Kiếm Vị Trí Sách";
            // 
            // fViTriSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1866, 847);
            this.Controls.Add(this.panelDMSS);
            this.Name = "fViTriSach";
            this.Text = "fViTriSach";
            this.Load += new System.EventHandler(this.fViTriSach_Load);
            this.panelDMSS.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDMSS;
        private System.Windows.Forms.ListView lsvVTS;
        private System.Windows.Forms.ColumnHeader MaViTri;
        private System.Windows.Forms.ColumnHeader MaSach;
        private System.Windows.Forms.ColumnHeader Ke;
        private System.Windows.Forms.ColumnHeader Tang;
        private System.Windows.Forms.ColumnHeader Ngan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNgan;
        private System.Windows.Forms.Label lbNgan;
        private System.Windows.Forms.Button btnLuuVTS;
        private System.Windows.Forms.Button btnHuyVTS;
        private System.Windows.Forms.Button btnSuaVTS;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.TextBox txtKe;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtMaViTri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMaViTri;
        private System.Windows.Forms.Label lbTang;
        private System.Windows.Forms.Label lbKe;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPhanLoai;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbWorstSell;
        private System.Windows.Forms.RadioButton rbBestSell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lsvDanhGia;
        private System.Windows.Forms.ColumnHeader MaSach1;
        private System.Windows.Forms.ColumnHeader TenSach;
        private System.Windows.Forms.ColumnHeader SoLuongDaBan;
    }
}