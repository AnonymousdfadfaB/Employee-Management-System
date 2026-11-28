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
            displayBonusData();
        }

        private void addBonus_addBtn_Click(object sender, EventArgs e)
        {
            if (addBonus_BonusCode.Text == ""
                || addBonus_EmployeeCode.Text == ""
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
                            INSERT INTO Bonuses (BonusCode, EmployeeID, Month, Year, Amount, Reason)
                            SELECT @bonusCode, EmployeeID, @month, @year, @amount, @reason
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
                            cmd.Parameters.AddWithValue("@bonusCode", addBonus_BonusCode.Text.Trim());
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
                                connect.Close();
                                refreshData();
                                clearFields();

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

        private void addBonus_deleteBtn_Click(object sender, EventArgs e)
        {
            if (addBonus_BonusCode.Text == "")
            {
                MessageBox.Show("Please fill bonus code"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE Bonus Code: "
                    + addBonus_BonusCode.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM Bonuses WHERE BonusCode = @bonusCode";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@bonusCode", addBonus_BonusCode.Text.Trim());

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Delete successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Gọi hàm load lại DataGridView tại đây
                                    connect.Close();
                                    refreshData();
                                    clearFields();

                                }
                                else
                                {
                                    MessageBox.Show("Not Found Bonus Code " + addBonus_BonusCode.Text.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void addBonus_updateBtn_Click(object sender, EventArgs e)
        {
            if (addBonus_BonusCode.Text == ""
                || addBonus_EmployeeCode.Text == ""
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
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Bonus Code: "
                    + addBonus_BonusCode.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = @"
                        UPDATE Bonuses 
                        SET EmployeeID = (SELECT EmployeeID FROM Employees WHERE EmployeeCode = @employeeCode),
                            Month = @month,
                            Year = @year,
                            Amount = @amount,
                            Reason = @reason
                        WHERE BonusCode = @bonusCode 
                          AND EXISTS (SELECT 1 FROM Employees WHERE EmployeeCode = @employeeCode)";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                int monthValue = 0;
                                int yearValue = 0;
                                decimal amountValue = 0;

                                int.TryParse(addBonus_Month.Text.Trim(), out monthValue);
                                int.TryParse(addBonus_Year.Text.Trim(), out yearValue);
                                decimal.TryParse(addBonus_Amount.Text.Trim(), out amountValue);

                                cmd.Parameters.AddWithValue("@bonusCode", addBonus_BonusCode.Text.Trim());
                                cmd.Parameters.AddWithValue("@employeeCode", addBonus_EmployeeCode.Text.Trim());
                                cmd.Parameters.AddWithValue("@month", monthValue);
                                cmd.Parameters.AddWithValue("@year", yearValue);
                                cmd.Parameters.AddWithValue("@amount", amountValue);
                                cmd.Parameters.AddWithValue("@reason", addBonus_Reason.Text.Trim());

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Update successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Gọi hàm load lại DataGridView tại đây
                                    connect.Close();
                                    refreshData();
                                    clearFields();

                                }
                                else
                                {
                                    MessageBox.Show("Not Found Bonus Code or Employee Code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void addBonus_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra e.RowIndex >= 0 để tránh click vào tiêu đề cột và bỏ qua dòng trống cuối cùng (NewRow)
            if (e.RowIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Sử dụng ?.ToString() ?? "" để không bị lỗi NullReferenceException nếu ô đó trống
                addBonus_BonusCode.Text = row.Cells["BonusCode"].Value?.ToString() ?? "";
                addBonus_EmployeeCode.Text = row.Cells["EmployeeCode"].Value?.ToString() ?? "";
                addBonus_EmployeeFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                addBonus_Month.Text = row.Cells["Month"].Value?.ToString() ?? "";
                addBonus_Year.Text = row.Cells["Year"].Value?.ToString() ?? "";
                addBonus_Amount.Text = row.Cells["Amount"].Value?.ToString() ?? "0";
                addBonus_Reason.Text = row.Cells["Reason"].Value?.ToString() ?? "";
            }
        }
        public void displayBonusData()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = @"
                SELECT b.BonusCode, e.EmployeeCode, e.FullName, b.Month, b.Year, b.Amount, b.Reason
                FROM Bonuses b
                INNER JOIN Employees e ON b.EmployeeID = e.EmployeeID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Căn chỉnh chiều cao dòng và căn lề chữ 
                        dataGridView1.RowTemplate.Height = 35;
                        dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                        // Định dạng cột tiền tệ (Amount) có dấu phẩy ngăn cách hàng nghìn (VD: 2,000,000)
                        if (dataGridView1.Columns["Amount"] != null)
                        {
                            dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "N0";
                        }
                        dataGridView1.DataSource = table;

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
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayBonusData();
        }

        public void clearFields()
        {
            addBonus_BonusCode.Text = "";
            addBonus_EmployeeCode.Text = "";
            addBonus_EmployeeFullName.Text = "";
            addBonus_Amount.Text = "";
            addBonus_Year.Text = "";
            addBonus_Month.Text = "";
            addBonus_Reason.Text = "";
        }

    }
}
