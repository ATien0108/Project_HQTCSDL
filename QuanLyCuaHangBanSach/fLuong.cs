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
    public partial class fLuong : Form
    {
        bool Them;
        SqlConnection conn = null;
        string strConnectionString;
        public fLuong(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fLuong_Load(object sender, EventArgs e)
        {
            HienThiLuong();
        }
        void HienThiLuong()
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
                command.CommandText = "SELECT * FROM View_Salary";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvLuong.Items.Clear();
                while (reader.Read())
                {
                    string MaNhanVien = reader.GetString(0);
                    string SoNgayLamViec = reader.GetInt32(1).ToString();
                    string Thuong = reader.GetDecimal(2).ToString();
                    string TongLuong = reader.GetDecimal(3).ToString();

                    ListViewItem lvi = new ListViewItem(MaNhanVien);
                    lvi.SubItems.Add(SoNgayLamViec);
                    lvi.SubItems.Add(Thuong);
                    lvi.SubItems.Add(TongLuong);


                    lsvLuong.Items.Add(lvi);
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

        private void lsvLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLuong.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvLuong.SelectedItems[0];
            string MaNhanVien = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoLuong(MaNhanVien);
        }
        void HienThiChiTietToanBoLuong(string MaNhanVien)
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
                command.CommandText = "ShowSalary";
                command.Connection = conn;

                SqlParameter parMaNhanVien = new SqlParameter("@MaNhanVien", SqlDbType.NVarChar);
                parMaNhanVien.Value = MaNhanVien;
                command.Parameters.Add(parMaNhanVien);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaNhanVien.Text = reader.GetString(0) + "";
                    txtSNLV.Text = reader.GetInt32(1).ToString() + "";
                    txtThuong.Text = reader.GetDecimal(2).ToString() + "";
                    txtTongLuong.Text = reader.GetDecimal(3).ToString() + "";
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

        private void rbSNLV_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbSNLV.Checked)
                {
                    cbPhanLoai.Items.Clear();
                    string query = "SELECT DISTINCT SoNgayLamViec FROM Luong";
                    using (SqlConnection connection = new SqlConnection(strConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbPhanLoai.Items.Add(reader.GetInt32(0).ToString());
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

        private void rbTongLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTongLuong.Checked)
            {
                // Xóa dữ liệu cũ trong combobox
                cbPhanLoai.Items.Clear();

                // Thêm các khoảng giá tiền vào combobox
                cbPhanLoai.Items.Add("4000000 - 7999999");
                cbPhanLoai.Items.Add("8000000 - 11999999");
                cbPhanLoai.Items.Add("12000000 - 15000000");
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbSNLV.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ClassifiedByDayOfWork";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@SoNgayLamViec", cbPhanLoai.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvLuong.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        // kiểm tra xem MaNhanVien đã có trong ListView chưa
                        string maNV = row["MaNhanVien"].ToString();

                        // chỉ thêm vào ListView nếu MaNhanVien chưa có
                        // đưa dữ liệu lên list view lương
                        ListViewItem itemLuong = new ListViewItem(maNV);
                        itemLuong.SubItems.Add(row["SoNgayLamViec"].ToString());
                        itemLuong.SubItems.Add(row["Thuong"].ToString());
                        itemLuong.SubItems.Add(row["TongLuong"].ToString());
                        lsvLuong.Items.Add(itemLuong);
                    }
                }
                else if (rbTongLuong.Checked)
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
                    command.CommandText = "ClassifiedBySumSalary";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@MinPrice", minPrice);
                    command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvLuong.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        // kiểm tra xem MaNhanVien đã có trong ListView chưa
                        string maNV = row["MaNhanVien"].ToString();

                        // chỉ thêm vào ListView nếu MaNhanVien chưa có
                        // đưa dữ liệu lên list view lương
                        ListViewItem itemLuong = new ListViewItem(maNV);
                        itemLuong.SubItems.Add(row["SoNgayLamViec"].ToString());
                        itemLuong.SubItems.Add(row["Thuong"].ToString());
                        itemLuong.SubItems.Add(row["TongLuong"].ToString());
                        lsvLuong.Items.Add(itemLuong);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {

                HienThiLuong();
                txtMaNhanVien.Text = string.Empty;
                txtSNLV.Text = string.Empty;
                txtThuong.Text = string.Empty;
                txtTongLuong.Text = string.Empty;

                txtMaNhanVien.ReadOnly = true;
                txtSNLV.ReadOnly = true;
                txtThuong.ReadOnly = true;
                txtTongLuong.ReadOnly = true;

                rbSNLV.Checked = false;
                rbTongLuong.Checked = false;

                cbPhanLoai.Text = string.Empty;
                cbPhanLoai.Items.Clear();
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
                txtSNLV.Text = string.Empty;
                txtThuong.Text = string.Empty;
                txtTongLuong.Text = string.Empty;

                txtMaNhanVien.ReadOnly = false;
                txtSNLV.ReadOnly = false;
                txtThuong.ReadOnly = false;
                txtTongLuong.ReadOnly = true;
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
                txtSNLV.ReadOnly = false;
                txtThuong.ReadOnly = false;
                txtTongLuong.ReadOnly = true;
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
            if (Them)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddSalary";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                    command.Parameters.Add("@SoNgayLamViec", SqlDbType.Int).Value = Int32.Parse(txtSNLV.Text);
                    command.Parameters.Add("@Thuong", SqlDbType.Decimal).Value = decimal.Parse(txtThuong.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiLuong();
                        txtMaNhanVien.ReadOnly = true;
                        txtSNLV.ReadOnly = true;
                        txtThuong.ReadOnly = true;
                        txtTongLuong.ReadOnly = true;
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
                    command.CommandText = "UpdateSalary";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                    command.Parameters.Add("@SoNgayLamViec", SqlDbType.Int).Value = Int32.Parse(txtSNLV.Text);
                    command.Parameters.Add("@Thuong", SqlDbType.Decimal).Value = decimal.Parse(txtThuong.Text);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiLuong();
                        txtMaNhanVien.ReadOnly = true;
                        txtSNLV.ReadOnly = true;
                        txtThuong.ReadOnly = true;
                        txtTongLuong.ReadOnly = true;
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM View_NoAbsence";
                    command.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvDanhGia.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaNhanVien"].ToString());
                        item.SubItems.Add(row["SoNgayLamViec"].ToString());
                        item.SubItems.Add(row["Thuong"].ToString());
                        item.SubItems.Add(row["TongLuong"].ToString());
                        lsvDanhGia.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton3.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM View_Top5HighSalary";
                    command.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvDanhGia.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaNhanVien"].ToString());
                        item.SubItems.Add(row["SoNgayLamViec"].ToString());
                        item.SubItems.Add(row["Thuong"].ToString());
                        item.SubItems.Add(row["TongLuong"].ToString());
                        lsvDanhGia.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM View_Top3Bonus";
                    command.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lsvDanhGia.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaNhanVien"].ToString());
                        item.SubItems.Add(row["SoNgayLamViec"].ToString());
                        item.SubItems.Add(row["Thuong"].ToString());
                        item.SubItems.Add(row["TongLuong"].ToString());
                        lsvDanhGia.Items.Add(item);
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
