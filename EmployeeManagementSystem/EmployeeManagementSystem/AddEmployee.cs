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
using System.IO;

namespace EmployeeManagementSystem
{
    public partial class AddEmployee : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

        public AddEmployee()
        {
            InitializeComponent();

            // TO DISPLAY THE DATA FROM DATABASE TO YOUR DATA GRID VIEW
            displayEmployeeData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayEmployeeData();
        }

        public void displayEmployeeData()
        {
            EmployeeData ed = new EmployeeData();
            List<EmployeeData> listData = ed.employeeListData();
            dataGridView1.RowTemplate.Height = 90;
            // 2. Cấu hình cột chứa ảnh (thay "Avatar" bằng đúng tên property trong class của bạn)
            if (dataGridView1.Columns["Avatar"] is DataGridViewImageColumn imgCol)
            {
                // Zoom giúp giữ nguyên tỷ lệ 400x600, không bao giờ làm méo ảnh
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

                // Chiều rộng cột 60px khớp tỷ lệ 2:3 với Row Height 90px
                imgCol.Width = 60;

                // Tạo khoảng thở (padding) xung quanh ảnh cho thoáng mắt
                imgCol.DefaultCellStyle.Padding = new Padding(4);

                // Màu nền khi ô trống hoặc phần viền dư của tỷ lệ Zoom
                imgCol.DefaultCellStyle.NullValue = null;
            }

            // 3. Căn giữa chữ cho các cột thông tin còn lại để cân đối với ảnh cao
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.DataSource = listData;
        }

        private void addEmployee_addBtn_Click(object sender, EventArgs e)
        {
            if(addEmployee_code.Text == ""
                || addEmployee_fullName.Text == ""
                || addEmployee_gender.Text == ""
                || addEmployee_phoneNum.Text == ""
                || addEmployee_position.Text == ""
                || addEmployee_status.Text == ""
                || addEmployee_picture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkEmCode = "SELECT COUNT(*) FROM Employees WHERE EmployeeCode = @emCode";

                        using(SqlCommand checkEm = new SqlCommand(checkEmCode, connect))
                        {
                            checkEm.Parameters.AddWithValue("@emCode", addEmployee_code.Text.Trim());
                            int count = (int)checkEm.ExecuteScalar();

                            if(count >= 1)
                            {
                                MessageBox.Show(addEmployee_code.Text.Trim() + " is already taken"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO employees " +
                                    "(EmployeeCode, Fullname, Gender, PhoneNumber" +
                                    ", Position, Salary, Avatar) " +
                                    "VALUES(@employeeCode, @fullName, @gender, @contactNum" +
                                    ", @position, @salary, @image )";

                                byte[] imageBytes = null;
                                if (!string.IsNullOrEmpty(addEmployee_picture.ImageLocation))
                                {
                                    imageBytes = File.ReadAllBytes(addEmployee_picture.ImageLocation);
                                }

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@employeeCode", addEmployee_code.Text.Trim());
                                    cmd.Parameters.AddWithValue("@fullName", addEmployee_fullName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@gender", addEmployee_gender.Text.Trim());
                                    cmd.Parameters.AddWithValue("@contactNum", addEmployee_phoneNum.Text.Trim());
                                    cmd.Parameters.AddWithValue("@position", addEmployee_position.Text.Trim());

                                    decimal salaryValue = 0;

                                    // 2. Nếu người dùng có nhập chữ vào TextBox thì kiểm tra và ép kiểu sang decimal
                                    if (!string.IsNullOrWhiteSpace(addEmployee_salary.Text))
                                    {
                                        // decimal.TryParse giúp kiểm tra người dùng có nhập đúng định dạng số hay không (tránh crash app)
                                        if (!decimal.TryParse(addEmployee_salary.Text.Trim(), out salaryValue))
                                        {
                                            MessageBox.Show("Mức lương không hợp lệ! Vui lòng chỉ nhập số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return; // Dừng lại, không chạy lệnh SQL nữa
                                        }
                                    }

                                    // 3. Truyền biến kiểu decimal (salaryValue) vào tham số SQL
                                    cmd.Parameters.AddWithValue("@salary", salaryValue);

                                    // 2. Truyền mảng byte[] vào tham số @image dưới dạng VarBinary
                                    SqlParameter imageParam = new SqlParameter("@image", SqlDbType.VarBinary, -1);
                                    imageParam.Value = (object)imageBytes ?? DBNull.Value;
                                    cmd.Parameters.Add(imageParam);
                                    cmd.ExecuteNonQuery();

                                    displayEmployeeData();

                                    MessageBox.Show("Added successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
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

        private void addEmployee_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addEmployee_picture.ImageLocation = imagePath;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                addEmployee_code.Text = row.Cells[1].Value.ToString();
                addEmployee_fullName.Text = row.Cells[2].Value.ToString();
                addEmployee_gender.Text = row.Cells[3].Value.ToString();
                addEmployee_phoneNum.Text = row.Cells[4].Value.ToString();
                addEmployee_position.Text = row.Cells[5].Value.ToString();

                string imagePath = row.Cells[6].Value.ToString();

                if(imagePath != null)
                {
                    addEmployee_picture.Image = Image.FromFile(imagePath);
                }
                else
                {
                    addEmployee_picture.Image = null;
                }

                addEmployee_status.Text = row.Cells[8].Value.ToString();
            }
        }

        public void clearFields()
        {
            addEmployee_code.Text = "";
            addEmployee_fullName.Text = "";
            addEmployee_gender.SelectedIndex = -1;
            addEmployee_phoneNum.Text = "";
            addEmployee_position.SelectedIndex = -1;
            addEmployee_status.SelectedIndex = -1;
            addEmployee_picture.Image = null;
        }

        private void addEmployee_updateBtn_Click(object sender, EventArgs e)
        {
            if (addEmployee_code.Text == ""
                || addEmployee_fullName.Text == ""
                || addEmployee_gender.Text == ""
                || addEmployee_phoneNum.Text == ""
                || addEmployee_position.Text == ""
                || addEmployee_status.Text == ""
                || addEmployee_picture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " +
                    "Employee ID: " + addEmployee_code.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE employees SET full_name = @fullName" +
                            ", gender = @gender, contact_number = @contactNum" +
                            ", position = @position, update_date = @updateDate, status = @status " +
                            "WHERE employee_id = @employeeID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@fullName", addEmployee_fullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@gender", addEmployee_gender.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", addEmployee_phoneNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@position", addEmployee_position.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            cmd.Parameters.AddWithValue("@status", addEmployee_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@employeeID", addEmployee_code.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayEmployeeData();

                            MessageBox.Show("Update successfully!"
                                , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            clearFields();
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
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void addEmployee_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addEmployee_deleteBtn_Click(object sender, EventArgs e)
        {
            if (addEmployee_code.Text == ""
                || addEmployee_fullName.Text == ""
                || addEmployee_gender.Text == ""
                || addEmployee_phoneNum.Text == ""
                || addEmployee_position.Text == ""
                || addEmployee_status.Text == ""
                || addEmployee_picture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE " +
                    "Employee ID: " + addEmployee_code.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE employees SET delete_date = @deleteDate " +
                            "WHERE employee_id = @employeeID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@employeeID", addEmployee_code.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayEmployeeData();

                            MessageBox.Show("Update successfully!"
                                , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
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
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addEmployee_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void addEmployee_picture_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Để trống vì bạn đã xử lý ở sự kiện dataGridView1_CellClick
        }
    }
}
