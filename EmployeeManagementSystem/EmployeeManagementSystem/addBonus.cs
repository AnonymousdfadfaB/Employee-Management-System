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
    public partial class addBonus : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        public addBonus()
        {
            InitializeComponent();
        }

        private void addBonus_addBtn_Click(object sender, EventArgs e)
        {
            if (addBonus_EmployeeCode.Text == ""
               || addBonus_EmployeeFullName.Text == ""
               || addBonus_Amount.Text == ""
               || addBonus_Year.Text == ""
               || addBonus_Month.Text == ""
               || addBonus_Reason.Text == "")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        //DateTime today = DateTime.Today;
                        string insertData = @"
                            INSERT INTO Bonuses (EmployeeID, Month, Year, Amount, Reason)
                            SELECT EmployeeID, @month, @year, @amount, @reason
                            FROM Employees
                            WHERE EmployeeCode = @employeeCode";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            // 1. Khởi tạo giá trị mặc định là 0
                            int monthValue = 0;
                            int yearValue = 0;
                            decimal amountValue = 0;

                            // 2. Lấy giá trị từ TextBox (nếu nhập sai hoặc bỏ trống, TryParse tự giữ nguyên giá trị 0)
                            int.TryParse(addBonus_Month.Text.Trim(), out monthValue);
                            int.TryParse(addBonus_Year.Text.Trim(), out yearValue);
                            decimal.TryParse(addBonus_Amount.Text.Trim(), out amountValue);
                            cmd.Parameters.AddWithValue("@employeeCode", addBonus_EmployeeCode.Text.Trim());
                            cmd.Parameters.AddWithValue("@month", monthValue);
                            cmd.Parameters.AddWithValue("@year", yearValue);
                            cmd.Parameters.AddWithValue("@amount", amountValue);
                            cmd.Parameters.AddWithValue("@reason", addBonus_Reason.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Add succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Gọi hàm load lại DataGridView tại đây
                            }
                            else
                            {
                                // rowsAffected == 0 nghĩa là không tìm thấy EmployeeCode nào khớp trong bảng Employees
                                MessageBox.Show("Not Found Employee " + addBonus_EmployeeCode.Text.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
