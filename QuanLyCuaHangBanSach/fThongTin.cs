using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangBanSach
{
    public partial class fThongTin : Form
    {
        string taikhoan;
        string matkhau;
        SqlConnection conn = null;
        string connectionString;
        public fThongTin(string taikhoan, string matkhau)
        {
            connectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
            this.taikhoan = taikhoan ;
            this.matkhau = matkhau ;
        }

        private void fThongTin_Load(object sender, EventArgs e)
        {
            hienThiThongTin();
        }

        private void hienThiThongTin()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ShowStaffInformation", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenDangNhap", taikhoan);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy dữ liệu từ SqlDataReader
                        string maNhanVien = reader.GetString(0);
                        string hoTen = reader.GetString(1);
                        DateTime ngaySinh = reader.GetDateTime(2);
                        string gioiTinh = reader.GetString(3);
                        string maChucVu = reader.GetString(4);
                        string diaChi = reader.GetString(5);
                        string soDienThoai = reader.GetString(6);
                        string hoatdong = reader.GetString(7);
                        string taikhoan = reader.GetString(9);
                        string matkhau = reader.GetString(10);
                        // Hiển thị thông tin nhân viên trong textbox
                        txtMaNhanVien.Text = maNhanVien;
                        txtHoTen.Text = hoTen;
                        txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                        txtGioiTinh.Text = gioiTinh;
                        txtMaChucVu.Text = maChucVu;
                        txtDiaChi.Text = diaChi;
                        txtSoDienThoai.Text = soDienThoai;
                        txtHoatDong.Text = hoatdong;
                        txtUserName.Text = taikhoan;
                        txtPassword.Text = matkhau;
                    }
                    reader.Close();
                }
            }
        }

        private void cbPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassWord.Checked)
            {
                // Hiển thị mật khẩu
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaNhanVien.ReadOnly = true;
                txtHoTen.ReadOnly = false;
                txtNgaySinh.ReadOnly = false;
                txtGioiTinh.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtMaChucVu.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;
                txtHoatDong.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(connectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateEmployee";
                command.Connection = conn;

                command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txtHoTen.Text;
                command.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = txtNgaySinh.Text;
                command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = txtGioiTinh.Text;
                command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                command.Parameters.Add("@HoatDong", SqlDbType.NVarChar).Value = txtHoatDong.Text;

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Sửa Thành Công");
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                fThongTin_Load(this, EventArgs.Empty);

                txtMaNhanVien.ReadOnly = true;
                txtHoTen.ReadOnly = true;
                txtNgaySinh.ReadOnly = true;
                txtGioiTinh.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtMaChucVu.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;
                txtHoatDong.ReadOnly = true;
            }
        }
    }
}
