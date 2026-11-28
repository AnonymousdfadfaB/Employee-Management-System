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
    public partial class Dashboard : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        public Dashboard()
        {
            InitializeComponent();
            displayData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayData();
        }
        public void displayData()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = @"
                SELECT 
                    COUNT(EmployeeID) AS TotalEmployees,
                    COUNT(CASE WHEN Status = 'Active' THEN 1 END) AS ActiveEmployees,
                    COUNT(CASE WHEN Status = 'Inactive' THEN 1 END) AS InactiveEmployees
                FROM Employees";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dashboard_TE.Text = reader["TotalEmployees"].ToString();
                                dashboard_AE.Text = reader["ActiveEmployees"].ToString();
                                dashboard_IE.Text = reader["InactiveEmployees"].ToString();
                            }
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

    }
}
