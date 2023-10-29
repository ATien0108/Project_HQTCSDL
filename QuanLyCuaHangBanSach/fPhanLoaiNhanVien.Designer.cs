namespace QuanLyCuaHangBanSach
{
    partial class fPhanLoaiNhanVien
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
            this.lsvPhanLoaiNhanVien = new System.Windows.Forms.ListView();
            this.MaChucVu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenChucVu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MoTaCongViec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Luong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbLuong = new System.Windows.Forms.RadioButton();
            this.rbChucVu = new System.Windows.Forms.RadioButton();
            this.cbPhanLoai = new System.Windows.Forms.ComboBox();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMaChucVu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.txtMoTaCongViec = new System.Windows.Forms.TextBox();
            this.lbDonGia = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.txtTenChucVu = new System.Windows.Forms.TextBox();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvDangNhap = new System.Windows.Forms.ListView();
            this.MaNhanVien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenDangNhap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MatKhau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lsvDangNhap);
            this.panel1.Controls.Add(this.lsvPhanLoaiNhanVien);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1854, 805);
            this.panel1.TabIndex = 8;
            // 
            // lsvPhanLoaiNhanVien
            // 
            this.lsvPhanLoaiNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaChucVu,
            this.TenChucVu,
            this.MoTaCongViec,
            this.Luong});
            this.lsvPhanLoaiNhanVien.FullRowSelect = true;
            this.lsvPhanLoaiNhanVien.HideSelection = false;
            this.lsvPhanLoaiNhanVien.Location = new System.Drawing.Point(571, 13);
            this.lsvPhanLoaiNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsvPhanLoaiNhanVien.Name = "lsvPhanLoaiNhanVien";
            this.lsvPhanLoaiNhanVien.Size = new System.Drawing.Size(756, 783);
            this.lsvPhanLoaiNhanVien.TabIndex = 29;
            this.lsvPhanLoaiNhanVien.UseCompatibleStateImageBehavior = false;
            this.lsvPhanLoaiNhanVien.View = System.Windows.Forms.View.Details;
            this.lsvPhanLoaiNhanVien.SelectedIndexChanged += new System.EventHandler(this.lsvPhanLoaiNhanVien_SelectedIndexChanged);
            // 
            // MaChucVu
            // 
            this.MaChucVu.Text = "Mã Chức Vụ";
            this.MaChucVu.Width = 117;
            // 
            // TenChucVu
            // 
            this.TenChucVu.Text = "Tên Chức Vụ";
            this.TenChucVu.Width = 160;
            // 
            // MoTaCongViec
            // 
            this.MoTaCongViec.Text = "Mô Tả Công Việc";
            this.MoTaCongViec.Width = 260;
            // 
            // Luong
            // 
            this.Luong.Text = "Lương";
            this.Luong.Width = 95;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.rbLuong);
            this.panel2.Controls.Add(this.rbChucVu);
            this.panel2.Controls.Add(this.cbPhanLoai);
            this.panel2.Controls.Add(this.btnHienThi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(9, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 242);
            this.panel2.TabIndex = 27;
            // 
            // rbLuong
            // 
            this.rbLuong.AutoSize = true;
            this.rbLuong.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLuong.Location = new System.Drawing.Point(316, 87);
            this.rbLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbLuong.Name = "rbLuong";
            this.rbLuong.Size = new System.Drawing.Size(155, 30);
            this.rbLuong.TabIndex = 22;
            this.rbLuong.TabStop = true;
            this.rbLuong.Text = "Theo Lương";
            this.rbLuong.UseVisualStyleBackColor = true;
            this.rbLuong.CheckedChanged += new System.EventHandler(this.rbLuong_CheckedChanged);
            // 
            // rbChucVu
            // 
            this.rbChucVu.AutoSize = true;
            this.rbChucVu.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbChucVu.Location = new System.Drawing.Point(78, 87);
            this.rbChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbChucVu.Name = "rbChucVu";
            this.rbChucVu.Size = new System.Drawing.Size(178, 30);
            this.rbChucVu.TabIndex = 19;
            this.rbChucVu.TabStop = true;
            this.rbChucVu.Text = "Theo Chức Vụ";
            this.rbChucVu.UseVisualStyleBackColor = true;
            this.rbChucVu.CheckedChanged += new System.EventHandler(this.rbChucVu_CheckedChanged);
            // 
            // cbPhanLoai
            // 
            this.cbPhanLoai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPhanLoai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPhanLoai.DropDownHeight = 60;
            this.cbPhanLoai.FormattingEnabled = true;
            this.cbPhanLoai.IntegralHeight = false;
            this.cbPhanLoai.Location = new System.Drawing.Point(25, 172);
            this.cbPhanLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPhanLoai.Name = "cbPhanLoai";
            this.cbPhanLoai.Size = new System.Drawing.Size(333, 28);
            this.cbPhanLoai.TabIndex = 17;
            // 
            // btnHienThi
            // 
            this.btnHienThi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHienThi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThi.Location = new System.Drawing.Point(388, 144);
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
            this.label3.Location = new System.Drawing.Point(189, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 37);
            this.label3.TabIndex = 14;
            this.label3.Text = "Phân Loại";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.txtMaChucVu);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnHuy);
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Controls.Add(this.txtLuong);
            this.panel3.Controls.Add(this.txtMoTaCongViec);
            this.panel3.Controls.Add(this.lbDonGia);
            this.panel3.Controls.Add(this.lbSoLuong);
            this.panel3.Controls.Add(this.txtTenChucVu);
            this.panel3.Controls.Add(this.lbMaSach);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(9, 262);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 532);
            this.panel3.TabIndex = 26;
            // 
            // txtMaChucVu
            // 
            this.txtMaChucVu.Location = new System.Drawing.Point(178, 106);
            this.txtMaChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaChucVu.Name = "txtMaChucVu";
            this.txtMaChucVu.Size = new System.Drawing.Size(343, 26);
            this.txtMaChucVu.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "Mã Chức Vụ:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(311, 435);
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
            this.btnLuu.Location = new System.Drawing.Point(55, 435);
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
            this.btnSua.Location = new System.Drawing.Point(311, 333);
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
            this.btnThem.Location = new System.Drawing.Point(55, 333);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 76);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(178, 273);
            this.txtLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(343, 26);
            this.txtLuong.TabIndex = 4;
            // 
            // txtMoTaCongViec
            // 
            this.txtMoTaCongViec.Location = new System.Drawing.Point(178, 214);
            this.txtMoTaCongViec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMoTaCongViec.Name = "txtMoTaCongViec";
            this.txtMoTaCongViec.Size = new System.Drawing.Size(343, 26);
            this.txtMoTaCongViec.TabIndex = 3;
            // 
            // lbDonGia
            // 
            this.lbDonGia.AutoSize = true;
            this.lbDonGia.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDonGia.Location = new System.Drawing.Point(74, 273);
            this.lbDonGia.Name = "lbDonGia";
            this.lbDonGia.Size = new System.Drawing.Size(86, 24);
            this.lbDonGia.TabIndex = 33;
            this.lbDonGia.Text = "Lương:";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.Location = new System.Drawing.Point(88, 214);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(72, 24);
            this.lbSoLuong.TabIndex = 32;
            this.lbSoLuong.Text = "Mô tả:";
            // 
            // txtTenChucVu
            // 
            this.txtTenChucVu.Location = new System.Drawing.Point(178, 161);
            this.txtTenChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenChucVu.Name = "txtTenChucVu";
            this.txtTenChucVu.Size = new System.Drawing.Size(343, 26);
            this.txtTenChucVu.TabIndex = 2;
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(12, 161);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(148, 24);
            this.lbMaSach.TabIndex = 28;
            this.lbMaSach.Text = "Tên Chức Vụ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(115, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phân Loại Nhân Viên";
            // 
            // lsvDangNhap
            // 
            this.lsvDangNhap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaNhanVien,
            this.TenDangNhap,
            this.MatKhau});
            this.lsvDangNhap.FullRowSelect = true;
            this.lsvDangNhap.HideSelection = false;
            this.lsvDangNhap.Location = new System.Drawing.Point(1333, 13);
            this.lsvDangNhap.Name = "lsvDangNhap";
            this.lsvDangNhap.Size = new System.Drawing.Size(511, 783);
            this.lsvDangNhap.TabIndex = 30;
            this.lsvDangNhap.UseCompatibleStateImageBehavior = false;
            this.lsvDangNhap.View = System.Windows.Forms.View.Details;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Text = "Mã Nhân Viên";
            this.MaNhanVien.Width = 100;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.Text = "Tên Đăng Nhập";
            this.TenDangNhap.Width = 100;
            // 
            // MatKhau
            // 
            this.MatKhau.Text = "Mật Khẩu";
            this.MatKhau.Width = 100;
            // 
            // fPhanLoaiNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1866, 904);
            this.Controls.Add(this.panel1);
            this.Name = "fPhanLoaiNhanVien";
            this.Text = "fPhanLoaiNhanVien";
            this.Load += new System.EventHandler(this.fPhanLoaiNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvPhanLoaiNhanVien;
        private System.Windows.Forms.ColumnHeader MaChucVu;
        private System.Windows.Forms.ColumnHeader TenChucVu;
        private System.Windows.Forms.ColumnHeader MoTaCongViec;
        private System.Windows.Forms.ColumnHeader Luong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbLuong;
        private System.Windows.Forms.RadioButton rbChucVu;
        private System.Windows.Forms.ComboBox cbPhanLoai;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMaChucVu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.TextBox txtMoTaCongViec;
        private System.Windows.Forms.Label lbDonGia;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.TextBox txtTenChucVu;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvDangNhap;
        private System.Windows.Forms.ColumnHeader MaNhanVien;
        private System.Windows.Forms.ColumnHeader TenDangNhap;
        private System.Windows.Forms.ColumnHeader MatKhau;
    }
}