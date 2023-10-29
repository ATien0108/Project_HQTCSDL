using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanSach
{
    public partial class fQuanLyChung : Form
    {
        string MaTK;
        string MatKhau;
        public fQuanLyChung(string MaTK, string MatKhau)
        {
            InitializeComponent();
            this.MaTK = MaTK;
            this.MatKhau = MatKhau;
        }

        private void tsbSach_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fSach sach = new fSach(MaTK, MatKhau);
            sach.TopLevel = false;
            sach.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(sach);
            sach.Show();
        }

        private void tsbTheLoai_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fTheLoai theloai = new fTheLoai(MaTK, MatKhau);
            theloai.TopLevel = false;
            theloai.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(theloai);
            theloai.Show();
        }

        private void tsbKhoSach_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fKhoSach khosach = new fKhoSach(MaTK, MatKhau);
            khosach.TopLevel = false;
            khosach.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(khosach);
            khosach.Show();
        }

        private void tsbKhachHang_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fKhachHang khachhang = new fKhachHang(MaTK, MatKhau);
            khachhang.TopLevel = false;
            khachhang.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(khachhang);
            khachhang.Show();
        }

        private void tsbNCC_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fNhaCungCap NCC = new fNhaCungCap(MaTK, MatKhau);
            NCC.TopLevel = false;
            NCC.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(NCC);
            NCC.Show();
        }

        private void tsbHoaDon_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fHoaDon hoadon = new fHoaDon(MaTK, MatKhau);
            hoadon.TopLevel = false;
            hoadon.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(hoadon);
            hoadon.Show();
        }

        private void tsbPhieuNhap_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fPhieuNhap phieunhap = new fPhieuNhap(MaTK, MatKhau);
            phieunhap.TopLevel = false;
            phieunhap.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(phieunhap);
            phieunhap.Show();
        }

        private void tsbViTriSach_Click(object sender, EventArgs e)
        {
            pTongQLC.Controls.Clear();
            fViTriSach vitrisach = new fViTriSach(MaTK, MatKhau);
            vitrisach.TopLevel = false;
            vitrisach.FormBorderStyle = FormBorderStyle.None;
            pTongQLC.Controls.Add(vitrisach);
            vitrisach.Show();
        }
    }
}
