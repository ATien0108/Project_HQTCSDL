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
    public partial class fQuanLyNhanVien : Form
    {
        string MaTK;
        string MatKhau;
        public fQuanLyNhanVien(string MaTK, string MatKhau)
        {
            InitializeComponent();
            this.MaTK = MaTK;
            this.MatKhau = MatKhau;
        }

        private void tsbNhanVien_Click(object sender, EventArgs e)
        {
            pTongQLNV.Controls.Clear();
            fNhanVien nhanvien = new fNhanVien(MaTK, MatKhau);
            nhanvien.TopLevel = false;
            nhanvien.FormBorderStyle = FormBorderStyle.None;
            pTongQLNV.Controls.Add(nhanvien);
            nhanvien.Show();
        }

        private void tsbPhanLoaiNhanVien_Click(object sender, EventArgs e)
        {
            pTongQLNV.Controls.Clear();
            fPhanLoaiNhanVien plnhanvien = new fPhanLoaiNhanVien(MaTK, MatKhau);
            plnhanvien.TopLevel = false;
            plnhanvien.FormBorderStyle = FormBorderStyle.None;
            pTongQLNV.Controls.Add(plnhanvien);
            plnhanvien.Show();
        }

        private void tsbLuong_Click(object sender, EventArgs e)
        {
            pTongQLNV.Controls.Clear();
            fLuong luong = new fLuong(MaTK, MatKhau);
            luong.TopLevel = false;
            luong.FormBorderStyle = FormBorderStyle.None;
            pTongQLNV.Controls.Add(luong);
            luong.Show();
        }
    }
}
