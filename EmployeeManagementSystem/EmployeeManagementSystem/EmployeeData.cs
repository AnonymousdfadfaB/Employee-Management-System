using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    class EmployeeData
    {

        public string EmployeeCode { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public string Phone { set; get; }
        public string Position { set; get; }
        public string Status { set; get; }
        public decimal Salary { set; get; } // Đổi sang decimal để khớp với DECIMAL(18,2)
        public byte[] Avatar { set; get; }




        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
    

        public List<EmployeeData> employeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if(connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM Employees";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeData ed = new EmployeeData();
                            ed.EmployeeCode = reader["EmployeeCode"].ToString();
                            ed.Name = reader["FullName"].ToString();
                            ed.Gender = reader["Gender"].ToString();
                            ed.Phone = reader["PhoneNumber"].ToString();
                            ed.Position = reader["Position"].ToString();
                            ed.Status = reader["Status"].ToString();

                            // Đọc cột Salary kiểu decimal an toàn
                            ed.Salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0;

                            // Đọc cột Avatar kiểu VARBINARY(MAX)
                            if (reader["Avatar"] != DBNull.Value)
                            {
                                ed.Avatar = (byte[])reader["Avatar"];
                            }
                            else
                            {
                                ed.Avatar = null;
                            }

                            listdata.Add(ed);
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }

        public List<EmployeeData> salaryEmployeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeData ed = new EmployeeData();
                            ed.EmployeeCode = reader["EmployeeCode"].ToString();
                            ed.Name = reader["full_name"].ToString();
                            ed.Position = reader["position"].ToString();
                            ed.Salary = (int)reader["salary"];

                            listdata.Add(ed);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }
    }
}
