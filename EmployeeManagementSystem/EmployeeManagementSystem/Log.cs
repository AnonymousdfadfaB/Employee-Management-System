using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Log : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

        public Log()
        {
            InitializeComponent();
            displayData();
        }
        public void displayData()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    // Kết nối bảng DailyAttendances với Employees để lấy thêm Mã và Tên nhân viên
                    // Sắp xếp ngày mới nhất lên đầu (ORDER BY d.WorkDate DESC)
                    string selectData = @"
                SELECT 
                    d.AttendanceID,
                    e.EmployeeCode,
                    e.FullName,
                    d.WorkDate,
                    d.CheckInTime,
                    d.CheckOutTime,
                    d.WorkDayUnit,
                    d.Status
                FROM DailyAttendances d
                INNER JOIN Employees e ON d.EmployeeID = e.EmployeeID
                ORDER BY d.WorkDate DESC, e.EmployeeCode ASC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Căn chỉnh giao diện bảng đồng bộ với các form khác
                        dataGridView1.RowTemplate.Height = 35;
                        dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                        dataGridView1.DataSource = table;

                        // Định dạng cột ngày làm việc (VD: 28/11/2026)
                        if (dataGridView1.Columns["WorkDate"] != null)
                        {
                            dataGridView1.Columns["WorkDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                        // Định dạng số công (VD: 1.0 hoặc 0.5)
                        if (dataGridView1.Columns["WorkDayUnit"] != null)
                        {
                            dataGridView1.Columns["WorkDayUnit"].DefaultCellStyle.Format = "0.##";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void refreshData()
        {
            displayData();
        }

        private void log_synchronizeBtn_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_SyncDailyAttendances", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Nếu không truyền tham số @FromDate và @ToDate, thủ tục sẽ tự động đồng bộ ngày hôm nay.
                        // Nếu bạn có 2 ô DateTimePicker trên Form (ví dụ dtpFromDate và dtpToDate), bỏ comment 2 dòng dưới:
                        // cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                        // cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Successfully synchronize", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

                // Gọi lại hàm hiển thị nếu cần làm mới bảng dữ liệu ngay sau khi đóng kết nối
                refreshData();
            }
        }
    }
}

