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
    public partial class userProfile : Form
    {
        public userProfile()
        {
            InitializeComponent();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            searchBooks sebks = new searchBooks();
            sebks.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            borrowBooks brbks = new borrowBooks();
            brbks.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            returnBooks rebks = new returnBooks();
            rebks.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From [user] Where email='" + txtEmail.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if(txtEmail.Text == "")
                {
                    MessageBox.Show("Please Enter Your Valid Email");
                }
                else
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    txtEmail.Text = sdr["email"].ToString();
                    txtFName.Text = sdr["firstName"].ToString();
                    txtLName.Text = sdr["lastName"].ToString();
                    txtPassword.Text = sdr["password"].ToString();
                    txtMobile.Text = sdr["mobile"].ToString();
                    MessageBox.Show("User Profile Details Available");
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string mobile = txtMobile.Text;
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Update [user] Set mobile='" + mobile + "',password='"+password+"' Where email=email";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if (txtEmail.Text=="")
                {
                    MessageBox.Show("Please Enter Your Email");
                }
                else
                {
                    if(fName=="" || lName=="" || email=="" || password=="" || mobile == "")
                    {
                        MessageBox.Show("Please cheack your Email");
                    }
                    else
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User Profile updated Successfully");
                    }
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text=="")
            {
                MessageBox.Show("Please enter valid Email");
            }
            else
            {
                if (txtEmail.Text=="" || txtFName.Text=="" || txtLName.Text=="" || txtMobile.Text=="" || txtPassword.Text=="")
                {
                    MessageBox.Show("Please check your Email");
                }
                else
                {
                    deleteAccount del = new deleteAccount();
                    del.Show();
                    this.Hide();
                }
            }
        }
    }
}
