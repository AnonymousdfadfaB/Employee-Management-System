using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?"
                , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            addEmployee1.Visible = false;
            salary1.Visible = false;
            addBonus1.Visible = false;
            log1.Visible = false;
            rawLog1.Visible = false;
            dashboard1.RefreshData();

    

        }

        private void addEmployee_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addEmployee1.Visible = true;
            salary1.Visible = false;
            addBonus1.Visible = false;
            log1.Visible = false;
            rawLog1.Visible = false;
            addEmployee1.RefreshData();

        }

        private void salary_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addEmployee1.Visible = false;
            addBonus1.Visible = false;
            salary1.Visible = true;
            log1.Visible = false;
            rawLog1.Visible = false;
            Salary salaryForm = salary1 as Salary;
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void bonus_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addEmployee1.Visible = false;
            addBonus1.Visible =true;
            salary1.Visible = false;
            log1.Visible = false;
            rawLog1.Visible = false;
            addBonus1.refreshData();
            //addBonus1.RefreshData();

        }

        private void log_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addEmployee1.Visible = false;
            addBonus1.Visible = false;
            salary1.Visible = false;
            log1.Visible = true;
            rawLog1.Visible = false;
            log1.refreshData();
        }

        private void rawLog1_Load(object sender, EventArgs e)
        {

        }

        private void rawLog_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addEmployee1.Visible = false;
            addBonus1.Visible = false;
            salary1.Visible = false;
            log1.Visible = false;
            rawLog1.Visible = true;
            rawLog1.refreshData();
        }
    }
}


// THATS IT FOR THIS VIDEO, THANKS FOR WATCHING!
// SUBSCRIBE FOR MORE C# PROJECT TUTORIALS
// THANKS : ) 