using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanSach
{
    public partial class fQuanLy : Form
    {
        string MaTK;
        string MatKhau;
        public fQuanLy(string MaTK, string MatKhau)
        {
            InitializeComponent();
            this.MaTK = MaTK;
            this.MatKhau = MatKhau;
        }

        private void tsbTrangChu_Click(object sender, EventArgs e)
        {
            pTongQL.Controls.Clear();
            pTongQL.Controls.Add(lbTong);
            pTongQL.Controls.Add(pbTong);
        }

        private void tsbQuanLyChung_Click(object sender, EventArgs e)
        {
            pTongQL.Controls.Clear();
            fQuanLyChung qlc = new fQuanLyChung(MaTK, MatKhau);
            qlc.TopLevel = false;
            qlc.FormBorderStyle = FormBorderStyle.None;
            pTongQL.Controls.Add(qlc);
            qlc.Show();
        }

        private void tsbNhanVien_Click(object sender, EventArgs e)
        {
            pTongQL.Controls.Clear();
            fQuanLyNhanVien qlnv = new fQuanLyNhanVien(MaTK, MatKhau);
            qlnv.TopLevel = false;
            qlnv.FormBorderStyle = FormBorderStyle.None;
            pTongQL.Controls.Add(qlnv);
            qlnv.Show();
        }

        private void tsbThongKe_Click(object sender, EventArgs e)
        {
            pTongQL.Controls.Clear();
            fBaoCaoThongKe bctk = new fBaoCaoThongKe(MaTK, MatKhau);
            bctk.TopLevel = false;
            bctk.FormBorderStyle = FormBorderStyle.None;
            pTongQL.Controls.Add(bctk);
            bctk.Show();
        }

        private void tsbThongTin_Click(object sender, EventArgs e)
        {
            pTongQL.Controls.Clear();
            fThongTin tt = new fThongTin(MaTK, MatKhau);
            tt.TopLevel = false;
            tt.FormBorderStyle = FormBorderStyle.None;
            pTongQL.Controls.Add(tt);
            tt.Show();
        }

        private void tsbTroGiup_Click(object sender, EventArgs e)
        {
            pTongQL.Controls.Clear();
            fTroGiup tg = new fTroGiup();
            tg.TopLevel = false;
            tg.FormBorderStyle = FormBorderStyle.None;
            pTongQL.Controls.Add(tg);
            tg.Show();
        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void tsbDangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị message box để xác nhận việc đăng xuất
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn đăng xuất không ?", "Xác nhận đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra kết quả trả về từ message box
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
