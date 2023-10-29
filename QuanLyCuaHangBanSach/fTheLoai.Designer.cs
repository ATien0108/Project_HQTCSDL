namespace QuanLyCuaHangBanSach
{
    partial class fTheLoai
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvTheLoai = new System.Windows.Forms.ListView();
            this.MaTheLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenTheLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MoTa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTenTheLoai = new System.Windows.Forms.TextBox();
            this.txtMaTheLoai = new System.Windows.Forms.TextBox();
            this.lbMaTheLoai = new System.Windows.Forms.Label();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.lbTenTheLoai = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbHighestNumber = new System.Windows.Forms.RadioButton();
            this.rbLeastNumber = new System.Windows.Forms.RadioButton();
            this.rbBestSell = new System.Windows.Forms.RadioButton();
            this.rbWorstSell = new System.Windows.Forms.RadioButton();
            this.lsvDanhGia = new System.Windows.Forms.ListView();
            this.MaTheLoai1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenTheLoai1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuongBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panelDMSS.Controls.Add(this.panel2);
            this.panelDMSS.Controls.Add(this.lsvTheLoai);
            this.panelDMSS.Controls.Add(this.panel1);
            this.panelDMSS.Location = new System.Drawing.Point(4, 3);
            this.panelDMSS.Name = "panelDMSS";
            this.panelDMSS.Size = new System.Drawing.Size(1846, 797);
            this.panelDMSS.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cbTimKiem);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(11, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 227);
            this.panel2.TabIndex = 30;
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
            this.label3.Location = new System.Drawing.Point(160, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tìm Kiếm Thể Loại";
            // 
            // lsvTheLoai
            // 
            this.lsvTheLoai.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaTheLoai,
            this.TenTheLoai,
            this.MoTa});
            this.lsvTheLoai.FullRowSelect = true;
            this.lsvTheLoai.HideSelection = false;
            this.lsvTheLoai.Location = new System.Drawing.Point(618, 10);
            this.lsvTheLoai.Name = "lsvTheLoai";
            this.lsvTheLoai.Size = new System.Drawing.Size(684, 775);
            this.lsvTheLoai.TabIndex = 29;
            this.lsvTheLoai.UseCompatibleStateImageBehavior = false;
            this.lsvTheLoai.View = System.Windows.Forms.View.Details;
            this.lsvTheLoai.SelectedIndexChanged += new System.EventHandler(this.lsvTheLoai_SelectedIndexChanged);
            // 
            // MaTheLoai
            // 
            this.MaTheLoai.Text = "Mã Thể Loại";
            this.MaTheLoai.Width = 80;
            // 
            // TenTheLoai
            // 
            this.TenTheLoai.Text = "Tên Thể Loại";
            this.TenTheLoai.Width = 120;
            // 
            // MoTa
            // 
            this.MoTa.Text = "Mô Tả";
            this.MoTa.Width = 180;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.txtMoTa);
            this.panel1.Controls.Add(this.txtTenTheLoai);
            this.panel1.Controls.Add(this.txtMaTheLoai);
            this.panel1.Controls.Add(this.lbMaTheLoai);
            this.panel1.Controls.Add(this.lbMoTa);
            this.panel1.Controls.Add(this.lbTenTheLoai);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 257);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 528);
            this.panel1.TabIndex = 26;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(200, 270);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(350, 26);
            this.txtMoTa.TabIndex = 19;
            // 
            // txtTenTheLoai
            // 
            this.txtTenTheLoai.Location = new System.Drawing.Point(199, 183);
            this.txtTenTheLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenTheLoai.Name = "txtTenTheLoai";
            this.txtTenTheLoai.Size = new System.Drawing.Size(350, 26);
            this.txtTenTheLoai.TabIndex = 17;
            // 
            // txtMaTheLoai
            // 
            this.txtMaTheLoai.Location = new System.Drawing.Point(199, 106);
            this.txtMaTheLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaTheLoai.Name = "txtMaTheLoai";
            this.txtMaTheLoai.Size = new System.Drawing.Size(350, 26);
            this.txtMaTheLoai.TabIndex = 15;
            // 
            // lbMaTheLoai
            // 
            this.lbMaTheLoai.AutoSize = true;
            this.lbMaTheLoai.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaTheLoai.Location = new System.Drawing.Point(36, 103);
            this.lbMaTheLoai.Name = "lbMaTheLoai";
            this.lbMaTheLoai.Size = new System.Drawing.Size(143, 26);
            this.lbMaTheLoai.TabIndex = 14;
            this.lbMaTheLoai.Text = "Mã Thể Loại:";
            // 
            // lbMoTa
            // 
            this.lbMoTa.AutoSize = true;
            this.lbMoTa.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoTa.Location = new System.Drawing.Point(97, 270);
            this.lbMoTa.Name = "lbMoTa";
            this.lbMoTa.Size = new System.Drawing.Size(82, 26);
            this.lbMoTa.TabIndex = 18;
            this.lbMoTa.Text = "Mô Tả:";
            // 
            // lbTenTheLoai
            // 
            this.lbTenTheLoai.AutoSize = true;
            this.lbTenTheLoai.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenTheLoai.Location = new System.Drawing.Point(25, 181);
            this.lbTenTheLoai.Name = "lbTenTheLoai";
            this.lbTenTheLoai.Size = new System.Drawing.Size(154, 26);
            this.lbTenTheLoai.TabIndex = 16;
            this.lbTenTheLoai.Text = "Tên Thể Loại:";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(346, 332);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 80);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.TabStop = false;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(346, 428);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 80);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.TabStop = false;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSua.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(102, 428);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 80);
            this.btnSua.TabIndex = 9;
            this.btnSua.TabStop = false;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(102, 332);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 80);
            this.btnThem.TabIndex = 8;
            this.btnThem.TabStop = false;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(150, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông Tin Thể Loại";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.rbWorstSell);
            this.panel3.Controls.Add(this.rbBestSell);
            this.panel3.Controls.Add(this.rbLeastNumber);
            this.panel3.Controls.Add(this.rbHighestNumber);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1312, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(523, 337);
            this.panel3.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(144, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Đánh giá thể loại";
            // 
            // rbHighestNumber
            // 
            this.rbHighestNumber.AutoSize = true;
            this.rbHighestNumber.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHighestNumber.Location = new System.Drawing.Point(63, 85);
            this.rbHighestNumber.Name = "rbHighestNumber";
            this.rbHighestNumber.Size = new System.Drawing.Size(416, 30);
            this.rbHighestNumber.TabIndex = 15;
            this.rbHighestNumber.TabStop = true;
            this.rbHighestNumber.Text = "Top 5 thể loại có lượng sách nhiều nhất";
            this.rbHighestNumber.UseVisualStyleBackColor = true;
            this.rbHighestNumber.CheckedChanged += new System.EventHandler(this.rbHighestNumber_CheckedChanged);
            // 
            // rbLeastNumber
            // 
            this.rbLeastNumber.AutoSize = true;
            this.rbLeastNumber.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLeastNumber.Location = new System.Drawing.Point(63, 144);
            this.rbLeastNumber.Name = "rbLeastNumber";
            this.rbLeastNumber.Size = new System.Drawing.Size(375, 30);
            this.rbLeastNumber.TabIndex = 16;
            this.rbLeastNumber.TabStop = true;
            this.rbLeastNumber.Text = "Top 5 thể loại có lượng sách ít nhất";
            this.rbLeastNumber.UseVisualStyleBackColor = true;
            this.rbLeastNumber.CheckedChanged += new System.EventHandler(this.rbLeastNumber_CheckedChanged);
            // 
            // rbBestSell
            // 
            this.rbBestSell.AutoSize = true;
            this.rbBestSell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBestSell.Location = new System.Drawing.Point(63, 208);
            this.rbBestSell.Name = "rbBestSell";
            this.rbBestSell.Size = new System.Drawing.Size(381, 30);
            this.rbBestSell.TabIndex = 17;
            this.rbBestSell.TabStop = true;
            this.rbBestSell.Text = "Top 5 thể loại có lượng sách bán tốt";
            this.rbBestSell.UseVisualStyleBackColor = true;
            this.rbBestSell.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbWorstSell
            // 
            this.rbWorstSell.AutoSize = true;
            this.rbWorstSell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWorstSell.Location = new System.Drawing.Point(63, 276);
            this.rbWorstSell.Name = "rbWorstSell";
            this.rbWorstSell.Size = new System.Drawing.Size(375, 30);
            this.rbWorstSell.TabIndex = 18;
            this.rbWorstSell.TabStop = true;
            this.rbWorstSell.Text = "Top 5 thể loại có lượng sách bán tệ";
            this.rbWorstSell.UseVisualStyleBackColor = true;
            this.rbWorstSell.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // lsvDanhGia
            // 
            this.lsvDanhGia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaTheLoai1,
            this.TenTheLoai1,
            this.SoLuong,
            this.SoLuongBan});
            this.lsvDanhGia.FullRowSelect = true;
            this.lsvDanhGia.HideSelection = false;
            this.lsvDanhGia.Location = new System.Drawing.Point(1312, 360);
            this.lsvDanhGia.Name = "lsvDanhGia";
            this.lsvDanhGia.Size = new System.Drawing.Size(523, 425);
            this.lsvDanhGia.TabIndex = 32;
            this.lsvDanhGia.UseCompatibleStateImageBehavior = false;
            this.lsvDanhGia.View = System.Windows.Forms.View.Details;
            // 
            // MaTheLoai1
            // 
            this.MaTheLoai1.Text = "Mã Thể Loại";
            this.MaTheLoai1.Width = 70;
            // 
            // TenTheLoai1
            // 
            this.TenTheLoai1.Text = "Tên Thể Loại";
            this.TenTheLoai1.Width = 110;
            // 
            // SoLuong
            // 
            this.SoLuong.Text = "Số Lượng Kệ Và Kho";
            this.SoLuong.Width = 80;
            // 
            // SoLuongBan
            // 
            this.SoLuongBan.Text = "Tổng Số Lượng Bán";
            this.SoLuongBan.Width = 80;
            // 
            // fTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1866, 847);
            this.Controls.Add(this.panelDMSS);
            this.Name = "fTheLoai";
            this.Text = "fTheLoaiVTSach";
            this.Load += new System.EventHandler(this.fTheLoaiVTSach_Load);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTenTheLoai;
        private System.Windows.Forms.TextBox txtMaTheLoai;
        private System.Windows.Forms.Label lbMaTheLoai;
        private System.Windows.Forms.Label lbMoTa;
        private System.Windows.Forms.Label lbTenTheLoai;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvTheLoai;
        private System.Windows.Forms.ColumnHeader MaTheLoai;
        private System.Windows.Forms.ColumnHeader TenTheLoai;
        private System.Windows.Forms.ColumnHeader MoTa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lsvDanhGia;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbWorstSell;
        private System.Windows.Forms.RadioButton rbBestSell;
        private System.Windows.Forms.RadioButton rbLeastNumber;
        private System.Windows.Forms.RadioButton rbHighestNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader MaTheLoai1;
        private System.Windows.Forms.ColumnHeader TenTheLoai1;
        private System.Windows.Forms.ColumnHeader SoLuong;
        private System.Windows.Forms.ColumnHeader SoLuongBan;
    }
}