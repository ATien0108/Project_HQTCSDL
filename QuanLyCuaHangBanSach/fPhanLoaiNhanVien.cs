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
    public partial class fPhanLoaiNhanVien : Form
    {
        bool Them;
        SqlConnection conn = null;
        string strConnectionString;
        public fPhanLoaiNhanVien(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fPhanLoaiNhanVien_Load(object sender, EventArgs e)
        {
            HienThiPhanLoaiNhanVien();
            HienThiToanBoDangNhap();
        }
        void HienThiPhanLoaiNhanVien()
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
                command.CommandText = "SELECT * FROM View_ClassifiedStaff";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhanLoaiNhanVien.Items.Clear();
                while (reader.Read())
                {
                    string MaChucVu = reader.GetString(0);
                    string TenChucVu = reader.GetString(1);
                    string MoTaCongViec = reader.GetString(2);
                    string Luong = reader.GetDecimal(3).ToString();

                    ListViewItem lvi = new ListViewItem(MaChucVu);
                    lvi.SubItems.Add(TenChucVu);
                    lvi.SubItems.Add(MoTaCongViec);
                    lvi.SubItems.Add(Luong);


                    lsvPhanLoaiNhanVien.Items.Add(lvi);
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
        void HienThiToanBoDangNhap()
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
                command.CommandText = "SELECT * FROM View_Account";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvDangNhap.Items.Clear();
                while (reader.Read())
                {
                    string MaNhanVien = reader.GetString(0);
                    string TaiKhoan = reader.GetString(1);
                    string MatKhau = reader.GetString(2);

                    ListViewItem lvi = new ListViewItem(MaNhanVien);
                    lvi.SubItems.Add(TaiKhoan);
                    lvi.SubItems.Add(MatKhau);

                    lsvDangNhap.Items.Add(lvi);
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
        private void lsvPhanLoaiNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhanLoaiNhanVien.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhanLoaiNhanVien.SelectedItems[0];
            string MaChucVu = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoPLNV(MaChucVu);
        }
        void HienThiChiTietToanBoPLNV(string MaChucVu)
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
                command.CommandText = "ShowClassifiedStaff";
                command.Connection = conn;

                SqlParameter parMaChucVu = new SqlParameter("@MaChucVu", SqlDbType.NVarChar);
                parMaChucVu.Value = MaChucVu;
                command.Parameters.Add(parMaChucVu);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaChucVu.Text = reader.GetString(0) + "";
                    txtTenChucVu.Text = reader.GetString(1) + "";
                    txtMoTaCongViec.Text = reader.GetString(2) + "";
                    txtLuong.Text = reader.GetDecimal(3).ToString() + "";
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

        private void rbChucVu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbChucVu.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT TenChucVu FROM PhanLoaiNhanVien";
                    using (SqlConnection connection = new SqlConnection(strConnectionString))
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

        private void rbLuong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbLuong.Checked)
                {
                    // Xóa dữ liệu cũ trong combobox
                    cbPhanLoai.Items.Clear();

                    // Thêm các khoảng giá tiền vào combobox
                    cbPhanLoai.Items.Add("5000000 - 7999999");
                    cbPhanLoai.Items.Add("8000000 - 11999999");
                    cbPhanLoai.Items.Add("12000000 - 15000000");
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
                if (rbChucVu.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "FindDuty";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@TenChucVu", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvPhanLoaiNhanVien.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string maChucVu = row["MaChucVu"].ToString();
                        // đưa dữ liệu lên list view phân loại nhân viên
                        ListViewItem itemPhanLoaiNhanVien = new ListViewItem(maChucVu);
                        itemPhanLoaiNhanVien.SubItems.Add(row["TenChucVu"].ToString());
                        itemPhanLoaiNhanVien.SubItems.Add(row["MoTaCongViec"].ToString());
                        itemPhanLoaiNhanVien.SubItems.Add(row["Luong"].ToString());
                        lsvPhanLoaiNhanVien.Items.Add(itemPhanLoaiNhanVien);
                    }
                }
                else if (rbLuong.Checked)
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
                    command.CommandText = "ClassifiedBySalary";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@MinPrice", minPrice);
                    command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvPhanLoaiNhanVien.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        // kiểm tra xem MaChucVu đã có trong ListView chưa
                        string maChucVu = row["MaChucVu"].ToString();
                        bool existChucVu = lsvPhanLoaiNhanVien.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text.Equals(maChucVu));

                        // chỉ thêm vào ListView nếu MaChucVu chưa có
                        if (!existChucVu)
                        {
                            // đưa dữ liệu lên list view phân loại nhân viên
                            ListViewItem itemPhanLoaiNhanVien = new ListViewItem(maChucVu);
                            itemPhanLoaiNhanVien.SubItems.Add(row["TenChucVu"].ToString());
                            itemPhanLoaiNhanVien.SubItems.Add(row["MoTaCongViec"].ToString());
                            itemPhanLoaiNhanVien.SubItems.Add(row["Luong"].ToString());
                            lsvPhanLoaiNhanVien.Items.Add(itemPhanLoaiNhanVien);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

                txtMaChucVu.Text = string.Empty;
                txtMoTaCongViec.Text = string.Empty;
                txtTenChucVu.Text = string.Empty;
                txtLuong.Text = string.Empty;

                txtMaChucVu.ReadOnly = true;
                txtTenChucVu.ReadOnly = false;
                txtMoTaCongViec.ReadOnly = false;
                txtLuong.ReadOnly = false;


                //Tăng mã Chức Vụ lên 1
                string maxID = "CV000";
                foreach (ListViewItem item in lsvPhanLoaiNhanVien.Items)
                {
                    string maChucVu = item.SubItems[0].Text;
                    if (maChucVu.CompareTo(maxID) > 0)
                    {
                        maxID = maChucVu;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "CV" + newNumber.ToString("000");
                txtMaChucVu.Text = newID;
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

                txtMaChucVu.ReadOnly = true;
                txtTenChucVu.ReadOnly = false;
                txtMoTaCongViec.ReadOnly = false;
                txtLuong.ReadOnly = false;
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

                HienThiPhanLoaiNhanVien();
                txtMaChucVu.Text = string.Empty;
                txtMoTaCongViec.Text = string.Empty;
                txtTenChucVu.Text = string.Empty;
                txtLuong.Text = string.Empty;

                txtMaChucVu.ReadOnly = true;
                txtTenChucVu.ReadOnly = true;
                txtMoTaCongViec.ReadOnly = true;
                txtLuong.ReadOnly = true;

                rbChucVu.Checked = false;
                rbLuong.Checked = false;

                cbPhanLoai.Text = string.Empty;
                cbPhanLoai.Items.Clear();
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
                    command.CommandText = "AddClassifiedStaff";
                    command.Connection = conn;

                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;
                    command.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = txtTenChucVu.Text;
                    command.Parameters.Add("@MoTaCongViec", SqlDbType.NVarChar).Value = txtMoTaCongViec.Text;
                    command.Parameters.Add("@Luong", SqlDbType.Decimal).Value = decimal.Parse(txtLuong.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiPhanLoaiNhanVien();
                        txtMaChucVu.ReadOnly = true;
                        txtTenChucVu.ReadOnly = true;
                        txtMoTaCongViec.ReadOnly = true;
                        txtLuong.ReadOnly = true;
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
                    command.CommandText = "UpdateClassifiedStaff";
                    command.Connection = conn;

                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;
                    command.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = txtTenChucVu.Text;
                    command.Parameters.Add("@MoTaCongViec", SqlDbType.NVarChar).Value = txtMoTaCongViec.Text;
                    command.Parameters.Add("@Luong", SqlDbType.Decimal).Value = decimal.Parse(txtLuong.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiPhanLoaiNhanVien();
                        txtMaChucVu.ReadOnly = true;
                        txtTenChucVu.ReadOnly = true;
                        txtMoTaCongViec.ReadOnly = true;
                        txtLuong.ReadOnly = true;
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
    }
}
