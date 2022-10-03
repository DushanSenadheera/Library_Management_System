using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class deleteAccount : Form
    {
        public deleteAccount()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            userProfile user = new userProfile();
            user.Show();    
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string del = "Delete From [user] Where email = '"+txtEmail.Text+ "' AND password = '" + txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            try
            {
                if (adminPassword.Text == "")
                {
                    MessageBox.Show("Can't Delete Account Without Admin Confirmation");
                }
                else if (txtEmail.Text=="" || txtPassword.Text=="")
                {
                    MessageBox.Show("Please Enter your Credentials");
                }
                else if (adminPassword.Text=="admin")
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted Successfully");
                    login log = new login();
                    log.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong, Please Check Again");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
