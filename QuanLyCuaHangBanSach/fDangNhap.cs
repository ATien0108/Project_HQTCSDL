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
using static System.Windows.Forms.LinkLabel;

namespace QuanLyCuaHangBanSach
{
    public partial class fDangNhap : Form
    {
        SqlConnection sqlCon = null;
        string username;
        string password;
        public fDangNhap()
        {
            InitializeComponent();
        }
        private void fDangNhap_Load(object sender, EventArgs e)
        {
            //KetNoiVoiCSDL();
        }
        private void KetNoiVoiCSDL()
        {
            username = this.txtUserName.Text;
            password = this.txtPassWord.Text;
            try
            {
                string strCon = $"Data Source=(local);Initial Catalog=QLCHBS;" +
                    $"User ID={username};" +
                    $"Password={password};";

                sqlCon = new SqlConnection(strCon);

                sqlCon.Open();
                fQuanLy f = new fQuanLy(username, password);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoiVoiCSDL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát khỏi chương trình không ?", "Thông báo",
                MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            fQuenMatKhau f = new fQuenMatKhau();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void cbPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassWord.Checked == true)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }
    }
}
