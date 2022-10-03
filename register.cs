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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string password = txtPassword.Text;
            string mobile = txtMobile.Text;
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "INSERT INTO [user] (firstName,lastName,email,password,mobile) VALUES('" + fName + "','" + lName + "','" + email + "','" + password + "','" + mobile + "')"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if ( email=="" || fName=="" || lName=="" || password=="" || mobile=="")
                {
                    MessageBox.Show("Please Fill All Required Details");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully");
                    conn.Close();
                    login log = new login();
                    log.Show();
                    this.Hide();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
