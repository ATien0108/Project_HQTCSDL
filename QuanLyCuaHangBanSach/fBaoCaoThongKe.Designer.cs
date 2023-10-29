namespace QuanLyCuaHangBanSach
{
    partial class fBaoCaoThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelDMSS = new System.Windows.Forms.Panel();
            this.pPhieuNhap = new System.Windows.Forms.Panel();
            this.chartPhieuNhap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvPhieuNhap = new System.Windows.Forms.ListView();
            this.NgayNhap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuongNhap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongTienNhap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pDoanhThu = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvDoanhThu = new System.Windows.Forms.ListView();
            this.Ngay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuongSachBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDMSS.SuspendLayout();
            this.pPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhieuNhap)).BeginInit();
            this.pDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDMSS
            // 
            this.panelDMSS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelDMSS.Controls.Add(this.pPhieuNhap);
            this.panelDMSS.Controls.Add(this.pDoanhThu);
            this.panelDMSS.Location = new System.Drawing.Point(5, 7);
            this.panelDMSS.Name = "panelDMSS";
            this.panelDMSS.Size = new System.Drawing.Size(1846, 902);
            this.panelDMSS.TabIndex = 3;
            // 
            // pPhieuNhap
            // 
            this.pPhieuNhap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pPhieuNhap.Controls.Add(this.chartPhieuNhap);
            this.pPhieuNhap.Controls.Add(this.label2);
            this.pPhieuNhap.Controls.Add(this.lsvPhieuNhap);
            this.pPhieuNhap.Location = new System.Drawing.Point(930, 5);
            this.pPhieuNhap.Name = "pPhieuNhap";
            this.pPhieuNhap.Size = new System.Drawing.Size(915, 890);
            this.pPhieuNhap.TabIndex = 2;
            // 
            // chartPhieuNhap
            // 
            chartArea3.Name = "ChartArea1";
            this.chartPhieuNhap.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPhieuNhap.Legends.Add(legend3);
            this.chartPhieuNhap.Location = new System.Drawing.Point(13, 401);
            this.chartPhieuNhap.Name = "chartPhieuNhap";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartPhieuNhap.Series.Add(series3);
            this.chartPhieuNhap.Size = new System.Drawing.Size(888, 476);
            this.chartPhieuNhap.TabIndex = 4;
            this.chartPhieuNhap.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(295, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thống Kê Phiếu Nhập";
            // 
            // lsvPhieuNhap
            // 
            this.lsvPhieuNhap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NgayNhap,
            this.SoLuongNhap,
            this.TongTienNhap});
            this.lsvPhieuNhap.FullRowSelect = true;
            this.lsvPhieuNhap.HideSelection = false;
            this.lsvPhieuNhap.Location = new System.Drawing.Point(13, 63);
            this.lsvPhieuNhap.Name = "lsvPhieuNhap";
            this.lsvPhieuNhap.Size = new System.Drawing.Size(888, 321);
            this.lsvPhieuNhap.TabIndex = 1;
            this.lsvPhieuNhap.UseCompatibleStateImageBehavior = false;
            this.lsvPhieuNhap.View = System.Windows.Forms.View.Details;
            // 
            // NgayNhap
            // 
            this.NgayNhap.Text = "Ngày Nhập";
            this.NgayNhap.Width = 150;
            // 
            // SoLuongNhap
            // 
            this.SoLuongNhap.Text = "Số Lượng Sách Nhập";
            this.SoLuongNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoLuongNhap.Width = 150;
            // 
            // TongTienNhap
            // 
            this.TongTienNhap.Text = "Tổng Tiền Nhập";
            this.TongTienNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TongTienNhap.Width = 160;
            // 
            // pDoanhThu
            // 
            this.pDoanhThu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pDoanhThu.Controls.Add(this.chartDoanhThu);
            this.pDoanhThu.Controls.Add(this.label1);
            this.pDoanhThu.Controls.Add(this.lsvDoanhThu);
            this.pDoanhThu.Location = new System.Drawing.Point(7, 5);
            this.pDoanhThu.Name = "pDoanhThu";
            this.pDoanhThu.Size = new System.Drawing.Size(915, 890);
            this.pDoanhThu.TabIndex = 1;
            // 
            // chartDoanhThu
            // 
            chartArea4.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend4);
            this.chartDoanhThu.Location = new System.Drawing.Point(11, 401);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartDoanhThu.Series.Add(series4);
            this.chartDoanhThu.Size = new System.Drawing.Size(888, 476);
            this.chartDoanhThu.TabIndex = 3;
            this.chartDoanhThu.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(271, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống Kê Doanh Thu";
            // 
            // lsvDoanhThu
            // 
            this.lsvDoanhThu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ngay,
            this.SoLuongSachBan,
            this.TongTien});
            this.lsvDoanhThu.FullRowSelect = true;
            this.lsvDoanhThu.HideSelection = false;
            this.lsvDoanhThu.Location = new System.Drawing.Point(11, 63);
            this.lsvDoanhThu.Name = "lsvDoanhThu";
            this.lsvDoanhThu.Size = new System.Drawing.Size(888, 321);
            this.lsvDoanhThu.TabIndex = 1;
            this.lsvDoanhThu.UseCompatibleStateImageBehavior = false;
            this.lsvDoanhThu.View = System.Windows.Forms.View.Details;
            // 
            // Ngay
            // 
            this.Ngay.Text = "Ngày";
            this.Ngay.Width = 150;
            // 
            // SoLuongSachBan
            // 
            this.SoLuongSachBan.Text = "Số Lượng Sách Bán";
            this.SoLuongSachBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoLuongSachBan.Width = 150;
            // 
            // TongTien
            // 
            this.TongTien.Text = "Tổng Doanh Thu";
            this.TongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TongTien.Width = 160;
            // 
            // fBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1866, 914);
            this.Controls.Add(this.panelDMSS);
            this.Name = "fBaoCaoThongKe";
            this.Text = "fBaoCaoThongKe";
            this.Load += new System.EventHandler(this.fBaoCaoThongKe_Load);
            this.panelDMSS.ResumeLayout(false);
            this.pPhieuNhap.ResumeLayout(false);
            this.pPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhieuNhap)).EndInit();
            this.pDoanhThu.ResumeLayout(false);
            this.pDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDMSS;
        private System.Windows.Forms.Panel pPhieuNhap;
        private System.Windows.Forms.ListView lsvPhieuNhap;
        private System.Windows.Forms.Panel pDoanhThu;
        private System.Windows.Forms.ListView lsvDoanhThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Ngay;
        private System.Windows.Forms.ColumnHeader SoLuongSachBan;
        private System.Windows.Forms.ColumnHeader TongTien;
        private System.Windows.Forms.ColumnHeader NgayNhap;
        private System.Windows.Forms.ColumnHeader SoLuongNhap;
        private System.Windows.Forms.ColumnHeader TongTienNhap;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhieuNhap;
    }
}