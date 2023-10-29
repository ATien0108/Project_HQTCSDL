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
    public partial class fKhoSach : Form
    {
        SqlConnection conn = null;
        string strConnectionString;
        public fKhoSach(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fKhoSach_Load(object sender, EventArgs e)
        {
            HienThiToanBoKhoSach();
            loadCbTimKiem();
        }
        private void HienThiToanBoKhoSach()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_Inventory";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvKhoSach.Items.Clear();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string TenSach = reader.GetString(1);
                    int SoLuongKho = reader.GetInt32(2);

                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(TenSach);
                    lvi.SubItems.Add(SoLuongKho.ToString());

                    lsvKhoSach.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void lsvKhoSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKhoSach.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvKhoSach.SelectedItems[0];
            string MaSach = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoKhoSach(MaSach);
        }


        private void HienThiChiTietToanBoKhoSach(string MaSach)
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowInventoryDetails";
                command.Connection = conn;

                SqlParameter parMaSach = new SqlParameter("@MaSach", SqlDbType.NVarChar);
                parMaSach.Value = MaSach;
                command.Parameters.Add(parMaSach);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaSach.Text = reader.GetString(0) + "";
                    txtTenSach.Text = reader.GetString(1) + "";
                    txtSoLuong.Text = reader.GetInt32(2).ToString() + "";
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaSach.ReadOnly = true;
                txtTenSach.ReadOnly = true;
                txtSoLuong.ReadOnly = false;
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
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateInventory";
                command.Connection = conn;

                command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                command.Parameters.Add("@Soluong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    HienThiToanBoKhoSach();
                    MessageBox.Show("Sửa Thành Công");
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại");
                }
            }
            catch (SqlException ex)
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
                HienThiToanBoKhoSach();

                txtMaSach.Text = string.Empty;
                txtTenSach.Text = string.Empty;
                txtSoLuong.Text = string.Empty;

                txtMaSach.ReadOnly = true;
                txtTenSach.ReadOnly = true;
                txtSoLuong.ReadOnly = true;

                cbTimKiem.Text = string.Empty;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                lsvDanhGia.Items.Clear();
            }
        }
        private void loadCbTimKiem()
        {
            string query = "SELECT TenSach FROM Sach";
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbTimKiem.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tensach = cbTimKiem.Text.Trim();

            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text; // Thay đổi kiểu CommandType
                command.CommandText = "SELECT * FROM SearchInventory(@TenSach)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@TenSach", "%" + tensach + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvKhoSach.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetInt32(2).ToString());

                    lsvKhoSach.Items.Add(item);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_MostInStock";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                    item.SubItems.Add(row["TenSach"].ToString());
                    item.SubItems.Add(row["TongSoLuongTrongKho"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_LeastInStock";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                    item.SubItems.Add(row["TenSach"].ToString());
                    item.SubItems.Add(row["TongSoLuongTrongKho"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }
    }
}
