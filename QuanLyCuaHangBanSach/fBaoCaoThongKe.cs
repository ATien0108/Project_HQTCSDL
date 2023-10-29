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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangBanSach
{
    public partial class fBaoCaoThongKe : Form
    {
        string connectionString;
        SqlConnection conn = null;
        public fBaoCaoThongKe(string taikhoan, string matkhau)
        {
            connectionString = $"Data Source=(local);Initial Catalog=QLCHBS;User ID={taikhoan}; Password={matkhau}";
            InitializeComponent();
            CreateColumnChartDoanhThu();
            CreateColumnChartPhieuNhap();
        }
        private void fBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            HienThiTKDoanhThu();
            HienThiTKPhieuNhap();
        }
        private void HienThiTKDoanhThu()
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
                command.CommandText = "SELECT * FROM dbo.ThongKeHoaDon()";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvDoanhThu.Items.Clear();
                while (reader.Read())
                {
                    DateTime Ngay = reader.GetDateTime(0);
                    string SoLuongSachBan = reader.GetInt32(1).ToString();
                    string TongTien = reader.GetInt32(2).ToString();

                    ListViewItem lvi = new ListViewItem(Ngay.ToString("yyyy-MM-dd"));
                    lvi.SubItems.Add(SoLuongSachBan);
                    lvi.SubItems.Add(TongTien);

                    lsvDoanhThu.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
            finally
            {
                conn.Close();
            }
        }
        private void HienThiTKPhieuNhap()
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
                command.CommandText = "SELECT * FROM fn_PaymentStatistics()";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhieuNhap.Items.Clear();
                while (reader.Read())
                {
                    DateTime Ngay = reader.GetDateTime(0);
                    string SoLuongNhap = reader.GetInt32(1).ToString();
                    string TongTien = reader.GetInt32(2).ToString();

                    ListViewItem lvi = new ListViewItem(Ngay.ToString("yyyy-MM-dd"));
                    lvi.SubItems.Add(SoLuongNhap);
                    lvi.SubItems.Add(TongTien);

                    lsvPhieuNhap.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
            finally
            {
                conn.Close();
            }
        }
        private void CreateColumnChartDoanhThu()
        {
            try
            {
                // Thiết lập kích thước và vị trí của biểu đồ cột
                chartDoanhThu.Series["Series1"].ChartType = SeriesChartType.Column;
                chartDoanhThu.Series["Series1"].IsVisibleInLegend = false;
                chartDoanhThu.Series["Series1"].XValueMember = "Tuan";
                chartDoanhThu.Series["Series1"].YValueMembers = "TongDoanhThu";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.Titles.Add("Title1").Text = "Biểu Đồ Doanh Thu";
                string query = "SELECT * FROM View_RevenueStatistics_Week";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập dữ liệu cho biểu đồ tròn và cột
                    chartDoanhThu.DataSource = dataTable;
                    chartDoanhThu.DataBind();
                }

                // Thêm biểu đồ cột vào form
                pDoanhThu.Controls.Add(chartDoanhThu);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }

        }
        private void CreateColumnChartPhieuNhap()
        {
            try
            {
                // Thiết lập kích thước và vị trí của biểu đồ cột
                chartPhieuNhap.Series["Series1"].ChartType = SeriesChartType.Column;
                chartPhieuNhap.Series["Series1"].IsVisibleInLegend = false;
                chartPhieuNhap.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                chartPhieuNhap.Series["Series1"].XValueMember = "Thang";
                chartPhieuNhap.Series["Series1"].YValueMembers = "TongTien";
                chartPhieuNhap.ChartAreas[0].AxisX.Interval = 1;
                chartPhieuNhap.Titles.Add("Title1").Text = "Biểu Đồ Phiếu Nhập";
                string query = "SELECT * FROM View_PaymentStatistics_Week";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập dữ liệu cho biểu đồ tròn và cột
                    chartPhieuNhap.DataSource = dataTable;
                    chartPhieuNhap.DataBind();
                }

                // Thêm biểu đồ cột vào form
                pPhieuNhap.Controls.Add(chartPhieuNhap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
        }
    }
}
