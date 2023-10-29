using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanSach
{
    public partial class fPhieuNhap : Form
    {
        bool ThemPN;
        bool ThemCTPN;
        SqlConnection conn = null;
        string strConnectionString;
        public fPhieuNhap(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }

        private void fPhieuNhap_Load(object sender, EventArgs e)
        {
            HienThiAllPhieuNhap();
            HienThiAllChiTietPhieuNhap();
            loadcbTimKiem();
        }
        void HienThiAllPhieuNhap()
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
                command.CommandText = "SELECT * FROM View_Receipt";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhieuNhap.Items.Clear();
                while (reader.Read())
                {
                    string MaPhieuNhap = reader.GetString(0);
                    string MaNCC = reader.GetString(1);
                    DateTime NgayNhap = reader.GetDateTime(2);
                    string ThanhTien = reader.GetDecimal(3).ToString();

                    ListViewItem lvi = new ListViewItem(MaPhieuNhap);
                    lvi.SubItems.Add(MaNCC);
                    lvi.SubItems.Add(NgayNhap.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(ThanhTien);
                    lsvPhieuNhap.Items.Add(lvi);
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
        void HienThiAllChiTietPhieuNhap()
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
                command.CommandText = "SELECT * FROM View_ReceiptDetails";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvChiTietPhieuNhap.Items.Clear();
                while (reader.Read())
                {
                    string MaPhieuNhap = reader.GetString(0);
                    string MaSach = reader.GetString(1);
                    string SoLuongNhap = reader.GetInt32(2).ToString();
                    string DonGia = reader.GetInt32(3).ToString();

                    ListViewItem lvi = new ListViewItem(MaPhieuNhap);
                    lvi.SubItems.Add(MaSach);
                    lvi.SubItems.Add(SoLuongNhap);
                    lvi.SubItems.Add(DonGia);

                    lsvChiTietPhieuNhap.Items.Add(lvi);
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

        private void lsvPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuNhap.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhieuNhap.SelectedItems[0];
            string MaPhieuNhap = lvi.SubItems[0].Text.Trim();

            HienThiChiTietCuaPhieuNhap(MaPhieuNhap);
        }

        private void lsvChiTietPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvChiTietPhieuNhap.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvChiTietPhieuNhap.SelectedItems[0];
            string MaPhieuNhap = lvi.SubItems[0].Text.Trim();
            string MaSach = lvi.SubItems[1].Text.Trim();

            HienThiChiTietCuaChiTietPhieuNhap(MaPhieuNhap, MaSach);
        }

        void HienThiChiTietCuaPhieuNhap(string MaPhieuNhap)
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
                command.CommandText = "ShowReceipt";
                command.Connection = conn;

                SqlParameter parMaPhieuNhap = new SqlParameter("@MaPhieuNhap", SqlDbType.NVarChar);
                parMaPhieuNhap.Value = MaPhieuNhap;
                command.Parameters.Add(parMaPhieuNhap);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaPhieuNhap.Text = reader.GetString(0) + "";
                    txtMaNCC.Text = reader.GetString(1) + "";
                    txtNgayNhap.Text = reader.GetDateTime(2).ToString() + "";
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

        void HienThiChiTietCuaChiTietPhieuNhap(string MaPhieuNhap, string maSach)
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
                command.CommandText = "ShowReceiptDetails";
                command.Connection = conn;

                SqlParameter parMaPhieuNhap = new SqlParameter("@MaPhieuNhap", SqlDbType.NVarChar);
                parMaPhieuNhap.Value = MaPhieuNhap;
                command.Parameters.Add(parMaPhieuNhap);

                SqlParameter parMaSach = new SqlParameter("@MaSach", SqlDbType.NVarChar);
                parMaSach.Value = maSach;
                command.Parameters.Add(parMaSach);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaPNChiTiet.Text = reader.GetString(4) + "";
                    txtMaSach.Text = reader.GetString(5) + "";
                    txtSoLuongNhap.Text = reader.GetInt32(6).ToString() + "";
                    txtDonGia.Text = reader.GetInt32(7).ToString() + "";
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            HienThiAllPhieuNhap();
            HienThiAllChiTietPhieuNhap();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                HienThiAllPhieuNhap();
                HienThiAllChiTietPhieuNhap();

                txtMaPhieuNhap.Text = string.Empty;
                txtMaPNChiTiet.Text = string.Empty;
                txtMaNCC.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                txtMaSach.Text = string.Empty;
                txtNgayNhap.Text = string.Empty;
                txtSoLuongNhap.Text = string.Empty;

                txtMaSach.ReadOnly = true;
                txtNgayNhap.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                txtMaPhieuNhap.ReadOnly = true;
                txtMaPNChiTiet.ReadOnly = true;
                txtMaNCC.ReadOnly = true;
                txtSoLuongNhap.ReadOnly = true;

                cbTimKiem.Text = string.Empty;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                // xóa phiếu nhập
                SqlCommand commandXoaPN = new SqlCommand();
                commandXoaPN.CommandType = CommandType.StoredProcedure;
                commandXoaPN.CommandText = "DeleteReceipt";
                commandXoaPN.Connection = conn;
                commandXoaPN.Parameters.Add("@MaPhieuNhap", SqlDbType.NVarChar).Value = txtMaPhieuNhap.Text;

                int n = commandXoaPN.ExecuteNonQuery();
                if (n > 0)
                {
                    HienThiAllPhieuNhap();
                    MessageBox.Show("Xóa Thành Công");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
                //Xóa chi tiết phiếu nhập
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand commandXoaCTPN = new SqlCommand();
                commandXoaCTPN.CommandType = CommandType.StoredProcedure;
                commandXoaCTPN.CommandText = "XoaPhieuNhap";
                commandXoaCTPN.Connection = conn;
                commandXoaCTPN.Parameters.Add("@MaPhieuNhap", SqlDbType.NVarChar).Value = txtMaPhieuNhap.Text;

                int m = commandXoaCTPN.ExecuteNonQuery();
                if (m > 0)
                {
                    HienThiAllChiTietPhieuNhap();
                    MessageBox.Show("Xóa Thành Công");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại");
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

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            ThemPN = true;
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

                txtMaPhieuNhap.ReadOnly = true;
                txtMaNCC.ReadOnly = false;
                txtNgayNhap.ReadOnly = true;

                txtMaPhieuNhap.Text = string.Empty;
                txtMaNCC.Text = string.Empty;
                txtNgayNhap.Text = string.Empty;

                //Tăng mã Phiếu Nhập lên 1
                string maxID = "PN000";
                foreach (ListViewItem item in lsvPhieuNhap.Items)
                {
                    string maPhieuNhap = item.SubItems[0].Text;
                    if (maPhieuNhap.CompareTo(maxID) > 0)
                    {
                        maxID = maPhieuNhap;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "PN" + newNumber.ToString("000");
                txtMaPhieuNhap.Text = newID;
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

        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            ThemPN = false;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaPhieuNhap.ReadOnly = true;
                txtMaNCC.ReadOnly = false;
                txtNgayNhap.ReadOnly = true;
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

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (ThemPN)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddReceipt";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiAllPhieuNhap();
                        HienThiAllChiTietPhieuNhap();
                        txtMaPhieuNhap.ReadOnly = true;
                        txtMaNCC.ReadOnly = true;
                        txtNgayNhap.ReadOnly = true;

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
                    command.CommandText = "UpdateReceipt";
                    command.Connection = conn;

                    command.Parameters.Add("@MaPhieuNhap", SqlDbType.NVarChar).Value = txtMaPhieuNhap.Text;
                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;
                    //command.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = DateTime.Parse(txtNgayNhap.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiAllPhieuNhap();
                        HienThiAllChiTietPhieuNhap();
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

        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            ThemCTPN = true;
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

                txtMaPNChiTiet.ReadOnly = false;
                txtMaSach.ReadOnly = false;
                txtSoLuongNhap.ReadOnly = false;
                txtDonGia.ReadOnly = false;

                txtMaPNChiTiet.Text = string.Empty;
                txtMaSach.Text = string.Empty;
                txtSoLuongNhap.Text = string.Empty;
                txtDonGia.Text = string.Empty;

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

        private void btnSuaCTPN_Click(object sender, EventArgs e)
        {
            ThemCTPN = false;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaPNChiTiet.ReadOnly = true;
                txtMaSach.ReadOnly = true;
                txtSoLuongNhap.ReadOnly = false;
                txtDonGia.ReadOnly = false;

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

        private void btnLuuCTPN_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (ThemCTPN)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddReceiptDetails";
                    command.Connection = conn;

                    command.Parameters.Add("@MaPhieuNhap", SqlDbType.NVarChar).Value = txtMaPNChiTiet.Text;
                    command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    command.Parameters.Add("@SoLuongNhap", SqlDbType.Int).Value = int.Parse(txtSoLuongNhap.Text);
                    command.Parameters.Add("@DonGia", SqlDbType.Int).Value = int.Parse(txtDonGia.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiAllPhieuNhap();
                        HienThiAllChiTietPhieuNhap();
                        txtMaPhieuNhap.ReadOnly = true;
                        txtMaSach.ReadOnly = true;
                        txtSoLuongNhap.ReadOnly = true;
                        txtDonGia.ReadOnly = true;

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
                    command.CommandText = "UpdateReceiptDetails";
                    command.Connection = conn;

                    command.Parameters.Add("@MaPhieuNhap", SqlDbType.NVarChar).Value = txtMaPNChiTiet.Text;
                    command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    command.Parameters.Add("@SoLuongNhap", SqlDbType.Int).Value = int.Parse(txtSoLuongNhap.Text);
                    command.Parameters.Add("@DonGia", SqlDbType.Int).Value = int.Parse(txtDonGia.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiAllPhieuNhap();
                        HienThiAllChiTietPhieuNhap();
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
        private void loadcbTimKiem()
        {
            try
            {
                string query = "SELECT MaPhieuNhap FROM PhieuNhap";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maphieunhap = cbTimKiem.Text.Trim();
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
                    SqlCommand commandPN = new SqlCommand();
                    commandPN.Connection = conn;
                    commandPN.CommandType = CommandType.Text; // Thay đổi kiểu CommandType
                    commandPN.CommandText = "SELECT * FROM SearchReceipt(@MaPhieuNhap)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                    commandPN.Parameters.AddWithValue("@MaPhieuNhap", maphieunhap);

                    SqlDataReader readerPN = commandPN.ExecuteReader();

                    lsvPhieuNhap.Items.Clear();

                    while (readerPN.Read())
                    {
                        ListViewItem item = new ListViewItem(readerPN.GetString(0));
                        item.SubItems.Add(readerPN.GetString(1));
                        item.SubItems.Add(readerPN.GetDateTime(2).ToString());
                        item.SubItems.Add(readerPN.GetDecimal(3).ToString());

                    lsvPhieuNhap.Items.Add(item);
                    }

                    readerPN.Close();

                    // tìm kiếm trong Chi Tiết Phiếu Nhập
                    SqlCommand commandCTPN = new SqlCommand();
                    commandCTPN.Connection = conn;
                    commandCTPN.CommandType = CommandType.Text; // Thay đổi kiểu CommandType
                    commandCTPN.CommandText = "SELECT * FROM SearchReceiptDetails(@MaPhieuNhap)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                    commandCTPN.Parameters.AddWithValue("@MaPhieuNhap", maphieunhap);

                    SqlDataReader readerCTPN = commandCTPN.ExecuteReader();

                    lsvChiTietPhieuNhap.Items.Clear();

                    while (readerCTPN.Read())
                    {
                        ListViewItem item = new ListViewItem(readerCTPN.GetString(0));
                        item.SubItems.Add(readerCTPN.GetString(1));
                        item.SubItems.Add(readerCTPN.GetInt32(2).ToString());
                        item.SubItems.Add(readerCTPN.GetInt32(3).ToString());

                        lsvChiTietPhieuNhap.Items.Add(item);
                    }

                    readerCTPN.Close();
                
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
}
