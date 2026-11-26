using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    public partial class Salary : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

        public Salary()
        {
            InitializeComponent();


        }


        


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void salary_caculateBtn_Click(object sender, EventArgs e)
        {

            // 1. Kiểm tra đầu vào Month và Year
            if (!int.TryParse(salary_Month.Text.Trim(), out int month) || month < 1 || month > 12)
            {
                MessageBox.Show("Tháng không hợp lệ! Vui lòng nhập số từ 1 đến 12.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                salary_Month.Focus();
                return;
            }

            if (!int.TryParse(salary_Year.Text.Trim(), out int year) || year < 2000 || year > 2100)
            {
                MessageBox.Show("Năm không hợp lệ! Vui lòng nhập năm hợp lệ (VD: 2026).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                salary_Year.Focus();
                return;
            }

            // 2. Lấy tổng số ngày của tháng đó (VD: tháng 2 năm 2026 = 28 ngày, tháng 11 = 30 ngày)
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Tạo bảng tạm (DataTable) để chứa kết quả sau khi duyệt từng nhân viên
            DataTable dtSalaryResult = new DataTable();
            dtSalaryResult.Columns.Add("Employee Code", typeof(string));
            dtSalaryResult.Columns.Add("Full Name", typeof(string));
            dtSalaryResult.Columns.Add("Position", typeof(string));
            dtSalaryResult.Columns.Add("Base Salary", typeof(decimal));
            dtSalaryResult.Columns.Add("Work Days", typeof(double));
            dtSalaryResult.Columns.Add("Total Days in Month", typeof(int));
            dtSalaryResult.Columns.Add("Bonus", typeof(decimal));
            dtSalaryResult.Columns.Add("Net Salary", typeof(decimal));

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // 3. Lấy danh sách toàn bộ nhân viên (hoặc chỉ nhân viên đang Active)
                DataTable dtEmployees = new DataTable();
                string empQuery = "SELECT EmployeeID, EmployeeCode, FullName, Position, Salary FROM Employees";
                using (SqlDataAdapter adapter = new SqlDataAdapter(empQuery, connect))
                {
                    adapter.Fill(dtEmployees);
                }

                // 4. Duyệt qua từng nhân viên một để tính lương
                foreach (DataRow empRow in dtEmployees.Rows)
                {
                    int empId = Convert.ToInt32(empRow["EmployeeID"]);
                    string empCode = empRow["EmployeeCode"].ToString();
                    string fullName = empRow["FullName"].ToString();
                    string position = empRow["Position"].ToString();
                    decimal baseSalary = Convert.ToDecimal(empRow["Salary"]);

                    // 4a. Lấy tổng WorkDayUnit của nhân viên này trong tháng/năm từ bảng DailyAttendances
                    double totalWorkDays = 0;
                    string attQuery = "SELECT ISNULL(SUM(WorkDayUnit), 0) FROM DailyAttendances WHERE EmployeeID = @empId AND MONTH(WorkDate) = @month AND YEAR(WorkDate) = @year";
                    using (SqlCommand cmdAtt = new SqlCommand(attQuery, connect))
                    {
                        cmdAtt.Parameters.AddWithValue("@empId", empId);
                        cmdAtt.Parameters.AddWithValue("@month", month);
                        cmdAtt.Parameters.AddWithValue("@year", year);
                        totalWorkDays = Convert.ToDouble(cmdAtt.ExecuteScalar());
                    }

                    // 4b. Lấy tổng Bonus của nhân viên này trong tháng/năm từ bảng Bonuses (nếu có)
                    decimal totalBonus = 0;
                    string bonusQuery = "SELECT ISNULL(SUM(Amount), 0) FROM Bonuses WHERE EmployeeID = @empId AND Month = @month AND Year = @year";
                    using (SqlCommand cmdBonus = new SqlCommand(bonusQuery, connect))
                    {
                        cmdBonus.Parameters.AddWithValue("@empId", empId);
                        cmdBonus.Parameters.AddWithValue("@month", month);
                        cmdBonus.Parameters.AddWithValue("@year", year);
                        totalBonus = Convert.ToDecimal(cmdBonus.ExecuteScalar());
                    }

                    // 4c. Tính lương theo đúng công thức của bạn: Salary * (WorkDayUnit / Tổng số ngày trong tháng) + Bonus
                    decimal netSalary = (baseSalary * (decimal)(totalWorkDays / daysInMonth)) + totalBonus;
                    netSalary = Math.Round(netSalary, 2); // Làm tròn 2 chữ số thập phân

                    // 4d. Thêm dòng kết quả của nhân viên này vào bảng tạm
                    dtSalaryResult.Rows.Add(empCode, fullName, position, baseSalary, totalWorkDays, daysInMonth, totalBonus, netSalary);
                }

                // 5. Đổ dữ liệu lên DataGridView và định dạng số tiền cho đẹp
                dataGridView1.DataSource = dtSalaryResult;
                dataGridView1.Columns["Base Salary"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["Bonus"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["Net Salary"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }
   
    }
}
