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
    public partial class fKhachHang : Form
    {
        bool Them;
        SqlConnection conn = null;
        string strConnectionString;
        public fKhachHang(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            HienThiToanBoKH();
        }

        private void HienThiToanBoKH()
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
                command.CommandText = "SELECT * FROM View_Customer";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvKhachHang.Items.Clear();
                while (reader.Read())
                {
                    string MaKhachHang = reader.GetString(0);
                    string HoTen = reader.GetString(1);
                    string DiaChi = reader.GetString(2);
                    string SoDienThoai = reader.GetString(3);

                    ListViewItem lvi = new ListViewItem(MaKhachHang);
                    lvi.SubItems.Add(HoTen);
                    lvi.SubItems.Add(DiaChi);
                    lvi.SubItems.Add(SoDienThoai);


                    lsvKhachHang.Items.Add(lvi);
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
        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lsvKhachHang.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvKhachHang.SelectedItems[0];
            string MaKhachHang = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoKH(MaKhachHang);
        }
        private void HienThiChiTietToanBoKH(string MaKhachHang)
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
                command.CommandText = "SELECT * FROM dbo.ShowCustomerDetails(@MaKhachHang)";
                command.Connection = conn;

                SqlParameter parMaKhachHang = new SqlParameter("@MaKhachHang", SqlDbType.NVarChar);
                parMaKhachHang.Value = MaKhachHang;
                command.Parameters.Add(parMaKhachHang);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaKhachHang.Text = reader.GetString(0) + "";
                    txtHoTen.Text = reader.GetString(1) + "";
                    txtDiaChi.Text = reader.GetString(2) + "";
                    txtSoDienThoai.Text = reader.GetString(3) + "";
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

        private void btnThem_Click(object sender, EventArgs e)
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

                txtMaKhachHang.ReadOnly = true;
                txtHoTen.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;

                txtMaKhachHang.Text = string.Empty;
                txtHoTen.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;

                //Tăng mã nhà cung cấp lên 1
                string maxID = "KH000";
                foreach (ListViewItem item in lsvKhachHang.Items)
                {
                    string maNCC = item.SubItems[0].Text;
                    if (maNCC.CompareTo(maxID) > 0)
                    {
                        maxID = maNCC;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "KH" + newNumber.ToString("000");
                txtMaKhachHang.Text = newID;
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
            Them = false;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaKhachHang.ReadOnly = true;
                txtHoTen.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;

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
                HienThiToanBoKH();

                txtMaKhachHang.Text = string.Empty;
                txtHoTen.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;

                txtMaKhachHang.ReadOnly = true;
                txtHoTen.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;

                rbHoTen.Checked = false;
                rbMaKhachHang.Checked = false;
                cbTimKiem.Text = string.Empty;
                cbTimKiem.Items.Clear();
                rbCustomerLeastBuy.Checked = false;
                rbCustomerMostBuy.Checked = false;
                lsvDanhGia.Items.Clear();
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
            if (Them)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddCustomer";
                    command.Connection = conn;

                    command.Parameters.Add("@MaKhachHang", SqlDbType.NVarChar).Value = txtMaKhachHang.Text;
                    command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoKH();
                        txtMaKhachHang.ReadOnly = true;
                        txtHoTen.ReadOnly = true;
                        txtDiaChi.ReadOnly = true;
                        txtSoDienThoai.ReadOnly = true;
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
                    command.CommandText = "UpdateCustomer";
                    command.Connection = conn;

                    command.Parameters.Add("@MaKhachHang", SqlDbType.NVarChar).Value = txtMaKhachHang.Text;
                    //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                    command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoKH();
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string HoTen = cbTimKiem.Text.Trim();
            string MaKH = cbTimKiem.Text.Trim();

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
                command.CommandText = "SELECT * FROM SearchCustomer(@MaKhachHang, @TenKhachHang)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@MaKhachHang", "%" + MaKH + "%");
                command.Parameters.AddWithValue("@TenKhachHang", "%" + HoTen + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvKhachHang.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetString(3));

                    lsvKhachHang.Items.Add(item);
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

        private void rbMaKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaKhachHang.Checked)
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên Khách Hàng và đổ vào ComboBox
                cbTimKiem.Items.Clear();
                string query = "SELECT MaKhachHang FROM KhachHang";
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
        }

        private void rbHoTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHoTen.Checked)
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên Khách Hàng và đổ vào ComboBox
                cbTimKiem.Items.Clear();
                string query = "SELECT HoTen FROM KhachHang";
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
        }

        private void rbCustomerMostBuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustomerMostBuy.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_CustomerMostBuy";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaKhachHang"].ToString());
                    item.SubItems.Add(row["HoTen"].ToString());
                    item.SubItems.Add(row["TongSoHoaDon"].ToString());
                    item.SubItems.Add(row["TongSoLuongMua"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }

        private void rbCustomerLeastBuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustomerLeastBuy.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_CustomerLeastBuy";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaKhachHang"].ToString());
                    item.SubItems.Add(row["HoTen"].ToString());
                    item.SubItems.Add(row["TongSoHoaDon"].ToString());
                    item.SubItems.Add(row["TongSoLuongMua"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }
    }
}
