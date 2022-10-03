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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From [user] Where email='"+ txtEmail.Text+"' AND password='"+ txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                if (txtEmail.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Valid User Credentials");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Login Successfull");
                    conn.Close();
                    borrowBooks brbks = new borrowBooks();
                    brbks.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminLogin admin = new adminLogin();
            admin.Show();
            this.Hide();
        }
    }
}
