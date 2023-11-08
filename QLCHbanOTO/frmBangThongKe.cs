using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.SqlServer.Server;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace QLCHbanOTO
{
    public partial class frmBangThongKe : Form
    {
        public frmBangThongKe()
        {
            InitializeComponent();
        }
        
        // Bảng thống kê số lượng xe bán
        private void frmBangThongKe_Load(object sender, EventArgs e)
        {            
            LoadDataGridView();
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
        }
       private void btntim_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateStart.Value.Date;
            DateTime endDate = dateEnd.Value.Date.AddSeconds(86399); // Kết thúc vào 00:00:00 của ngày tiếp theo

            if (endDate >= startDate)
            {
                DataView dv = ((DataTable)dataGridView1.DataSource).DefaultView;
                dv.RowFilter = $"ngayDatHang >= #{startDate}# AND ngayDatHang <= #{endDate}#";

                // Sau khi lọc dữ liệu, tính lại tổng số lượng và tổng thành tiền
                int totalSoLuong = 0;
                decimal totalThanhTien = 0;

                foreach (DataRowView rowView in dv)
                {
                    DataRow row = rowView.Row;
                    totalSoLuong += Convert.ToInt32(row["soLuong"]);
                    totalThanhTien += Convert.ToDecimal(row["thanhTien"]);
                }

                // Cập nhật TextBoxs hiển thị tổng số lượng và tổng thành tiền
                textBox1.Text = totalSoLuong.ToString();
                textBox2.Text = totalThanhTien.ToString("N2");

                // Sau khi tính toán tổng số lượng và tổng thành tiền, cập nhật biểu đồ
                UpdateChart(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QLoto;Integrated Security=True"))
                {
                    conn.Open();
                    DataTable dt = new DataTable();

                    // Thay đổi câu truy vấn SQL để lấy dữ liệu dựa trên khoảng ngày
                    string query = "SELECT loaiXe, SUM(soLuong) as TotalSoLuong FROM khachHang " +
                                    $"WHERE ngayDatHang >= '{startDate}' AND ngayDatHang <= '{endDate}' " +
                                    "GROUP BY loaiXe";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    sqlDataAdapter.Fill(dt);

                    // Xóa các điểm cũ trong biểu đồ
                    chart1.Series["SoLuong"].Points.Clear();

                    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Loại Xe";
                    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                    chart1.Series["SoLuong"]["DrawingStyle"] = "cylinder";
                    chart1.ChartAreas["ChartArea1"].AxisY.Interval = 1;
                    chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;

                    // Cập nhật biểu đồ với dữ liệu mới
                    foreach (DataRow row in dt.Rows)
                    {
                        chart1.Series["SoLuong"].Points.AddXY(row["loaiXe"], row["TotalSoLuong"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo biểu đồ: " + ex.Message);
            }
        }
        private void LoadDataGridView()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QLoto;Integrated Security=True"))
                {
                    cnn.Open();
                    string sql = "SELECT loaiXe, soLuong, donGia, thanhTien,ngayDatHang FROM khachHang";
                  

                    SqlCommand com = new SqlCommand(sql, cnn);
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();    
                    da.Fill(dt);
                    cnn.Close();
                    dataGridView1.DataSource = dt;
                    int totalSoLuong = 0;
                    decimal totalThanhTien = 0;

                    // Duyệt qua các dòng trong DataTable và tính tổng số lượng và tổng thành tiền
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSoLuong += Convert.ToInt32(row["soLuong"]);
                        totalThanhTien += Convert.ToDecimal(row["thanhTien"]);
                    }

                    // Hiển thị tổng số lượng và tổng thành tiền trên các TextBox
                   textBox1.Text = totalSoLuong.ToString();
                    textBox2.Text = totalThanhTien.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào DataGridView: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo hộp thoại SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Chọn vị trí và đặt tên cho tệp Excel";
            saveFileDialog.FileName = "MyData.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Gọi hàm xuất dữ liệu và truyền đường dẫn tới tệp Excel
                ExportToExcel(dataGridView1, saveFileDialog.FileName);
            }
        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            // Tạo một ứng dụng Excel mới
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Tạo một tệp Excel mới
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);

            // Tạo một tờ làm việc trong tệp Excel
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

            // Ghi tiêu đề
            excelWorksheet.Cells[1, 1] = "Bảng thống kê Bán hàng";
            Excel.Range titleRange = excelWorksheet.get_Range("A1", "E1");
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 16;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Ghi tiêu đề cho từng cột
            excelWorksheet.Cells[2, 1] = "Tên sản phẩm";
            excelWorksheet.Cells[2, 2] = "Số lượng";
            excelWorksheet.Cells[2, 3] = "Đơn giá";
            excelWorksheet.Cells[2, 4] = "Thành tiền";
            excelWorksheet.Cells[2, 5] = "Ngày Đặt Hàng";

            // Đặt font và định dạng cho tiêu đề cột
            Excel.Range headerRange = excelWorksheet.get_Range("A2", "E2");
            headerRange.Font.Bold = true;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Sao chép dữ liệu từ DataGridView vào  Excel
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    excelWorksheet.Cells[i + 3, j + 1] = dataGridView[j, i].Value;
                }
            }

            // Điều chỉnh chiều rộng của các cột
            for (int j = 0; j < dataGridView.Columns.Count; j++)
            {
                excelWorksheet.Columns[j + 1].AutoFit();
            }

            // Lưu tệp Excel
            excelWorkbook.SaveAs(filePath);

            //Đóng tệp Excel và giải phóng tài nguyên
            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(excelApp);
           // MessageBox.Show("Dữ liệu đã được xuất thành công vào tệp Excel.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

