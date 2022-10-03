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
    public partial class deleteBooks : Form
    {
        public deleteBooks()
        {
            InitializeComponent();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            updateBooks upbk = new updateBooks();
            upbk.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            addBooks adbk = new addBooks();
            adbk.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            bookList bklst = new bookList();
            bklst.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string del = "Delete From [books] Where bookID='" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(del, conn);
            try
            {
                if (txtISBN.Text == "" || txtName.Text == "" || txtAuthor.Text == "" || txtPublisher.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Check Your Book ID");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book deleted successfullly");
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From [books] Where bookID='" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if (txtID.Text=="")
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
                    txtPrice.Text = sdr["price"].ToString();
                    txtQuantity.Text = sdr["quantity"].ToString();
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

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
