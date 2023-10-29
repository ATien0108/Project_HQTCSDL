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
    public partial class fQuenMatKhau : Form
    {
        public fQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            //fDangNhap f = new fDangNhap();
            this.Hide();
        }
        private void cbPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassWord.Checked)
            {
                // Hiển thị mật khẩu
                txtForgorPW.UseSystemPasswordChar = false;
                txtConfirmPW.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                txtForgorPW.UseSystemPasswordChar = true;
                txtConfirmPW.UseSystemPasswordChar = true;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local);Initial Catalog=QLCHBS;Integrated Security=True";
            // Lấy dữ liệu từ các textbox
            string tendangnhap = txtForgotUserName.Text.Trim();
            string sdt = txtPhoneNumber.Text.Trim();
            string matKhauMoi = txtForgorPW.Text.Trim();
            string xacNhanMatKhau = txtConfirmPW.Text.Trim();

            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CheckAccount_Phone", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@TenDangNhap", tendangnhap);

                    count = (int)command.ExecuteScalar();
                }
            }

            // Nếu tồn tại, kiểm tra xem MatKhauMoi và XacNhanMatKhau có trùng nhau không
            if (count > 0)
            {
                if (matKhauMoi.Equals(xacNhanMatKhau))
                {
                    //query = "UPDATE DangNhap SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("UpdateAccount", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                            command.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công.");
                                txtForgotUserName.Clear();
                                txtPhoneNumber.Clear();
                                txtForgorPW.Clear();
                                txtConfirmPW.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Đổi mật khẩu thất bại.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không trùng nhau.");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc số điện thoại không đúng.");
            }
        }
    }
}
