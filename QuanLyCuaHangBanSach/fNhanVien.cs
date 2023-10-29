using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanSach
{
    public partial class fNhanVien : Form
    {
        bool Them;
        SqlConnection conn = null;
        string strConnectionString;
        public fNhanVien(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fNhanVien_Load(object sender, EventArgs e)
        {
            HienThiToanBoNhanVien();
        }
        void HienThiToanBoNhanVien()
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
                command.CommandText = "SELECT * FROM View_Staff";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    string MaNhanVien = reader.GetString(0);
                    string HoTen = reader.GetString(1);
                    string NgaySinh = reader.GetDateTime(2).ToString("yyyy-MM-dd");
                    string GioiTinh = reader.GetString(3);
                    string MaChucVu = reader.GetString(4);
                    string DiaChi = reader.GetString(5);
                    string SoDienThoai = reader.GetString(6);
                    string HoatDong = reader.GetString(7);

                    ListViewItem lvi = new ListViewItem(MaNhanVien);
                    lvi.SubItems.Add(HoTen);
                    lvi.SubItems.Add(NgaySinh);
                    lvi.SubItems.Add(GioiTinh);
                    lvi.SubItems.Add(MaChucVu);
                    lvi.SubItems.Add(DiaChi);
                    lvi.SubItems.Add(SoDienThoai);
                    lvi.SubItems.Add(HoatDong);


                    lsvNhanVien.Items.Add(lvi);
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
        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvNhanVien.SelectedItems[0];
            string MaNhanVien = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoNV(MaNhanVien);
        }

        void HienThiChiTietToanBoNV(string MaNhanVien)
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
                command.CommandText = "ShowStaff";
                command.Connection = conn;

                SqlParameter parMaNhanVien = new SqlParameter("@MaNhanVien", SqlDbType.NVarChar);
                parMaNhanVien.Value = MaNhanVien;
                command.Parameters.Add(parMaNhanVien);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaNhanVien.Text = reader.GetString(0) + "";
                    txtHoTen.Text = reader.GetString(1) + "";
                    txtNgaySinh.Text = reader.GetDateTime(2).ToString() + "";
                    txtGioiTinh.Text = reader.GetString(3) + "";
                    txtMaChucVu.Text = reader.GetString(4) + "";
                    txtDiaChi.Text = reader.GetString(5) + "";
                    txtSoDienThoai.Text = reader.GetString(6) + "";
                    txtHoatDong.Text = reader.GetString(7) + "";
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
                    string query = "SELECT DISTINCT MaChucVu FROM NhanVien";
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

        private void rbHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbHoatDong.Checked)
                {
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT HoatDong FROM NhanVien";
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

        private void rbGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbGioiTinh.Checked)
                {
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT GioiTinh FROM NhanVien";
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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbChucVu.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ClassifiedByDuty";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@MaChucVu", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvNhanVien.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        // kiểm tra xem MaNhanVien đã có trong ListView chưa
                        string maNhanVien = row["MaNhanVien"].ToString();
                        bool existNhanVien = lsvNhanVien.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text.Equals(maNhanVien));

                        // chỉ thêm vào ListView nếu MaNhanVien chưa có
                        if (!existNhanVien)
                        {
                            // đưa dữ liệu lên list view nhân viên
                            ListViewItem itemNhanVien = new ListViewItem(maNhanVien);
                            itemNhanVien.SubItems.Add(row["HoTen"].ToString());
                            itemNhanVien.SubItems.Add(row["NgaySinh"].ToString());
                            itemNhanVien.SubItems.Add(row["GioiTinh"].ToString());
                            itemNhanVien.SubItems.Add(row["MaChucVu"].ToString());
                            itemNhanVien.SubItems.Add(row["DiaChi"].ToString());
                            itemNhanVien.SubItems.Add(row["SoDienThoai"].ToString());
                            itemNhanVien.SubItems.Add(row["HoatDong"].ToString());
                            lsvNhanVien.Items.Add(itemNhanVien);
                        }
                    }
                }
                else if (rbHoatDong.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ClassifiedByActivity";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@HoatDong", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvNhanVien.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        // kiểm tra xem MaNhanVien đã có trong ListView chưa
                        string maNhanVien = row["MaNhanVien"].ToString();
                        bool existNhanVien = lsvNhanVien.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text.Equals(maNhanVien));

                        // chỉ thêm vào ListView nếu MaNhanVien chưa có
                        if (!existNhanVien)
                        {
                            // đưa dữ liệu lên list view nhân viên
                            ListViewItem itemNhanVien = new ListViewItem(maNhanVien);
                            itemNhanVien.SubItems.Add(row["HoTen"].ToString());
                            itemNhanVien.SubItems.Add(row["NgaySinh"].ToString());
                            itemNhanVien.SubItems.Add(row["GioiTinh"].ToString());
                            itemNhanVien.SubItems.Add(row["MaChucVu"].ToString());
                            itemNhanVien.SubItems.Add(row["DiaChi"].ToString());
                            itemNhanVien.SubItems.Add(row["SoDienThoai"].ToString());
                            itemNhanVien.SubItems.Add(row["HoatDong"].ToString());
                            lsvNhanVien.Items.Add(itemNhanVien);
                        }
                    }
                }
                else if (rbGioiTinh.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ClassifiedBySex";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@GioiTinh", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvNhanVien.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        // kiểm tra xem MaNhanVien đã có trong ListView chưa
                        string maNhanVien = row["MaNhanVien"].ToString();
                        bool existNhanVien = lsvNhanVien.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text.Equals(maNhanVien));

                        // chỉ thêm vào ListView nếu MaNhanVien chưa có
                        if (!existNhanVien)
                        {
                            // đưa dữ liệu lên list view nhân viên
                            ListViewItem itemNhanVien = new ListViewItem(maNhanVien);
                            itemNhanVien.SubItems.Add(row["HoTen"].ToString());
                            itemNhanVien.SubItems.Add(row["NgaySinh"].ToString());
                            itemNhanVien.SubItems.Add(row["GioiTinh"].ToString());
                            itemNhanVien.SubItems.Add(row["MaChucVu"].ToString());
                            itemNhanVien.SubItems.Add(row["DiaChi"].ToString());
                            itemNhanVien.SubItems.Add(row["SoDienThoai"].ToString());
                            itemNhanVien.SubItems.Add(row["HoatDong"].ToString());
                            lsvNhanVien.Items.Add(itemNhanVien);
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

                txtMaNhanVien.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtGioiTinh.Text = string.Empty;
                txtHoatDong.Text = string.Empty;
                txtHoTen.Text = string.Empty;
                txtMaChucVu.Text = string.Empty;
                txtNgaySinh.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;

                txtMaNhanVien.ReadOnly = true;
                txtDiaChi.ReadOnly = false;
                txtGioiTinh.ReadOnly = false;
                txtHoatDong.ReadOnly = false;
                txtHoTen.ReadOnly = false;
                txtMaChucVu.ReadOnly = false;
                txtNgaySinh.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;


                //Tăng mã nhân viên lên 1
                string maxID = "NV000";
                foreach (ListViewItem item in lsvNhanVien.Items)
                {
                    string maNhanVien = item.SubItems[0].Text;
                    if (maNhanVien.CompareTo(maxID) > 0)
                    {
                        maxID = maNhanVien;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "NV" + newNumber.ToString("000");
                txtMaNhanVien.Text = newID;
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

                txtMaNhanVien.ReadOnly = true;
                txtDiaChi.ReadOnly = false;
                txtGioiTinh.ReadOnly = false;
                txtHoatDong.ReadOnly = false;
                txtHoTen.ReadOnly = false;
                txtMaChucVu.ReadOnly = false;
                txtNgaySinh.ReadOnly = false;
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
                    command.CommandText = "AddEmployee";
                    command.Connection = conn;

                    command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = DateTime.ParseExact(txtNgaySinh.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = txtGioiTinh.Text;
                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                    command.Parameters.Add("@HoatDong", SqlDbType.NVarChar).Value = txtHoatDong.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoNhanVien();
                        txtMaNhanVien.ReadOnly = true;
                        txtDiaChi.ReadOnly = true;
                        txtGioiTinh.ReadOnly = true;
                        txtHoatDong.ReadOnly = true;
                        txtHoTen.ReadOnly = true;
                        txtMaChucVu.ReadOnly = true;
                        txtNgaySinh.ReadOnly = true;
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
                    command.CommandText = "UpdateEmployee";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                    command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = DateTime.ParseExact(txtNgaySinh.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = txtGioiTinh.Text;
                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                    command.Parameters.Add("@HoatDong", SqlDbType.NVarChar).Value = txtHoatDong.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoNhanVien();
                        txtMaNhanVien.ReadOnly = true;
                        txtDiaChi.ReadOnly = true;
                        txtGioiTinh.ReadOnly = true;
                        txtHoatDong.ReadOnly = true;
                        txtHoTen.ReadOnly = true;
                        txtMaChucVu.ReadOnly = true;
                        txtNgaySinh.ReadOnly = true;
                        txtSoDienThoai.ReadOnly = true;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {

                HienThiToanBoNhanVien();
                txtMaNhanVien.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtGioiTinh.Text = string.Empty;
                txtHoatDong.Text = string.Empty;
                txtHoTen.Text = string.Empty;
                txtMaChucVu.Text = string.Empty;
                txtNgaySinh.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;

                txtMaNhanVien.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtGioiTinh.ReadOnly = true;
                txtHoatDong.ReadOnly = true;
                txtHoTen.ReadOnly = true;
                txtMaChucVu.ReadOnly = true;
                txtNgaySinh.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;

                rbChucVu.Checked = false;
                rbGioiTinh.Checked = false;
                rbHoatDong.Checked = false;

                cbPhanLoai.Text = string.Empty;
                cbPhanLoai.Items.Clear();
            }
        }
    }
}
