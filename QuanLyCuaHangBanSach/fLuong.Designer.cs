namespace QuanLyCuaHangBanSach
{
    partial class fLuong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvLuong = new System.Windows.Forms.ListView();
            this.MaNhanVien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoNgayLamViec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbTongLuong = new System.Windows.Forms.RadioButton();
            this.rbSNLV = new System.Windows.Forms.RadioButton();
            this.cbPhanLoai = new System.Windows.Forms.ComboBox();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTongLuong = new System.Windows.Forms.TextBox();
            this.txtThuong = new System.Windows.Forms.TextBox();
            this.lbDonGia = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.txtSNLV = new System.Windows.Forms.TextBox();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMaPhieuNhap = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.lsvDanhGia = new System.Windows.Forms.ListView();
            this.MaNhanVien1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoNgayLamViec1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thuong1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongLuong1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lsvDanhGia);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lsvLuong);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1846, 795);
            this.panel1.TabIndex = 9;
            // 
            // lsvLuong
            // 
            this.lsvLuong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaNhanVien,
            this.SoNgayLamViec,
            this.Thuong,
            this.TongLuong});
            this.lsvLuong.FullRowSelect = true;
            this.lsvLuong.HideSelection = false;
            this.lsvLuong.Location = new System.Drawing.Point(531, 7);
            this.lsvLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsvLuong.Name = "lsvLuong";
            this.lsvLuong.Size = new System.Drawing.Size(692, 773);
            this.lsvLuong.TabIndex = 30;
            this.lsvLuong.UseCompatibleStateImageBehavior = false;
            this.lsvLuong.View = System.Windows.Forms.View.Details;
            this.lsvLuong.SelectedIndexChanged += new System.EventHandler(this.lsvLuong_SelectedIndexChanged);
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Text = "Mã Nhân Viên";
            this.MaNhanVien.Width = 117;
            // 
            // SoNgayLamViec
            // 
            this.SoNgayLamViec.Text = "Số Ngày Làm Việc";
            this.SoNgayLamViec.Width = 130;
            // 
            // Thuong
            // 
            this.Thuong.Text = "Thưởng";
            this.Thuong.Width = 123;
            // 
            // TongLuong
            // 
            this.TongLuong.Text = "Tổng Lương";
            this.TongLuong.Width = 95;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.rbTongLuong);
            this.panel2.Controls.Add(this.rbSNLV);
            this.panel2.Controls.Add(this.cbPhanLoai);
            this.panel2.Controls.Add(this.btnHienThi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(9, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 221);
            this.panel2.TabIndex = 27;
            // 
            // rbTongLuong
            // 
            this.rbTongLuong.AutoSize = true;
            this.rbTongLuong.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTongLuong.Location = new System.Drawing.Point(317, 77);
            this.rbTongLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTongLuong.Name = "rbTongLuong";
            this.rbTongLuong.Size = new System.Drawing.Size(155, 30);
            this.rbTongLuong.TabIndex = 22;
            this.rbTongLuong.TabStop = true;
            this.rbTongLuong.Text = "Tổng Lương";
            this.rbTongLuong.UseVisualStyleBackColor = true;
            this.rbTongLuong.CheckedChanged += new System.EventHandler(this.rbTongLuong_CheckedChanged);
            // 
            // rbSNLV
            // 
            this.rbSNLV.AutoSize = true;
            this.rbSNLV.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSNLV.Location = new System.Drawing.Point(25, 77);
            this.rbSNLV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSNLV.Name = "rbSNLV";
            this.rbSNLV.Size = new System.Drawing.Size(225, 30);
            this.rbSNLV.TabIndex = 19;
            this.rbSNLV.TabStop = true;
            this.rbSNLV.Text = "Theo Số Ngày Làm";
            this.rbSNLV.UseVisualStyleBackColor = true;
            this.rbSNLV.CheckedChanged += new System.EventHandler(this.rbSNLV_CheckedChanged);
            // 
            // cbPhanLoai
            // 
            this.cbPhanLoai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPhanLoai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPhanLoai.DropDownHeight = 60;
            this.cbPhanLoai.FormattingEnabled = true;
            this.cbPhanLoai.IntegralHeight = false;
            this.cbPhanLoai.Location = new System.Drawing.Point(25, 156);
            this.cbPhanLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPhanLoai.Name = "cbPhanLoai";
            this.cbPhanLoai.Size = new System.Drawing.Size(316, 28);
            this.cbPhanLoai.TabIndex = 17;
            // 
            // btnHienThi
            // 
            this.btnHienThi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHienThi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThi.Location = new System.Drawing.Point(362, 128);
            this.btnHienThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(133, 80);
            this.btnHienThi.TabIndex = 14;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = false;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(160, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 37);
            this.label3.TabIndex = 14;
            this.label3.Text = "Phân Loại";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnHuy);
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Controls.Add(this.txtTongLuong);
            this.panel3.Controls.Add(this.txtThuong);
            this.panel3.Controls.Add(this.lbDonGia);
            this.panel3.Controls.Add(this.lbSoLuong);
            this.panel3.Controls.Add(this.txtSNLV);
            this.panel3.Controls.Add(this.lbMaSach);
            this.panel3.Controls.Add(this.txtMaNhanVien);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbMaPhieuNhap);
            this.panel3.Location = new System.Drawing.Point(9, 237);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 543);
            this.panel3.TabIndex = 26;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(317, 450);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(160, 76);
            this.btnHuy.TabIndex = 40;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(46, 450);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 76);
            this.btnLuu.TabIndex = 38;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSua.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(317, 354);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(160, 76);
            this.btnSua.TabIndex = 36;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(46, 354);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 76);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTongLuong
            // 
            this.txtTongLuong.Location = new System.Drawing.Point(177, 297);
            this.txtTongLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongLuong.Name = "txtTongLuong";
            this.txtTongLuong.Size = new System.Drawing.Size(318, 26);
            this.txtTongLuong.TabIndex = 4;
            // 
            // txtThuong
            // 
            this.txtThuong.Location = new System.Drawing.Point(177, 233);
            this.txtThuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThuong.Name = "txtThuong";
            this.txtThuong.Size = new System.Drawing.Size(318, 26);
            this.txtThuong.TabIndex = 3;
            // 
            // lbDonGia
            // 
            this.lbDonGia.AutoSize = true;
            this.lbDonGia.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDonGia.Location = new System.Drawing.Point(21, 297);
            this.lbDonGia.Name = "lbDonGia";
            this.lbDonGia.Size = new System.Drawing.Size(144, 24);
            this.lbDonGia.TabIndex = 33;
            this.lbDonGia.Text = "Tổng Lương:";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.Location = new System.Drawing.Point(66, 233);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(99, 24);
            this.lbSoLuong.TabIndex = 32;
            this.lbSoLuong.Text = "Thưởng:";
            // 
            // txtSNLV
            // 
            this.txtSNLV.Location = new System.Drawing.Point(177, 168);
            this.txtSNLV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSNLV.Name = "txtSNLV";
            this.txtSNLV.Size = new System.Drawing.Size(318, 26);
            this.txtSNLV.TabIndex = 2;
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(15, 168);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(150, 24);
            this.lbMaSach.TabIndex = 28;
            this.lbMaSach.Text = "Số Ngày Làm:";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(177, 103);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(318, 26);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(106, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông Tin Lương";
            // 
            // lbMaPhieuNhap
            // 
            this.lbMaPhieuNhap.AutoSize = true;
            this.lbMaPhieuNhap.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaPhieuNhap.Location = new System.Drawing.Point(12, 105);
            this.lbMaPhieuNhap.Name = "lbMaPhieuNhap";
            this.lbMaPhieuNhap.Size = new System.Drawing.Size(153, 24);
            this.lbMaPhieuNhap.TabIndex = 0;
            this.lbMaPhieuNhap.Text = "Mã Nhân Viên:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.radioButton3);
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(1233, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(601, 300);
            this.panel4.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(242, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Đánh Giá";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(74, 230);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(444, 34);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Top 3 nhân viên có thưởng cao nhất";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(74, 86);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(481, 34);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Những nhân viên không vắng ngày làm";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(74, 156);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(485, 34);
            this.radioButton3.TabIndex = 17;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Top 5 nhân viên có tổng lương cao nhất";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // lsvDanhGia
            // 
            this.lsvDanhGia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaNhanVien1,
            this.SoNgayLamViec1,
            this.Thuong1,
            this.TongLuong1});
            this.lsvDanhGia.HideSelection = false;
            this.lsvDanhGia.Location = new System.Drawing.Point(1233, 312);
            this.lsvDanhGia.Name = "lsvDanhGia";
            this.lsvDanhGia.Size = new System.Drawing.Size(601, 468);
            this.lsvDanhGia.TabIndex = 31;
            this.lsvDanhGia.UseCompatibleStateImageBehavior = false;
            this.lsvDanhGia.View = System.Windows.Forms.View.Details;
            // 
            // MaNhanVien1
            // 
            this.MaNhanVien1.Text = "Mã Nhân Viên";
            this.MaNhanVien1.Width = 80;
            // 
            // SoNgayLamViec1
            // 
            this.SoNgayLamViec1.Text = "Số Ngày Làm Việc";
            this.SoNgayLamViec1.Width = 80;
            // 
            // Thuong1
            // 
            this.Thuong1.Text = "Thưởng";
            this.Thuong1.Width = 90;
            // 
            // TongLuong1
            // 
            this.TongLuong1.Text = "Tổng Lương";
            this.TongLuong1.Width = 100;
            // 
            // fLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1866, 904);
            this.Controls.Add(this.panel1);
            this.Name = "fLuong";
            this.Text = "fLuong";
            this.Load += new System.EventHandler(this.fLuong_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvLuong;
        private System.Windows.Forms.ColumnHeader MaNhanVien;
        private System.Windows.Forms.ColumnHeader SoNgayLamViec;
        private System.Windows.Forms.ColumnHeader Thuong;
        private System.Windows.Forms.ColumnHeader TongLuong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbTongLuong;
        private System.Windows.Forms.RadioButton rbSNLV;
        private System.Windows.Forms.ComboBox cbPhanLoai;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTongLuong;
        private System.Windows.Forms.TextBox txtThuong;
        private System.Windows.Forms.Label lbDonGia;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.TextBox txtSNLV;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMaPhieuNhap;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ListView lsvDanhGia;
        private System.Windows.Forms.ColumnHeader MaNhanVien1;
        private System.Windows.Forms.ColumnHeader SoNgayLamViec1;
        private System.Windows.Forms.ColumnHeader Thuong1;
        private System.Windows.Forms.ColumnHeader TongLuong1;
    }
}