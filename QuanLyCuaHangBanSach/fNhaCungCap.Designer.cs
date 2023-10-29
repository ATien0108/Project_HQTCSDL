namespace QuanLyCuaHangBanSach
{
    partial class fNhaCungCap
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
            this.lsvNCC = new System.Windows.Forms.ListView();
            this.MaNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiaChiNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoDienThoaiNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbMaNCC = new System.Windows.Forms.RadioButton();
            this.cbTimKiemNCC = new System.Windows.Forms.ComboBox();
            this.rbTenNCC = new System.Windows.Forms.RadioButton();
            this.btnTimKiemNCC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLuuNCC = new System.Windows.Forms.Button();
            this.btnHuyNCC = new System.Windows.Forms.Button();
            this.btnSuaNCC = new System.Windows.Forms.Button();
            this.btnThemNCC = new System.Windows.Forms.Button();
            this.txtSoDienThoaiNCC = new System.Windows.Forms.TextBox();
            this.txtDiaChiNCC = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.lbNXB = new System.Windows.Forms.Label();
            this.lbTacGia = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.panelDMSS.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDMSS
            // 
            this.panelDMSS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelDMSS.Controls.Add(this.lsvNCC);
            this.panelDMSS.Controls.Add(this.panel4);
            this.panelDMSS.Controls.Add(this.panel3);
            this.panelDMSS.Location = new System.Drawing.Point(2, 0);
            this.panelDMSS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDMSS.Name = "panelDMSS";
            this.panelDMSS.Size = new System.Drawing.Size(1846, 823);
            this.panelDMSS.TabIndex = 4;
            // 
            // lsvNCC
            // 
            this.lsvNCC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaNCC,
            this.TenNCC,
            this.DiaChiNCC,
            this.SoDienThoaiNCC});
            this.lsvNCC.FullRowSelect = true;
            this.lsvNCC.HideSelection = false;
            this.lsvNCC.Location = new System.Drawing.Point(693, 11);
            this.lsvNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvNCC.Name = "lsvNCC";
            this.lsvNCC.Size = new System.Drawing.Size(1136, 784);
            this.lsvNCC.TabIndex = 27;
            this.lsvNCC.UseCompatibleStateImageBehavior = false;
            this.lsvNCC.View = System.Windows.Forms.View.Details;
            this.lsvNCC.SelectedIndexChanged += new System.EventHandler(this.lsvNCC_SelectedIndexChanged);
            // 
            // MaNCC
            // 
            this.MaNCC.Text = "Mã Nhà Cung Cấp";
            this.MaNCC.Width = 100;
            // 
            // TenNCC
            // 
            this.TenNCC.Text = "Tên Nhà Cung Cấp";
            this.TenNCC.Width = 160;
            // 
            // DiaChiNCC
            // 
            this.DiaChiNCC.Text = "Địa chỉ";
            this.DiaChiNCC.Width = 320;
            // 
            // SoDienThoaiNCC
            // 
            this.SoDienThoaiNCC.Text = "Số Điện Thoại";
            this.SoDienThoaiNCC.Width = 110;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.rbMaNCC);
            this.panel4.Controls.Add(this.cbTimKiemNCC);
            this.panel4.Controls.Add(this.rbTenNCC);
            this.panel4.Controls.Add(this.btnTimKiemNCC);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(10, 11);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(665, 230);
            this.panel4.TabIndex = 26;
            // 
            // rbMaNCC
            // 
            this.rbMaNCC.AutoSize = true;
            this.rbMaNCC.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMaNCC.Location = new System.Drawing.Point(104, 74);
            this.rbMaNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbMaNCC.Name = "rbMaNCC";
            this.rbMaNCC.Size = new System.Drawing.Size(178, 30);
            this.rbMaNCC.TabIndex = 18;
            this.rbMaNCC.TabStop = true;
            this.rbMaNCC.Text = "Theo Mã MCC";
            this.rbMaNCC.UseVisualStyleBackColor = true;
            this.rbMaNCC.CheckedChanged += new System.EventHandler(this.rbMaNCC_CheckedChanged);
            // 
            // cbTimKiemNCC
            // 
            this.cbTimKiemNCC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTimKiemNCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTimKiemNCC.DropDownHeight = 60;
            this.cbTimKiemNCC.FormattingEnabled = true;
            this.cbTimKiemNCC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbTimKiemNCC.IntegralHeight = false;
            this.cbTimKiemNCC.Location = new System.Drawing.Point(47, 153);
            this.cbTimKiemNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTimKiemNCC.Name = "cbTimKiemNCC";
            this.cbTimKiemNCC.Size = new System.Drawing.Size(388, 28);
            this.cbTimKiemNCC.TabIndex = 17;
            // 
            // rbTenNCC
            // 
            this.rbTenNCC.AutoSize = true;
            this.rbTenNCC.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTenNCC.Location = new System.Drawing.Point(365, 74);
            this.rbTenNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTenNCC.Name = "rbTenNCC";
            this.rbTenNCC.Size = new System.Drawing.Size(183, 30);
            this.rbTenNCC.TabIndex = 18;
            this.rbTenNCC.TabStop = true;
            this.rbTenNCC.Text = "Theo Tên NCC";
            this.rbTenNCC.UseVisualStyleBackColor = true;
            this.rbTenNCC.CheckedChanged += new System.EventHandler(this.rbTenNCC_CheckedChanged);
            // 
            // btnTimKiemNCC
            // 
            this.btnTimKiemNCC.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnTimKiemNCC.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemNCC.Location = new System.Drawing.Point(468, 127);
            this.btnTimKiemNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiemNCC.Name = "btnTimKiemNCC";
            this.btnTimKiemNCC.Size = new System.Drawing.Size(150, 76);
            this.btnTimKiemNCC.TabIndex = 14;
            this.btnTimKiemNCC.Text = "Tìm Kiếm";
            this.btnTimKiemNCC.UseVisualStyleBackColor = false;
            this.btnTimKiemNCC.Click += new System.EventHandler(this.btnTimKiemNCC_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(237, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 29);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tìm Kiếm NCC";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnLuuNCC);
            this.panel3.Controls.Add(this.btnHuyNCC);
            this.panel3.Controls.Add(this.btnSuaNCC);
            this.panel3.Controls.Add(this.btnThemNCC);
            this.panel3.Controls.Add(this.txtSoDienThoaiNCC);
            this.panel3.Controls.Add(this.txtDiaChiNCC);
            this.panel3.Controls.Add(this.txtTenNCC);
            this.panel3.Controls.Add(this.txtMaNCC);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lbMaSach);
            this.panel3.Controls.Add(this.lbNXB);
            this.panel3.Controls.Add(this.lbTacGia);
            this.panel3.Controls.Add(this.lbTenSach);
            this.panel3.Location = new System.Drawing.Point(10, 258);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(665, 537);
            this.panel3.TabIndex = 25;
            // 
            // btnLuuNCC
            // 
            this.btnLuuNCC.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnLuuNCC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuNCC.Location = new System.Drawing.Point(183, 431);
            this.btnLuuNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuNCC.Name = "btnLuuNCC";
            this.btnLuuNCC.Size = new System.Drawing.Size(140, 80);
            this.btnLuuNCC.TabIndex = 11;
            this.btnLuuNCC.Text = "Lưu";
            this.btnLuuNCC.UseVisualStyleBackColor = false;
            this.btnLuuNCC.Click += new System.EventHandler(this.btnLuuNCC_Click);
            // 
            // btnHuyNCC
            // 
            this.btnHuyNCC.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnHuyNCC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyNCC.Location = new System.Drawing.Point(490, 431);
            this.btnHuyNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyNCC.Name = "btnHuyNCC";
            this.btnHuyNCC.Size = new System.Drawing.Size(140, 80);
            this.btnHuyNCC.TabIndex = 12;
            this.btnHuyNCC.Text = "Hủy";
            this.btnHuyNCC.UseVisualStyleBackColor = false;
            this.btnHuyNCC.Click += new System.EventHandler(this.btnHuyNCC_Click);
            // 
            // btnSuaNCC
            // 
            this.btnSuaNCC.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSuaNCC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNCC.Location = new System.Drawing.Point(334, 431);
            this.btnSuaNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaNCC.Name = "btnSuaNCC";
            this.btnSuaNCC.Size = new System.Drawing.Size(140, 80);
            this.btnSuaNCC.TabIndex = 9;
            this.btnSuaNCC.Text = "Sửa";
            this.btnSuaNCC.UseVisualStyleBackColor = false;
            this.btnSuaNCC.Click += new System.EventHandler(this.btnSuaNCC_Click);
            // 
            // btnThemNCC
            // 
            this.btnThemNCC.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThemNCC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNCC.Location = new System.Drawing.Point(28, 431);
            this.btnThemNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.Size = new System.Drawing.Size(140, 80);
            this.btnThemNCC.TabIndex = 8;
            this.btnThemNCC.Text = "Thêm";
            this.btnThemNCC.UseVisualStyleBackColor = false;
            this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click);
            // 
            // txtSoDienThoaiNCC
            // 
            this.txtSoDienThoaiNCC.Location = new System.Drawing.Point(265, 337);
            this.txtSoDienThoaiNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoDienThoaiNCC.Name = "txtSoDienThoaiNCC";
            this.txtSoDienThoaiNCC.Size = new System.Drawing.Size(325, 26);
            this.txtSoDienThoaiNCC.TabIndex = 4;
            // 
            // txtDiaChiNCC
            // 
            this.txtDiaChiNCC.Location = new System.Drawing.Point(265, 251);
            this.txtDiaChiNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChiNCC.Name = "txtDiaChiNCC";
            this.txtDiaChiNCC.Size = new System.Drawing.Size(325, 26);
            this.txtDiaChiNCC.TabIndex = 3;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(262, 168);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(325, 26);
            this.txtTenNCC.TabIndex = 2;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(266, 93);
            this.txtMaNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(325, 26);
            this.txtMaNCC.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(162, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thông Tin Nhà Cung Cấp";
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(53, 91);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(203, 26);
            this.lbMaSach.TabIndex = 0;
            this.lbMaSach.Text = "Mã Nhà Cung Cấp:";
            // 
            // lbNXB
            // 
            this.lbNXB.AutoSize = true;
            this.lbNXB.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNXB.Location = new System.Drawing.Point(192, 337);
            this.lbNXB.Name = "lbNXB";
            this.lbNXB.Size = new System.Drawing.Size(63, 26);
            this.lbNXB.TabIndex = 3;
            this.lbNXB.Text = "SĐT:";
            // 
            // lbTacGia
            // 
            this.lbTacGia.AutoSize = true;
            this.lbTacGia.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTacGia.Location = new System.Drawing.Point(163, 249);
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Size = new System.Drawing.Size(92, 26);
            this.lbTacGia.TabIndex = 2;
            this.lbTacGia.Text = "Địa Chỉ:";
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoSize = true;
            this.lbTenSach.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(42, 168);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(214, 26);
            this.lbTenSach.TabIndex = 1;
            this.lbTenSach.Text = "Tên Nhà Cung Cấp:";
            // 
            // fNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1866, 886);
            this.Controls.Add(this.panelDMSS);
            this.Name = "fNhaCungCap";
            this.Text = "fNhaCungCap";
            this.Load += new System.EventHandler(this.fNhaCungCap_Load);
            this.panelDMSS.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDMSS;
        private System.Windows.Forms.ListView lsvNCC;
        private System.Windows.Forms.ColumnHeader MaNCC;
        private System.Windows.Forms.ColumnHeader TenNCC;
        private System.Windows.Forms.ColumnHeader DiaChiNCC;
        private System.Windows.Forms.ColumnHeader SoDienThoaiNCC;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbMaNCC;
        private System.Windows.Forms.ComboBox cbTimKiemNCC;
        private System.Windows.Forms.RadioButton rbTenNCC;
        private System.Windows.Forms.Button btnTimKiemNCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLuuNCC;
        private System.Windows.Forms.Button btnHuyNCC;
        private System.Windows.Forms.Button btnSuaNCC;
        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.TextBox txtSoDienThoaiNCC;
        private System.Windows.Forms.TextBox txtDiaChiNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Label lbNXB;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label lbTenSach;
    }
}