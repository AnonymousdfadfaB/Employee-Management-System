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

namespace EmployeeManagementSystem
{
    public partial class rawLog : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

        public rawLog()
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

                    // Kết nối bảng AttendanceLogs với Employees để lấy Mã và Tên nhân viên
                    // Sắp xếp thời gian quẹt thẻ mới nhất lên đầu (ORDER BY a.CheckTime DESC)
                    string selectData = @"
                SELECT 
                    a.LogID,
                    e.EmployeeCode,
                    e.FullName,
                    a.CheckTime,
                    a.DeviceID
                FROM AttendanceLogs a
                INNER JOIN Employees e ON a.EmployeeID = e.EmployeeID
                ORDER BY a.CheckTime DESC, e.EmployeeCode ASC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Căn chỉnh giao diện bảng đồng bộ với các form khác
                        dataGridView1.RowTemplate.Height = 35;
                        dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.DataSource = table;

                        // Định dạng cột ngày giờ quẹt thẻ (VD: 28/11/2026 07:25:30)
                        if (dataGridView1.Columns["CheckTime"] != null)
                        {
                            dataGridView1.Columns["CheckTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
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

    }
}
