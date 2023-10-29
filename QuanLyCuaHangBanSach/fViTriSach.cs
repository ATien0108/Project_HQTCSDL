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
    public partial class fViTriSach : Form
    {
        SqlConnection conn = null;
        string strConnectionString;
        public fViTriSach(string taikhoan, string matkhau)
        {
            strConnectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
        }
        private void fViTriSach_Load(object sender, EventArgs e)
        {
            HienThiToanBoVTS();
            loadCbTimKiem();
            loadCbPhanLoai();
        }
        private void HienThiToanBoVTS()
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
                command.CommandText = "SELECT * FROM View_BookLocation";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvVTS.Items.Clear();
                while (reader.Read())
                {
                    string MaViTri = reader.GetString(0);
                    string MaSach = reader.GetString(1);
                    string Ke = reader.GetInt32(2).ToString();
                    string Tang = reader.GetInt32(3).ToString();
                    string Ngan = reader.GetInt32(4).ToString();

                    ListViewItem lvi = new ListViewItem(MaViTri);
                    lvi.SubItems.Add(MaSach);
                    lvi.SubItems.Add(Ke);
                    lvi.SubItems.Add(Tang);
                    lvi.SubItems.Add(Ngan);

                    lsvVTS.Items.Add(lvi);
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
        private void lsvVTS_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lsvVTS.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvVTS.SelectedItems[0];
            string MaViTri = lvi.SubItems[0].Text.Trim();

            HienThiChiTietToanBoVTS(MaViTri);
        }
        private void HienThiChiTietToanBoVTS(string MaViTri)
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
                command.CommandText = "ShowBookLocationDetails";
                command.Connection = conn;

                SqlParameter parMaViTri = new SqlParameter("@MaViTri", SqlDbType.NVarChar);
                parMaViTri.Value = MaViTri;
                command.Parameters.Add(parMaViTri);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaViTri.Text = reader.GetString(0) + "";
                    txtMaSach.Text = reader.GetString(1) + "";
                    txtKe.Text = reader.GetInt32(2).ToString() + "";
                    txtTang.Text = reader.GetInt32(3).ToString() + "";
                    txtNgan.Text = reader.GetInt32(4).ToString() + "";
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

        private void btnSuaVTS_Click(object sender, EventArgs e)
        {
            //Them = false;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaViTri.ReadOnly = true;
                txtMaSach.ReadOnly = false;
                txtKe.ReadOnly = false;
                txtTang.ReadOnly = false;
                txtNgan.ReadOnly = false;

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

        private void btnHuyVTS_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                HienThiToanBoVTS();

                txtMaViTri.ReadOnly = true;
                txtMaSach.ReadOnly = false;
                txtKe.ReadOnly = false;
                txtTang.ReadOnly = false;
                txtNgan.ReadOnly = false;

                txtMaViTri.Text = string.Empty;
                txtMaSach.Text = string.Empty;
                txtKe.Text = string.Empty;
                txtTang.Text = string.Empty;
                txtNgan.Text = string.Empty;

                rbBestSell.Checked = false;
                rbWorstSell.Checked = false;

                cbTimKiem.Text = string.Empty;
                cbPhanLoai.Text = string.Empty;
                lsvDanhGia.Items.Clear();
            }
        }

        private void btnLuuVTS_Click(object sender, EventArgs e)
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
                command.CommandText = "UpdateBookLocation";
                command.Connection = conn;
                //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                command.Parameters.Add("@MaViTri", SqlDbType.NVarChar).Value = txtMaViTri.Text;
                command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = txtMaSach.Text;
                command.Parameters.Add("@Ke", SqlDbType.Int).Value = int.Parse(txtKe.Text);
                command.Parameters.Add("@Tang", SqlDbType.Int).Value = int.Parse(txtTang.Text);
                command.Parameters.Add("@Ngan", SqlDbType.Int).Value = int.Parse(txtNgan.Text);

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    HienThiToanBoVTS();
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string MaSach = cbTimKiem.Text.Trim();

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
                command.CommandText = "SELECT * FROM SearchBookLocation(@MaSach)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@MaSach", "%" + MaSach + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvVTS.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetInt32(2).ToString());
                    item.SubItems.Add(reader.GetInt32(3).ToString());
                    item.SubItems.Add(reader.GetInt32(4).ToString());

                    lsvVTS.Items.Add(item);
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
            string query = "SELECT MaSach FROM ViTriSach";
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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ClassifiedByShelf";
            command.Connection = conn;
            command.Parameters.AddWithValue("@Ke", cbPhanLoai.Text);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lsvVTS.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaViTri"].ToString());
                item.SubItems.Add(row["MaSach"].ToString());
                item.SubItems.Add(row["Ke"].ToString());
                item.SubItems.Add(row["Tang"].ToString());
                item.SubItems.Add(row["Ngan"].ToString());
                lsvVTS.Items.Add(item);
            }
        }

        private void loadCbPhanLoai()
        {
            string query = "SELECT DISTINCT Ke FROM ViTriSach";
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
        private void rbBestSell_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBestSell.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_BookBestSell";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                    item.SubItems.Add(row["TenSach"].ToString());
                    item.SubItems.Add(row["TongSoLuongBan"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }

        private void rbWorstSell_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWorstSell.Checked)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_BookWorstSell";
                command.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lsvDanhGia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                    item.SubItems.Add(row["TenSach"].ToString());
                    item.SubItems.Add(row["TongSoLuongBan"].ToString());
                    lsvDanhGia.Items.Add(item);
                }
            }
        }
    }
}
