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
            // Kiểm tra e.RowIndex >= 0 để tránh click vào tiêu đề cột và bỏ qua dòng trống cuối cùng (NewRow)
            if (e.RowIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Sử dụng ?.ToString() ?? "" để không bị lỗi NullReferenceException nếu ô đó trống
                addEmployee_code.Text = row.Cells["EmployeeCode"].Value?.ToString() ?? "";
                addEmployee_fullName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                addEmployee_gender.Text = row.Cells["Gender"].Value?.ToString() ?? "";
                addEmployee_phoneNum.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                addEmployee_position.Text = row.Cells["Position"].Value?.ToString() ?? "";
                addEmployee_status.Text = row.Cells["Status"].Value?.ToString() ?? "";
                addEmployee_salary.Text = row.Cells["Salary"].Value?.ToString() ?? "0";

                // Reset đường dẫn ảnh cũ (để tránh hiểu nhầm là người dùng vừa chọn ảnh mới khi bấm Update)
                addEmployee_picture.ImageLocation = null;

                // Xử lý hiển thị hình ảnh từ cột Avatar (VARBINARY -> byte[] -> Image)
                if (row.Cells["Avatar"].Value != null && row.Cells["Avatar"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells["Avatar"].Value;
                    if (imageBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            addEmployee_picture.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        addEmployee_picture.Image = null;
                    }
                }
                else
                {
                    addEmployee_picture.Image = null;
                }
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
            addEmployee_salary.Text = "";
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
                        if (connect.State == ConnectionState.Closed)
                            connect.Open();

                        // 1. Kiểm tra định dạng mức lương (Salary) trước khi chạy SQL
                        decimal salaryValue = 0;
                        if (!string.IsNullOrWhiteSpace(addEmployee_salary.Text))
                        {
                            if (!decimal.TryParse(addEmployee_salary.Text.Trim(), out salaryValue))
                            {
                                MessageBox.Show("Mức lương không hợp lệ! Vui lòng chỉ nhập số.",
                                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // 2. Xử lý hình ảnh (Avatar)
                        byte[] imageBytes = null;
                        bool hasNewImage = false;

                        // Nếu người dùng có chọn ảnh mới từ máy tính (ImageLocation có đường dẫn)
                        if (!string.IsNullOrEmpty(addEmployee_picture.ImageLocation) && File.Exists(addEmployee_picture.ImageLocation))
                        {
                            imageBytes = File.ReadAllBytes(addEmployee_picture.ImageLocation);
                            hasNewImage = true;
                        }

                        // 3. Xây dựng câu lệnh SQL (Chỉ cập nhật cột Avatar nếu có chọn ảnh mới)
                        string updateData = "UPDATE Employees SET FullName = @fullName, " +
                                            "Gender = @gender, PhoneNumber = @contactNum, " +
                                            "Position = @position, Status = @status, Salary = @salary " +
                                            (hasNewImage ? ", Avatar = @image " : "") +
                                            "WHERE EmployeeCode = @employeeCode";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@fullName", addEmployee_fullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@gender", addEmployee_gender.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", addEmployee_phoneNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@position", addEmployee_position.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", addEmployee_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@salary", salaryValue);
                            cmd.Parameters.AddWithValue("@employeeCode", addEmployee_code.Text.Trim());

                            if (hasNewImage)
                            {
                                SqlParameter imageParam = new SqlParameter("@image", SqlDbType.VarBinary, -1);
                                imageParam.Value = imageBytes;
                                cmd.Parameters.Add(imageParam);
                            }

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                displayEmployeeData();

                                MessageBox.Show("Update successfully!",
                                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy mã nhân viên để cập nhật!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message,
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connect.State == ConnectionState.Open)
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
            if (addEmployee_code.Text == "")
            {
                MessageBox.Show("Please fill employee code"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE " +
                    "Employee Code: " + addEmployee_code.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        if (connect.State == ConnectionState.Closed)
                            connect.Open();

                        // Dùng lệnh DELETE theo EmployeeCode
                        string deleteData = "DELETE FROM Employees WHERE EmployeeCode = @employeeCode";

                        using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                        {
                            cmd.Parameters.AddWithValue("@employeeCode", addEmployee_code.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                displayEmployeeData();

                                MessageBox.Show("Deleted successfully!",
                                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Employee Code not found!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message,
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connect.State == ConnectionState.Open)
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
