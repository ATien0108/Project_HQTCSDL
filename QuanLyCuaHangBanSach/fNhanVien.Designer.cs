namespace QuanLyCuaHangBanSach
{
    partial class fNhanVien
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
            this.lsvNhanVien = new System.Windows.Forms.ListView();
            this.MaNhanVien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NgaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GioiTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaChucVuNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HoatDong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbHoatDong = new System.Windows.Forms.RadioButton();
            this.rbGioiTinh = new System.Windows.Forms.RadioButton();
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
            this.txtHoatDong = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lbDonGia = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lbMaNCC = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMaPhieuNhap = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lsvNhanVien);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1846, 820);
            this.panel1.TabIndex = 6;
            // 
            // lsvNhanVien
            // 
            this.lsvNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaNhanVien,
            this.HoTen,
            this.NgaySinh,
            this.GioiTinh,
            this.MaChucVuNV,
            this.DiaChi,
            this.SoDienThoai,
            this.HoatDong});
            this.lsvNhanVien.FullRowSelect = true;
            this.lsvNhanVien.HideSelection = false;
            this.lsvNhanVien.Location = new System.Drawing.Point(640, 199);
            this.lsvNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsvNhanVien.Name = "lsvNhanVien";
            this.lsvNhanVien.Size = new System.Drawing.Size(1188, 609);
            this.lsvNhanVien.TabIndex = 28;
            this.lsvNhanVien.UseCompatibleStateImageBehavior = false;
            this.lsvNhanVien.View = System.Windows.Forms.View.Details;
            this.lsvNhanVien.SelectedIndexChanged += new System.EventHandler(this.lsvNhanVien_SelectedIndexChanged);
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Text = "Mã Nhân Viên";
            this.MaNhanVien.Width = 80;
            // 
            // HoTen
            // 
            this.HoTen.Text = "Họ Tên";
            this.HoTen.Width = 150;
            // 
            // NgaySinh
            // 
            this.NgaySinh.Text = "Ngày Sinh";
            this.NgaySinh.Width = 100;
            // 
            // GioiTinh
            // 
            this.GioiTinh.Text = "Giới Tính";
            this.GioiTinh.Width = 80;
            // 
            // MaChucVuNV
            // 
            this.MaChucVuNV.Text = "Mã Chức Vụ";
            this.MaChucVuNV.Width = 100;
            // 
            // DiaChi
            // 
            this.DiaChi.Text = "Địa Chỉ";
            this.DiaChi.Width = 130;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.Text = "Số Điện Thoại";
            this.SoDienThoai.Width = 100;
            // 
            // HoatDong
            // 
            this.HoatDong.Text = "Hoạt Động";
            this.HoatDong.Width = 95;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.rbHoatDong);
            this.panel2.Controls.Add(this.rbGioiTinh);
            this.panel2.Controls.Add(this.rbChucVu);
            this.panel2.Controls.Add(this.cbPhanLoai);
            this.panel2.Controls.Add(this.btnHienThi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(640, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1188, 186);
            this.panel2.TabIndex = 27;
            // 
            // rbHoatDong
            // 
            this.rbHoatDong.AutoSize = true;
            this.rbHoatDong.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHoatDong.Location = new System.Drawing.Point(813, 63);
            this.rbHoatDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbHoatDong.Name = "rbHoatDong";
            this.rbHoatDong.Size = new System.Drawing.Size(196, 30);
            this.rbHoatDong.TabIndex = 22;
            this.rbHoatDong.TabStop = true;
            this.rbHoatDong.Text = "Theo Hoạt Động";
            this.rbHoatDong.UseVisualStyleBackColor = true;
            this.rbHoatDong.CheckedChanged += new System.EventHandler(this.rbHoatDong_CheckedChanged);
            // 
            // rbGioiTinh
            // 
            this.rbGioiTinh.AutoSize = true;
            this.rbGioiTinh.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGioiTinh.Location = new System.Drawing.Point(554, 63);
            this.rbGioiTinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbGioiTinh.Name = "rbGioiTinh";
            this.rbGioiTinh.Size = new System.Drawing.Size(181, 30);
            this.rbGioiTinh.TabIndex = 21;
            this.rbGioiTinh.TabStop = true;
            this.rbGioiTinh.Text = "Theo Giới Tính";
            this.rbGioiTinh.UseVisualStyleBackColor = true;
            this.rbGioiTinh.CheckedChanged += new System.EventHandler(this.rbGioiTinh_CheckedChanged);
            // 
            // rbChucVu
            // 
            this.rbChucVu.AutoSize = true;
            this.rbChucVu.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbChucVu.Location = new System.Drawing.Point(282, 63);
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
            this.cbPhanLoai.Location = new System.Drawing.Point(368, 127);
            this.cbPhanLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPhanLoai.Name = "cbPhanLoai";
            this.cbPhanLoai.Size = new System.Drawing.Size(473, 28);
            this.cbPhanLoai.TabIndex = 17;
            // 
            // btnHienThi
            // 
            this.btnHienThi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHienThi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThi.Location = new System.Drawing.Point(940, 107);
            this.btnHienThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(133, 65);
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
            this.label3.Location = new System.Drawing.Point(547, 6);
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
            this.panel3.Controls.Add(this.txtHoatDong);
            this.panel3.Controls.Add(this.txtSoDienThoai);
            this.panel3.Controls.Add(this.lbDonGia);
            this.panel3.Controls.Add(this.lbSoLuong);
            this.panel3.Controls.Add(this.txtGioiTinh);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtDiaChi);
            this.panel3.Controls.Add(this.lbMaSach);
            this.panel3.Controls.Add(this.txtNgaySinh);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtHoTen);
            this.panel3.Controls.Add(this.lbMaNCC);
            this.panel3.Controls.Add(this.txtMaNhanVien);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbMaPhieuNhap);
            this.panel3.Location = new System.Drawing.Point(13, 6);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(612, 802);
            this.panel3.TabIndex = 26;
            // 
            // txtMaChucVu
            // 
            this.txtMaChucVu.Location = new System.Drawing.Point(271, 387);
            this.txtMaChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaChucVu.Name = "txtMaChucVu";
            this.txtMaChucVu.Size = new System.Drawing.Size(318, 26);
            this.txtMaChucVu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "Mã Chức Vụ:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(390, 714);
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
            this.btnLuu.Location = new System.Drawing.Point(56, 714);
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
            this.btnSua.Location = new System.Drawing.Point(390, 634);
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
            this.btnThem.Location = new System.Drawing.Point(56, 634);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 76);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtHoatDong
            // 
            this.txtHoatDong.Location = new System.Drawing.Point(271, 586);
            this.txtHoatDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoatDong.Name = "txtHoatDong";
            this.txtHoatDong.Size = new System.Drawing.Size(318, 26);
            this.txtHoatDong.TabIndex = 8;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(271, 521);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(318, 26);
            this.txtSoDienThoai.TabIndex = 7;
            // 
            // lbDonGia
            // 
            this.lbDonGia.AutoSize = true;
            this.lbDonGia.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDonGia.Location = new System.Drawing.Point(68, 588);
            this.lbDonGia.Name = "lbDonGia";
            this.lbDonGia.Size = new System.Drawing.Size(123, 24);
            this.lbDonGia.TabIndex = 33;
            this.lbDonGia.Text = "Hoạt Động:";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.Location = new System.Drawing.Point(34, 523);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(157, 24);
            this.lbSoLuong.TabIndex = 32;
            this.lbSoLuong.Text = "Số Điện Thoại:";
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(271, 315);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(318, 26);
            this.txtGioiTinh.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Giới Tính:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(271, 454);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(318, 26);
            this.txtDiaChi.TabIndex = 6;
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(103, 456);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(88, 24);
            this.lbMaSach.TabIndex = 28;
            this.lbMaSach.Text = "Địa Chỉ:";
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(271, 240);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(318, 26);
            this.txtNgaySinh.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ngày Sinh:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(271, 169);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(318, 26);
            this.txtHoTen.TabIndex = 2;
            // 
            // lbMaNCC
            // 
            this.lbMaNCC.AutoSize = true;
            this.lbMaNCC.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaNCC.Location = new System.Drawing.Point(103, 169);
            this.lbMaNCC.Name = "lbMaNCC";
            this.lbMaNCC.Size = new System.Drawing.Size(88, 24);
            this.lbMaNCC.TabIndex = 25;
            this.lbMaNCC.Text = "Họ Tên:";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(271, 97);
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
            this.label2.Location = new System.Drawing.Point(91, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông Tin Nhân Viên";
            // 
            // lbMaPhieuNhap
            // 
            this.lbMaPhieuNhap.AutoSize = true;
            this.lbMaPhieuNhap.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaPhieuNhap.Location = new System.Drawing.Point(38, 97);
            this.lbMaPhieuNhap.Name = "lbMaPhieuNhap";
            this.lbMaPhieuNhap.Size = new System.Drawing.Size(153, 24);
            this.lbMaPhieuNhap.TabIndex = 0;
            this.lbMaPhieuNhap.Text = "Mã Nhân Viên:";
            // 
            // fNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1866, 904);
            this.Controls.Add(this.panel1);
            this.Name = "fNhanVien";
            this.Text = "fQuanLyNhanVien";
            this.Load += new System.EventHandler(this.fNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvNhanVien;
        private System.Windows.Forms.ColumnHeader MaNhanVien;
        private System.Windows.Forms.ColumnHeader HoTen;
        private System.Windows.Forms.ColumnHeader NgaySinh;
        private System.Windows.Forms.ColumnHeader GioiTinh;
        private System.Windows.Forms.ColumnHeader MaChucVuNV;
        private System.Windows.Forms.ColumnHeader DiaChi;
        private System.Windows.Forms.ColumnHeader SoDienThoai;
        private System.Windows.Forms.ColumnHeader HoatDong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbHoatDong;
        private System.Windows.Forms.RadioButton rbGioiTinh;
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
        private System.Windows.Forms.TextBox txtHoatDong;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lbDonGia;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lbMaNCC;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMaPhieuNhap;
    }
}