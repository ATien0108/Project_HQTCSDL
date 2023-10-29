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
    public partial class fNhaCungCap : Form
    {
        bool Them;
        SqlConnection conn = null;
        string strConnectionString;
        public fNhaCungCap(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiToanBoNCC();
        }
        private void HienThiToanBoNCC()
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
                command.CommandText = "SELECT * FROM View_Supplier";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvNCC.Items.Clear();
                while (reader.Read())
                {
                    string MaNCC = reader.GetString(0);
                    string TenNCC = reader.GetString(1);
                    string DiaChi = reader.GetString(2);
                    string SoDienThoai = reader.GetString(3);

                    ListViewItem lvi = new ListViewItem(MaNCC);
                    lvi.SubItems.Add(TenNCC);
                    lvi.SubItems.Add(DiaChi);
                    lvi.SubItems.Add(SoDienThoai);
                    lsvNCC.Items.Add(lvi);
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

        private void lsvNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNCC.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvNCC.SelectedItems[0];
            string MaNCC = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoNCC(MaNCC);
        }
        private void HienThiChiTietToanBoNCC(string MaNCC)
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
                command.CommandText = "SELECT * FROM ShowSupplierDetails(@MaNCC)";
                command.Connection = conn;

                SqlParameter parMaNCC = new SqlParameter("@MaNCC", SqlDbType.NVarChar);
                parMaNCC.Value = MaNCC;
                command.Parameters.Add(parMaNCC);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaNCC.Text = reader.GetString(0) + "";
                    txtTenNCC.Text = reader.GetString(1) + "";
                    txtDiaChiNCC.Text = reader.GetString(2) + "";
                    txtSoDienThoaiNCC.Text = reader.GetString(3) + "";
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

        private void rbTenNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTenNCC.Checked)
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên NCC và đổ vào ComboBox
                cbTimKiemNCC.Items.Clear();
                string query = "SELECT TenNCC FROM NhaCungCap";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbTimKiemNCC.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            string tenncc = cbTimKiemNCC.Text.Trim();
            string maNCC = cbTimKiemNCC.Text.Trim();

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
                command.CommandText = "SELECT * FROM SearchSupplier(@TenNCC, @MaNCC)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@TenNCC", "%" + tenncc + "%");
                command.Parameters.AddWithValue("@MaNCC", "%" + maNCC + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvNCC.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetString(3));
                    lsvNCC.Items.Add(item);
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

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Them = true;
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

                txtMaNCC.ReadOnly = true;
                txtTenNCC.ReadOnly = false;
                txtDiaChiNCC.ReadOnly = false;
                txtSoDienThoaiNCC.ReadOnly = false;

                txtMaNCC.Text = string.Empty;
                txtTenNCC.Text = string.Empty;
                txtDiaChiNCC.Text = string.Empty;
                txtSoDienThoaiNCC.Text = string.Empty;

                //Tăng mã nhà cung cấp lên 1
                string maxID = "NCC000";
                foreach (ListViewItem item in lsvNCC.Items)
                {
                    string maNCC = item.SubItems[0].Text;
                    if (maNCC.CompareTo(maxID) > 0)
                    {
                        maxID = maNCC;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(3)) + 1;
                string newID = "NCC" + newNumber.ToString("000");
                txtMaNCC.Text = newID;
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

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {

            Them = false;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaNCC.ReadOnly = true;
                txtTenNCC.ReadOnly = false;
                txtDiaChiNCC.ReadOnly = false;
                txtSoDienThoaiNCC.ReadOnly = false;

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

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (Them)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddSupplier";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;
                    command.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = txtTenNCC.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChiNCC.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoaiNCC.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoNCC();
                        txtMaNCC.ReadOnly = true;
                        txtTenNCC.ReadOnly = true;
                        txtDiaChiNCC.ReadOnly = true;
                        txtSoDienThoaiNCC.ReadOnly = true;
                        MessageBox.Show("Lưu Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Lưu Thất Bại");
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
            else
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateSupplier";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;
                    //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                    command.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = txtTenNCC.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChiNCC.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoaiNCC.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoNCC();
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
        }

        private void btnHuyNCC_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                HienThiToanBoNCC();

                txtMaNCC.Text = string.Empty;
                txtTenNCC.Text = string.Empty;
                txtDiaChiNCC.Text = string.Empty;
                txtSoDienThoaiNCC.Text = string.Empty;

                txtMaNCC.ReadOnly = true;
                txtTenNCC.ReadOnly = true;
                txtDiaChiNCC.ReadOnly = true;
                txtSoDienThoaiNCC.ReadOnly = true;

                rbMaNCC.Checked = false;
                rbTenNCC.Checked = false;
                cbTimKiemNCC.Text = string.Empty;
                cbTimKiemNCC.Items.Clear();
            }
        }
        private void rbMaNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaNCC.Checked)
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên Khách Hàng và đổ vào ComboBox
                cbTimKiemNCC.Items.Clear();
                string query = "SELECT MaNCC FROM NhaCungCap";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbTimKiemNCC.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
    }
}
