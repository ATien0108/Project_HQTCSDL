namespace QuanLyCuaHangBanSach
{
    partial class fKhachHang
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
            this.lsvKhachHang = new System.Windows.Forms.ListView();
            this.MaKhachHang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rbMaKhachHang = new System.Windows.Forms.RadioButton();
            this.rbHoTen = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.lbMaKhachHang = new System.Windows.Forms.Label();
            this.lbSoDienThoai = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.lbTenKhachHang = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbCustomerMostBuy = new System.Windows.Forms.RadioButton();
            this.rbCustomerLeastBuy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvDanhGia = new System.Windows.Forms.ListView();
            this.MaKhachHang1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HoVaTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongSoHoaDon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongSoLuongMua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDMSS.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDMSS
            // 
            this.panelDMSS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelDMSS.Controls.Add(this.lsvDanhGia);
            this.panelDMSS.Controls.Add(this.panel3);
            this.panelDMSS.Controls.Add(this.lsvKhachHang);
            this.panelDMSS.Controls.Add(this.panel2);
            this.panelDMSS.Controls.Add(this.panel1);
            this.panelDMSS.Location = new System.Drawing.Point(2, 0);
            this.panelDMSS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDMSS.Name = "panelDMSS";
            this.panelDMSS.Size = new System.Drawing.Size(1846, 823);
            this.panelDMSS.TabIndex = 3;
            // 
            // lsvKhachHang
            // 
            this.lsvKhachHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaKhachHang,
            this.HoTen,
            this.DiaChi,
            this.SoDienThoai});
            this.lsvKhachHang.FullRowSelect = true;
            this.lsvKhachHang.HideSelection = false;
            this.lsvKhachHang.Location = new System.Drawing.Point(631, 11);
            this.lsvKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvKhachHang.Name = "lsvKhachHang";
            this.lsvKhachHang.Size = new System.Drawing.Size(653, 792);
            this.lsvKhachHang.TabIndex = 24;
            this.lsvKhachHang.UseCompatibleStateImageBehavior = false;
            this.lsvKhachHang.View = System.Windows.Forms.View.Details;
            this.lsvKhachHang.SelectedIndexChanged += new System.EventHandler(this.lsvKhachHang_SelectedIndexChanged);
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.Text = "Mã Khách Hàng";
            this.MaKhachHang.Width = 100;
            // 
            // HoTen
            // 
            this.HoTen.Text = "Tên Khách Hàng";
            this.HoTen.Width = 130;
            // 
            // DiaChi
            // 
            this.DiaChi.Text = "Địa chỉ";
            this.DiaChi.Width = 300;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.Text = "Số Điện Thoại";
            this.SoDienThoai.Width = 100;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cbTimKiem);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.rbMaKhachHang);
            this.panel2.Controls.Add(this.rbHoTen);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(10, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 238);
            this.panel2.TabIndex = 21;
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTimKiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTimKiem.DropDownHeight = 60;
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.IntegralHeight = false;
            this.cbTimKiem.Location = new System.Drawing.Point(38, 144);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(349, 28);
            this.cbTimKiem.TabIndex = 17;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnTimKiem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(424, 118);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 76);
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // rbMaKhachHang
            // 
            this.rbMaKhachHang.AutoSize = true;
            this.rbMaKhachHang.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMaKhachHang.Location = new System.Drawing.Point(15, 57);
            this.rbMaKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbMaKhachHang.Name = "rbMaKhachHang";
            this.rbMaKhachHang.Size = new System.Drawing.Size(248, 30);
            this.rbMaKhachHang.TabIndex = 16;
            this.rbMaKhachHang.TabStop = true;
            this.rbMaKhachHang.Text = "Theo Mã Khách Hàng";
            this.rbMaKhachHang.UseVisualStyleBackColor = true;
            this.rbMaKhachHang.CheckedChanged += new System.EventHandler(this.rbMaKhachHang_CheckedChanged);
            // 
            // rbHoTen
            // 
            this.rbHoTen.AutoSize = true;
            this.rbHoTen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHoTen.Location = new System.Drawing.Point(328, 57);
            this.rbHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbHoTen.Name = "rbHoTen";
            this.rbHoTen.Size = new System.Drawing.Size(255, 30);
            this.rbHoTen.TabIndex = 15;
            this.rbHoTen.TabStop = true;
            this.rbHoTen.Text = "Theo Tên Khách Hàng";
            this.rbHoTen.UseVisualStyleBackColor = true;
            this.rbHoTen.CheckedChanged += new System.EventHandler(this.rbHoTen_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(176, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tìm Kiếm Khách Hàng";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.txtSoDienThoai);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.txtMaKhachHang);
            this.panel1.Controls.Add(this.lbMaKhachHang);
            this.panel1.Controls.Add(this.lbSoDienThoai);
            this.panel1.Controls.Add(this.lbDiaChi);
            this.panel1.Controls.Add(this.lbTenKhachHang);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 263);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 540);
            this.panel1.TabIndex = 20;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(224, 343);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(350, 26);
            this.txtSoDienThoai.TabIndex = 21;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(227, 254);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(350, 26);
            this.txtDiaChi.TabIndex = 19;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(223, 170);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(350, 26);
            this.txtHoTen.TabIndex = 17;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(223, 90);
            this.txtMaKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(350, 26);
            this.txtMaKhachHang.TabIndex = 15;
            // 
            // lbMaKhachHang
            // 
            this.lbMaKhachHang.AutoSize = true;
            this.lbMaKhachHang.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaKhachHang.Location = new System.Drawing.Point(34, 90);
            this.lbMaKhachHang.Name = "lbMaKhachHang";
            this.lbMaKhachHang.Size = new System.Drawing.Size(180, 26);
            this.lbMaKhachHang.TabIndex = 14;
            this.lbMaKhachHang.Text = "Mã Khách Hàng:";
            // 
            // lbSoDienThoai
            // 
            this.lbSoDienThoai.AutoSize = true;
            this.lbSoDienThoai.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDienThoai.Location = new System.Drawing.Point(151, 343);
            this.lbSoDienThoai.Name = "lbSoDienThoai";
            this.lbSoDienThoai.Size = new System.Drawing.Size(63, 26);
            this.lbSoDienThoai.TabIndex = 20;
            this.lbSoDienThoai.Text = "SĐT:";
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiaChi.Location = new System.Drawing.Point(125, 254);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(92, 26);
            this.lbDiaChi.TabIndex = 18;
            this.lbDiaChi.Text = "Địa Chỉ:";
            // 
            // lbTenKhachHang
            // 
            this.lbTenKhachHang.AutoSize = true;
            this.lbTenKhachHang.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenKhachHang.Location = new System.Drawing.Point(26, 170);
            this.lbTenKhachHang.Name = "lbTenKhachHang";
            this.lbTenKhachHang.Size = new System.Drawing.Size(191, 26);
            this.lbTenKhachHang.TabIndex = 16;
            this.lbTenKhachHang.Text = "Tên Khách Hàng:";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(156, 427);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(140, 80);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(452, 427);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 80);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSua.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(304, 427);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(140, 80);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(10, 427);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(140, 80);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(153, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông Tin Khách Hàng";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.rbCustomerMostBuy);
            this.panel3.Controls.Add(this.rbCustomerLeastBuy);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1296, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(538, 238);
            this.panel3.TabIndex = 22;
            // 
            // rbCustomerMostBuy
            // 
            this.rbCustomerMostBuy.AutoSize = true;
            this.rbCustomerMostBuy.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomerMostBuy.Location = new System.Drawing.Point(61, 93);
            this.rbCustomerMostBuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCustomerMostBuy.Name = "rbCustomerMostBuy";
            this.rbCustomerMostBuy.Size = new System.Drawing.Size(428, 30);
            this.rbCustomerMostBuy.TabIndex = 16;
            this.rbCustomerMostBuy.TabStop = true;
            this.rbCustomerMostBuy.Text = "Top 20 khách hàng mua sách nhiều nhất";
            this.rbCustomerMostBuy.UseVisualStyleBackColor = true;
            this.rbCustomerMostBuy.CheckedChanged += new System.EventHandler(this.rbCustomerMostBuy_CheckedChanged);
            // 
            // rbCustomerLeastBuy
            // 
            this.rbCustomerLeastBuy.AutoSize = true;
            this.rbCustomerLeastBuy.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomerLeastBuy.Location = new System.Drawing.Point(61, 164);
            this.rbCustomerLeastBuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCustomerLeastBuy.Name = "rbCustomerLeastBuy";
            this.rbCustomerLeastBuy.Size = new System.Drawing.Size(387, 30);
            this.rbCustomerLeastBuy.TabIndex = 15;
            this.rbCustomerLeastBuy.TabStop = true;
            this.rbCustomerLeastBuy.Text = "Top 20 khách hàng mua sách ít nhất";
            this.rbCustomerLeastBuy.UseVisualStyleBackColor = true;
            this.rbCustomerLeastBuy.CheckedChanged += new System.EventHandler(this.rbCustomerLeastBuy_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(134, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 33);
            this.label1.TabIndex = 14;
            this.label1.Text = "Đánh Giá Khách Hàng";
            // 
            // lsvDanhGia
            // 
            this.lsvDanhGia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaKhachHang1,
            this.HoVaTen,
            this.TongSoHoaDon,
            this.TongSoLuongMua});
            this.lsvDanhGia.FullRowSelect = true;
            this.lsvDanhGia.HideSelection = false;
            this.lsvDanhGia.Location = new System.Drawing.Point(1296, 263);
            this.lsvDanhGia.Name = "lsvDanhGia";
            this.lsvDanhGia.Size = new System.Drawing.Size(538, 540);
            this.lsvDanhGia.TabIndex = 25;
            this.lsvDanhGia.UseCompatibleStateImageBehavior = false;
            this.lsvDanhGia.View = System.Windows.Forms.View.Details;
            // 
            // MaKhachHang1
            // 
            this.MaKhachHang1.Text = "Mã Khách Hàng";
            this.MaKhachHang1.Width = 70;
            // 
            // HoVaTen
            // 
            this.HoVaTen.Text = "Họ Và Tên";
            this.HoVaTen.Width = 120;
            // 
            // TongSoHoaDon
            // 
            this.TongSoHoaDon.Text = "Tổng Số Hóa Đơn";
            this.TongSoHoaDon.Width = 80;
            // 
            // TongSoLuongMua
            // 
            this.TongSoLuongMua.Text = "Tổng Số Lượng Mua";
            this.TongSoLuongMua.Width = 80;
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1866, 886);
            this.Controls.Add(this.panelDMSS);
            this.Name = "fKhachHang";
            this.Text = "fDanhMucKhachHang";
            this.Load += new System.EventHandler(this.fKhachHang_Load);
            this.panelDMSS.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDMSS;
        private System.Windows.Forms.ListView lsvKhachHang;
        private System.Windows.Forms.ColumnHeader MaKhachHang;
        private System.Windows.Forms.ColumnHeader HoTen;
        private System.Windows.Forms.ColumnHeader DiaChi;
        private System.Windows.Forms.ColumnHeader SoDienThoai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton rbMaKhachHang;
        private System.Windows.Forms.RadioButton rbHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label lbMaKhachHang;
        private System.Windows.Forms.Label lbSoDienThoai;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbTenKhachHang;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvDanhGia;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbCustomerMostBuy;
        private System.Windows.Forms.RadioButton rbCustomerLeastBuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader MaKhachHang1;
        private System.Windows.Forms.ColumnHeader HoVaTen;
        private System.Windows.Forms.ColumnHeader TongSoHoaDon;
        private System.Windows.Forms.ColumnHeader TongSoLuongMua;
    }
}