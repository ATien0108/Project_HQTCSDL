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
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyCuaHangBanSach
{
    public partial class fTheLoai : Form
    {
        bool Them;
        SqlConnection conn = null;
        string strConnectionString;
        public fTheLoai(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fTheLoaiVTSach_Load(object sender, EventArgs e)
        {
            HienThiToanBoTheLoai();
            loadCbTimKiem();
        }

        private void HienThiToanBoTheLoai()
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
                command.CommandText = "SELECT * FROM View_Genre";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvTheLoai.Items.Clear();
                while (reader.Read())
                {
                    string MaTheLoai = reader.GetString(0);
                    string TenTheLoai = reader.GetString(1);
                    string MoTa = reader.GetString(2);

                    ListViewItem lvi = new ListViewItem(MaTheLoai);
                    lvi.SubItems.Add(TenTheLoai);
                    lvi.SubItems.Add(MoTa);

                    lsvTheLoai.Items.Add(lvi);
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
        private void lsvTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lsvTheLoai.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvTheLoai.SelectedItems[0];
            string MaTheLoai = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoTheLoai(MaTheLoai);
        }
        private void HienThiChiTietToanBoTheLoai(string MaTheLoai)
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
                command.CommandText = "ShowGenreDetails";
                command.Connection = conn;

                SqlParameter parMaTheLoai = new SqlParameter("@MaTheLoai", SqlDbType.NVarChar);
                parMaTheLoai.Value = MaTheLoai;
                command.Parameters.Add(parMaTheLoai);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaTheLoai.Text = reader.GetString(0) + "";
                    txtTenTheLoai.Text = reader.GetString(1) + "";
                    txtMoTa.Text = reader.GetString(2) + "";
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

                txtMaTheLoai.ReadOnly = true;
                txtTenTheLoai.ReadOnly = false;
                txtMoTa.ReadOnly = false;

                txtMaTheLoai.Text = string.Empty;
                txtTenTheLoai.Text = string.Empty;
                txtMoTa.Text = string.Empty;

                //Tăng mã nhà cung cấp lên 1
                string maxID = "TL000";
                foreach (ListViewItem item in lsvTheLoai.Items)
                {
                    string maNCC = item.SubItems[0].Text;
                    if (maNCC.CompareTo(maxID) > 0)
                    {
                        maxID = maNCC;
                    }
                }
                int newNumber = int.Parse(maxID.Substring(2)) + 1;
                string newID = "TL" + newNumber.ToString("000");
                txtMaTheLoai.Text = newID;
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

                txtMaTheLoai.ReadOnly = true;
                txtTenTheLoai.ReadOnly = false;
                txtMoTa.ReadOnly = false;

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
                HienThiToanBoTheLoai();

                txtMaTheLoai.ReadOnly = true;
                txtTenTheLoai.ReadOnly = false;
                txtMoTa.ReadOnly = false;

                txtMaTheLoai.Text = string.Empty;
                txtTenTheLoai.Text = string.Empty;
                txtMoTa.Text = string.Empty;

                rbHighestNumber.Checked = false;
                rbLeastNumber.Checked = false;
                rbBestSell.Checked = false;
                rbWorstSell.Checked = false;

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
                    command.CommandText = "AddGenre";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar).Value = txtMaTheLoai.Text;
                    command.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar).Value = txtTenTheLoai.Text;
                    command.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtMoTa.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoTheLoai();
                        txtMaTheLoai.ReadOnly = true;
                        txtTenTheLoai.ReadOnly = true;
                        txtMoTa.ReadOnly = true;
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
                    command.CommandText = "UpdateGenre";
                    command.Connection = conn;
                    //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                    command.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar).Value = txtMaTheLoai.Text;
                    command.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar).Value = txtTenTheLoai.Text;
                    command.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtMoTa.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        HienThiToanBoTheLoai();
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
            string tentheloai = cbTimKiem.Text.Trim();

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
                command.CommandText = "SELECT * FROM SearchGenre(@TenTheLoai)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@TenTheLoai", "%" + tentheloai + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvTheLoai.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));

                    lsvTheLoai.Items.Add(item);
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
        private void loadCbTimKiem()
        {
            string query = "SELECT TenTheLoai FROM TheLoai";
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

        private void rbHighestNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHighestNumber.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_GenreHighestNumber";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaTheLoai"].ToString());
                    item.SubItems.Add(row["TenTheLoai"].ToString());
                    item.SubItems.Add(row["TongSoLuong"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }

        private void rbLeastNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLeastNumber.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_GenreLeastNumber";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaTheLoai"].ToString());
                    item.SubItems.Add(row["TenTheLoai"].ToString());
                    item.SubItems.Add(row["TongSoLuong"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBestSell.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_GenreBestSell";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaTheLoai"].ToString());
                    item.SubItems.Add(row["TenTheLoai"].ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add(row["TongSoLuongBan"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWorstSell.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_GenreWorstSell";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaTheLoai"].ToString());
                    item.SubItems.Add(row["TenTheLoai"].ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add(row["TongSoLuongBan"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }
    }
}
