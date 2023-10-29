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
    public partial class fHoaDon : Form
    {
        int Flag = 0;
        int FlagCT = 0;
        //0 là không
        //1 là thêm
        //2 là sửa
        SqlConnection conn = null;
        string strConnectionString;
        public fHoaDon(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {
            HienThiToanBoHoaDon();
            HienThiToanBoChiTietHoaDon();
            loadcbPhanLoai();
        }

        private void HienThiToanBoHoaDon()
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
                command.CommandText = "SELECT * FROM View_Bill";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvHoaDon.Items.Clear();
                while (reader.Read())
                {
                    string MaHoaDon = reader.GetString(0);
                    string MaNhanVien = reader.GetString(1);
                    string MaKhachHang = reader.GetString(2);
                    DateTime ThoiGian = reader.GetDateTime(3);
                    Decimal ThanhTien = reader.GetDecimal(4);

                    ListViewItem lvi = new ListViewItem(MaHoaDon);
                    lvi.SubItems.Add(MaNhanVien);
                    lvi.SubItems.Add(MaKhachHang);
                    lvi.SubItems.Add(ThoiGian.ToString());
                    lvi.SubItems.Add(ThanhTien.ToString());

                    lsvHoaDon.Items.Add(lvi);
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
            };
        }
        private void HienThiToanBoChiTietHoaDon()
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
                command.CommandText = "SELECT * FROM View_BillDetails";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvChiTietHoaDon.Items.Clear();
                while (reader.Read())
                {
                    string MaHoaDon = reader.GetString(0);
                    string MaSach = reader.GetString(1);
                    int SoLuong = reader.GetInt32(2);
                    int DonGia = reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(MaHoaDon);
                    lvi.SubItems.Add(MaSach);
                    lvi.SubItems.Add(SoLuong.ToString());
                    lvi.SubItems.Add(DonGia.ToString());

                    lsvChiTietHoaDon.Items.Add(lvi);
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

        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvHoaDon.SelectedItems[0];
            string MaHoaDon = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoHoaDon(MaHoaDon);
        }

        private void HienThiChiTietToanBoHoaDon(string maHoaDon)
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
                command.CommandText = "ShowAllBills";
                command.Connection = conn;

                SqlParameter parMaHoaDon = new SqlParameter("@MaHoaDon", SqlDbType.NVarChar);
                parMaHoaDon.Value = maHoaDon;
                command.Parameters.Add(parMaHoaDon);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaHoaDon.Text = reader.GetString(0) + "";
                    txtMaNhanVien.Text = reader.GetString(1) + "";
                    txtMaKhachHang.Text = reader.GetString(2) + "";
                    txtThoiGian.Text = reader.GetDateTime(3).ToString() + "";
                    txtThanhTien.Text = reader.GetDecimal(4).ToString() + "";
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

        private void lsvChiTietHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvChiTietHoaDon.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvChiTietHoaDon.SelectedItems[0];
            string MaHoaDon = lvi.SubItems[0].Text.Trim();
            string MaSach = lvi.SubItems[1].Text.Trim();

            HienThiChiTietToanBoChiTietHoaDon(MaHoaDon, MaSach);
        }

        private void HienThiChiTietToanBoChiTietHoaDon(string maHoaDon, string maSach) //trung
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
                command.CommandText = "ShowAllBillDetails";
                command.Connection = conn;

                SqlParameter parMaHoaDon = new SqlParameter("@MaHoaDon", SqlDbType.NVarChar);
                parMaHoaDon.Value = maHoaDon;
                command.Parameters.Add(parMaHoaDon);

                SqlParameter parMaSach = new SqlParameter("@MaSach", SqlDbType.NVarChar);
                parMaSach.Value = maSach;
                command.Parameters.Add(parMaSach);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaHoaDonCT.Text = reader.GetString(0) + "";
                    txtMaSach.Text = reader.GetString(1);
                    txtSoLuong.Text = reader.GetInt32(2).ToString();
                    txtDonGia.Text = reader.GetInt32(3).ToString();
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

        private void rbnMaHoaDonTK_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnMaHoaDonTK.Checked)
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                cboTimKiem.Items.Clear();
                string query = "SELECT MaHoaDon FROM HoaDon";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboTimKiem.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void rbnMaKhachHangTK_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnMaKhachHangTK.Checked)
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên tác giả và đổ vào ComboBox
                cboTimKiem.Items.Clear();
                string query = "SELECT MaKhachHang FROM KhachHang";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboTimKiem.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
        private void loadcbPhanLoai()
        {
            try
            {
                // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                cboPhanLoai.Items.Clear();
                string query = "SELECT DISTINCT MaNhanVien FROM HoaDon";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboPhanLoai.Items.Add(reader.GetString(0));
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
            string MaHoaDon = cboTimKiem.Text.Trim();
            string MaKhachHang = cboTimKiem.Text.Trim();

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
                command.CommandText = "SELECT * FROM SearchBill(@MaHoaDon, @MaKhachHang)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@MaHoaDon", "%" + MaHoaDon + "%");
                command.Parameters.AddWithValue("@MaKhachHang", "%" + MaKhachHang + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvHoaDon.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetDateTime(3).ToString());
                    item.SubItems.Add(reader.GetDecimal(4).ToString());

                    lsvHoaDon.Items.Add(item);
                }

                reader.Close();

                SqlCommand command1 = new SqlCommand();
                command1.Connection = conn;
                command1.CommandType = CommandType.Text; // Thay đổi kiểu CommandType
                command1.CommandText = "SELECT * FROM SearchBillDetails(@MaHoaDon, @MaKhachHang)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command1.Parameters.AddWithValue("@MaHoaDon", "%" + MaHoaDon + "%");
                command1.Parameters.AddWithValue("@MaKhachHang", "%" + MaKhachHang + "%");

                SqlDataReader reader1 = command1.ExecuteReader();

                lsvChiTietHoaDon.Items.Clear();

                while (reader1.Read())
                {
                    ListViewItem item = new ListViewItem(reader1.GetString(0));
                    item.SubItems.Add(reader1.GetString(1));
                    item.SubItems.Add(reader1.GetInt32(2).ToString());
                    item.SubItems.Add(reader1.GetInt32(3).ToString());

                    lsvChiTietHoaDon.Items.Add(item);
                }
                reader1.Close();
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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // Lọc dữ liệu theo Mã NCC đã chọn
            //string query = "SELECT * FROM HoaDon JOIN ChiTietHoaDon ON HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon WHERE HoaDon.MaNhanVien = @MaNhanVien";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ClassifiedBillByStaff";
            command.Connection = conn;
            command.Parameters.AddWithValue("@MaNhanVien", cboPhanLoai.Text);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lsvHoaDon.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaHoaDon"].ToString());
                item.SubItems.Add(row["MaNhanVien"].ToString());
                item.SubItems.Add(row["MaKhachHang"].ToString());
                item.SubItems.Add(row["ThoiGian"].ToString());
                item.SubItems.Add(row["ThanhTien"].ToString());
                lsvHoaDon.Items.Add(item);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;

            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                HienThiToanBoHoaDon();
                HienThiToanBoChiTietHoaDon();

                txtMaHoaDon.Text = string.Empty;
                txtMaNhanVien.Text = string.Empty;
                txtMaKhachHang.Text = string.Empty;
                txtMaSach.Text = string.Empty;
                txtSoLuong.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                txtThoiGian.Text = string.Empty;
                txtThanhTien.Text = string.Empty;

                txtMaHoaDon.ReadOnly = true;
                txtMaNhanVien.ReadOnly = true;
                txtMaKhachHang.ReadOnly = true;
                txtMaSach.ReadOnly = true;
                txtSoLuong.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                txtThoiGian.ReadOnly = true;
                txtThanhTien.ReadOnly = true;
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            Flag = 1;
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

                txtMaHoaDon.ReadOnly = true;
                txtMaNhanVien.ReadOnly = false;
                txtMaKhachHang.ReadOnly = false;
                txtThoiGian.ReadOnly = true;

                txtMaHoaDon.Text = string.Empty;
                txtMaNhanVien.Text = string.Empty;
                txtMaKhachHang.Text = string.Empty;
                txtThoiGian.Text = string.Empty;

                //Tăng mã lên 1
                string maxID = "HD000";
                foreach (ListViewItem item in lsvHoaDon.Items)
                {
                    string maHoaDon = item.SubItems[0].Text;
                    if (maHoaDon.CompareTo(maxID) > 0)
                    {
                        maxID = maHoaDon;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "HD" + newNumber.ToString("000");
                txtMaHoaDon.Text = newID;
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

        //private void btnSuaHD_Click(object sender, EventArgs e)
        //{
        //    FlagCT = 2;
        //    try
        //    {
        //        if (conn == null)
        //            conn = new SqlConnection(strConnectionString);
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();

        //        txtMaHoaDon.ReadOnly = true;
        //        txtMaNhanVien.ReadOnly = false;
        //        txtMaKhachHang.ReadOnly = false;
        //        txtThoiGian.ReadOnly = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (Flag == 1)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddBill";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                    command.Parameters.Add("@MaKhachHang", SqlDbType.NVarChar).Value = txtMaKhachHang.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoHoaDon();
                        HienThiToanBoChiTietHoaDon();
                        txtMaHoaDon.ReadOnly = true;
                        txtMaNhanVien.ReadOnly = true;
                        txtMaKhachHang.ReadOnly = true;
                        txtThoiGian.ReadOnly = true;
                        txtThanhTien.ReadOnly = true;
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
            if (Flag == 2)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateBill";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                    command.Parameters.Add("@MaKhachHang", SqlDbType.NVarChar).Value = txtMaKhachHang.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoHoaDon();
                        HienThiToanBoChiTietHoaDon();
                        txtMaHoaDon.ReadOnly = true;
                        txtMaNhanVien.ReadOnly = true;
                        txtMaKhachHang.ReadOnly = true;
                        txtThoiGian.ReadOnly = true;
                        txtThanhTien.ReadOnly = true;
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

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            FlagCT = 1;
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
                txtMaHoaDonCT.ReadOnly = false;
                txtMaSach.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtDonGia.ReadOnly = true;

                txtMaHoaDonCT.Text = string.Empty;
                txtMaSach.Text = string.Empty;
                txtSoLuong.Text = string.Empty;
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


        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            FlagCT = 2;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaHoaDonCT.ReadOnly = true;
                txtMaSach.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtDonGia.ReadOnly = true;
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

        private void btnLuuCTHD_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (FlagCT == 1)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddBillDetails";
                    command.Connection = conn;

                    command.Parameters.Add("@MaHoaDon", SqlDbType.NVarChar).Value = txtMaHoaDonCT.Text;
                    command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoHoaDon();
                        HienThiToanBoChiTietHoaDon();
                        txtMaHoaDonCT.ReadOnly = true;
                        txtMaSach.ReadOnly = true;
                        txtSoLuong.ReadOnly = true;
                        txtDonGia.ReadOnly = true;
                        txtThanhTien.ReadOnly = true;

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
            if (FlagCT == 2)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateBillDetails";
                    command.Connection = conn;

                    command.Parameters.Add("@MaHoaDon", SqlDbType.NVarChar).Value = txtMaHoaDonCT.Text;
                    command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);
                    command.Parameters.Add("@DonGia", SqlDbType.Int).Value = int.Parse(txtDonGia.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoHoaDon();
                        HienThiToanBoChiTietHoaDon();
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
