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
    public partial class returnBooks : Form
    {
        public returnBooks()
        {
            InitializeComponent();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            searchBooks srbks = new searchBooks();
            srbks.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            borrowBooks brbks = new borrowBooks();
            brbks.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            userProfile user = new userProfile();
            user.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From [books] Where bookID='" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if (txtEmail.Text=="")
                {
                    MessageBox.Show("Please Enter Your Email");
                }
                else if (txtID.Text == "")
                {
                    MessageBox.Show("Please Enter Your Book ID");
                }
                else
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    txtISBN.Text = sdr["ISBN"].ToString();
                    txtName.Text = sdr["name"].ToString();
                    txtAuthor.Text = sdr["author"].ToString();
                    txtPublisher.Text = sdr["publisher"].ToString();
                    MessageBox.Show("Book is available");
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
            string email = txtEmail.Text;
            string bookID = txtID.Text;
            string ISBN = txtISBN.Text;
            string name = txtName.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;


            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "INSERT INTO [returnBooks] (email,bookID,ISBN,name,author,publisher,date) VALUES('" + email + "','" + bookID + "','" + ISBN + "','" + name + "','" + author + "','" + publisher + "','" + txtDate.Text + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please Enter Your Email");
                }
                else if (txtID.Text == "")
                {
                    MessageBox.Show("Please Enter Your Book ID");
                }
                else if(txtISBN.Text =="" || txtName.Text=="" || txtAuthor.Text=="" || txtPublisher.Text=="")
                {
                    MessageBox.Show("Please check your Book ID");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Returned Successfully");
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
            txtEmail.Text = "";
            txtID.Text = "";
            txtISBN.Text = "";
            txtName.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
        }
    }
}
