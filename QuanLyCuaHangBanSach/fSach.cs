using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyCuaHangBanSach
{
    public partial class fSach : Form
    {
        bool Them;
        SqlConnection conn = null;
        string connectionString;

        public fSach(string taikhoan, string matkhau)
        {
            connectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fDanhMucSachSach_Load(object sender, EventArgs e)
        {
            HienThiToanBoSach();       
        }

        private void HienThiToanBoSach()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connectionString);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_Book";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvSach.Items.Clear();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string TenSach = reader.GetString(1);
                    string TacGia = reader.GetString(2);
                    string NXB = reader.GetString(3);
                    string MaTheLoai = reader.GetString(4);
                    string MaNCC = reader.GetString(5);
                    int SoLuongTrenKe = reader.GetInt32(6);
                    decimal DonGia = reader.GetDecimal(7);

                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(TenSach);
                    lvi.SubItems.Add(TacGia);
                    lvi.SubItems.Add(NXB);
                    lvi.SubItems.Add(MaTheLoai);
                    lvi.SubItems.Add(MaNCC);
                    lvi.SubItems.Add(SoLuongTrenKe.ToString());
                    lvi.SubItems.Add(DonGia.ToString());

                    lsvSach.Items.Add(lvi);
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
        private void lsvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSach.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvSach.SelectedItems[0];
            string MaSach = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoSach(MaSach);
        }
        private void HienThiChiTietToanBoSach(string MaSach)
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.ShowBookDetails(@MaSach)";
                command.Connection = conn;

                SqlParameter parMaSach = new SqlParameter("@MaSach", SqlDbType.NVarChar);
                parMaSach.Value = MaSach;
                command.Parameters.Add(parMaSach);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaSach.Text = reader.GetString(0) + "";
                    txtTenSach.Text = reader.GetString(1) + "";
                    txtTacGia.Text = reader.GetString(2) + "";
                    txtNXB.Text = reader.GetString(3) + "";
                    txtMaTheLoai.Text = reader.GetString(4) + "";
                    txtMaNCC.Text = reader.GetString(5) + "";
                    txtSoLuong.Text = reader.GetInt32(6).ToString() + "";
                    txtDonGia.Text = reader.GetDecimal(7).ToString() + "";
                    txtSoLuongKho.Text = reader.GetInt32(8).ToString() + "";
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
                    conn = new SqlConnection(connectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                txtMaSach.ReadOnly = true;
                txtTenSach.ReadOnly = false;
                txtTacGia.ReadOnly = false;
                txtNXB.ReadOnly = false;
                txtMaTheLoai.ReadOnly = false;
                txtMaNCC.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtDonGia.ReadOnly = false;
                txtSoLuongKho.ReadOnly = false;

                txtMaSach.Text = string.Empty;
                txtTenSach.Text = string.Empty;
                txtTacGia.Text = string.Empty;
                txtNXB.Text = string.Empty;
                txtMaTheLoai.Text = string.Empty;
                txtMaNCC.Text = string.Empty;
                txtSoLuong.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                txtSoLuongKho.Text = string.Empty;

                //Tăng mã sách lên 1
                string maxID = "MS000";
                foreach (ListViewItem item in lsvSach.Items)
                {
                    string maSach = item.SubItems[0].Text;
                    if (maSach.CompareTo(maxID) > 0)
                    {
                        maxID = maSach;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "MS" + newNumber.ToString("000");
                txtMaSach.Text = newID;
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
                    conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaSach.ReadOnly = true;
                txtTenSach.ReadOnly = false;
                txtTacGia.ReadOnly = false;
                txtNXB.ReadOnly = false;
                txtMaTheLoai.ReadOnly = false;
                txtMaNCC.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtDonGia.ReadOnly = false;
                txtSoLuongKho.ReadOnly = false;

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
            if (Them)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddBook";
                    command.Connection = conn;

                    command.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = txtTenSach.Text;
                    command.Parameters.Add("@TacGia", SqlDbType.NVarChar).Value = txtTacGia.Text;
                    command.Parameters.Add("@NXB", SqlDbType.NVarChar).Value = txtNXB.Text;
                    command.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar).Value = txtMaTheLoai.Text;
                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;
                    command.Parameters.Add("@SoluongTrenKe", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);
                    command.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = decimal.Parse(txtDonGia.Text);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "AddInventory";
                    command1.Connection = conn;
                    command1.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    command1.Parameters.Add("@Soluong", SqlDbType.Int).Value = int.Parse(txtSoLuongKho.Text);

                    int n = command.ExecuteNonQuery();
                    int n1 = command1.ExecuteNonQuery();
                    if (n > 0 && n > 0)
                    {
                        HienThiToanBoSach();
                        txtMaSach.ReadOnly = true;
                        txtTenSach.ReadOnly = true;
                        txtTacGia.ReadOnly = true;
                        txtNXB.ReadOnly = true;
                        txtMaTheLoai.ReadOnly = true;
                        txtMaNCC.ReadOnly = true;
                        txtSoLuong.ReadOnly = true;
                        txtDonGia.ReadOnly = true;
                        txtSoLuongKho.ReadOnly = true;
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
                    command.CommandText = "UpdateBook";
                    command.Connection = conn;

                    command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                    command.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = txtTenSach.Text;
                    command.Parameters.Add("@TacGia", SqlDbType.NVarChar).Value = txtTacGia.Text;
                    command.Parameters.Add("@NXB", SqlDbType.NVarChar).Value = txtNXB.Text;
                    command.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar).Value = txtMaTheLoai.Text;
                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;
                    command.Parameters.Add("@SoluongTrenKe", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);
                    command.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = decimal.Parse(txtDonGia.Text);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "UpdateInventory";
                    command1.Connection = conn;

                    command1.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    command1.Parameters.Add("@Soluong", SqlDbType.Int).Value = int.Parse(txtSoLuongKho.Text);

                    int n = command.ExecuteNonQuery();
                    int n1 = command1.ExecuteNonQuery();
                    if (n > 0 && n1 > 0)
                    {
                        HienThiToanBoSach();
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
            string tacgia = cbTimKiem.Text.Trim();
            string tensach = cbTimKiem.Text.Trim();

            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text; // Thay đổi kiểu CommandType
                command.CommandText = "SELECT * FROM SearchBook(@TenSach, @TacGia)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@TenSach", "%" + tensach + "%");
                command.Parameters.AddWithValue("@TacGia", "%" + tacgia + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvSach.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetString(3));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetString(5));
                    item.SubItems.Add(reader.GetInt32(6).ToString());
                    item.SubItems.Add(reader.GetDecimal(7).ToString());

                    lsvSach.Items.Add(item);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                HienThiToanBoSach();
                //txtTenSachTK.Text = string.Empty;
                //txtTacGiaTK.Text = string.Empty;

                txtMaSach.Text = string.Empty;
                txtTenSach.Text = string.Empty;
                txtTacGia.Text = string.Empty;
                txtNXB.Text = string.Empty;
                txtMaTheLoai.Text = string.Empty;
                txtMaNCC.Text = string.Empty;
                txtSoLuong.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                txtSoLuongKho.Text = string.Empty;

                txtMaSach.ReadOnly = true;
                txtTenSach.ReadOnly = true;
                txtTacGia.ReadOnly = true;
                txtNXB.ReadOnly = true;
                txtMaTheLoai.ReadOnly = true;
                txtMaNCC.ReadOnly = true;
                txtSoLuong.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                txtSoLuongKho.ReadOnly = true;

                rbTenSach.Checked = false;
                rbTacGia.Checked = false;
                rbTheLoai.Checked = false;
                rbNXB.Checked = false;
                rbNCC.Checked = false;

                cbPhanLoai.Text = string.Empty;
                cbTimKiem.Text = string.Empty;
                cbPhanLoai.Items.Clear();
                cbTimKiem.Items.Clear();
            }
        }

        private void rbTenSach_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbTenSach.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT TenSach FROM Sach";
                    using (SqlConnection connection = new SqlConnection(connectionString))
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
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void rbTacGia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbTacGia.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên tác giả và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT TacGia FROM Sach";
                    using (SqlConnection connection = new SqlConnection(connectionString))
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
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rbTheLoai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbTheLoai.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT MaTheLoai FROM Sach";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbPhanLoai.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rbGiaTien_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbGiaTien.Checked)
                {
                    // Xóa dữ liệu cũ trong combobox
                    cbPhanLoai.Items.Clear();

                    // Thêm các khoảng giá tiền vào combobox
                    cbPhanLoai.Items.Add("0 - 49000");
                    cbPhanLoai.Items.Add("50000 - 75000");
                    cbPhanLoai.Items.Add("75000 - 99000");
                    cbPhanLoai.Items.Add("100000 - 200000");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbTheLoai.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM ClassifiedByGenre(@MaTheLoai)";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@MaTheLoai", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvSach.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                        item.SubItems.Add(row["TenSach"].ToString());
                        item.SubItems.Add(row["TacGia"].ToString());
                        item.SubItems.Add(row["NXB"].ToString());
                        item.SubItems.Add(row["MaTheLoai"].ToString());
                        item.SubItems.Add(row["MaNCC"].ToString());
                        item.SubItems.Add(row["SoLuongTrenKe"].ToString());
                        item.SubItems.Add(row["DonGia"].ToString());
                        lsvSach.Items.Add(item);
                    }
                }
                else if (rbGiaTien.Checked)
                {
                    // Lấy giá trị giá tiền từ combobox
                    string[] giaTien = cbPhanLoai.Text.Split(new string[] { " - " }, StringSplitOptions.None);
                    int minPrice = int.Parse(giaTien[0]);
                    int maxPrice = int.MaxValue;
                    if (giaTien.Length == 2)
                    {
                        maxPrice = int.Parse(giaTien[1]);
                    }

                    // Lọc dữ liệu theo khoảng giá tiền đã chọn
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ClassifiedByPrice";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@MinPrice", minPrice);
                    command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Sach");

                    // Hiển thị dữ liệu lên ListView
                    lsvSach.Items.Clear();
                    foreach (DataRow row in ds.Tables["Sach"].Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                        item.SubItems.Add(row["TenSach"].ToString());
                        item.SubItems.Add(row["TacGia"].ToString());
                        item.SubItems.Add(row["NXB"].ToString());
                        item.SubItems.Add(row["MaTheLoai"].ToString());
                        item.SubItems.Add(row["MaNCC"].ToString());
                        item.SubItems.Add(row["SoLuongTrenKe"].ToString());
                        item.SubItems.Add(row["DonGia"].ToString());
                        lsvSach.Items.Add(item);
                    }
                }
                else if (rbNCC.Checked)
                {
                    // Lọc dữ liệu theo Mã NCC đã chọn
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM ClassifiedBySupplier(@MaNCC)";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@MaNCC", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvSach.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                        item.SubItems.Add(row["TenSach"].ToString());
                        item.SubItems.Add(row["TacGia"].ToString());
                        item.SubItems.Add(row["NXB"].ToString());
                        item.SubItems.Add(row["MaTheLoai"].ToString());
                        item.SubItems.Add(row["MaNCC"].ToString());
                        item.SubItems.Add(row["SoLuongTrenKe"].ToString());
                        item.SubItems.Add(row["DonGia"].ToString());
                        lsvSach.Items.Add(item);
                    }
                }
                else
                {
                    // Lọc dữ liệu theo Mã NCC đã chọn
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM ClassifiedByPublishing(@NXB)";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@NXB", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvSach.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                        item.SubItems.Add(row["TenSach"].ToString());
                        item.SubItems.Add(row["TacGia"].ToString());
                        item.SubItems.Add(row["NXB"].ToString());
                        item.SubItems.Add(row["MaTheLoai"].ToString());
                        item.SubItems.Add(row["MaNCC"].ToString());
                        item.SubItems.Add(row["SoLuongTrenKe"].ToString());
                        item.SubItems.Add(row["DonGia"].ToString());
                        lsvSach.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rbNCC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbNCC.Checked)
                {
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT MaNCC FROM Sach";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbPhanLoai.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rbNXB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbNXB.Checked)
                {
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT NXB FROM Sach";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbPhanLoai.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
