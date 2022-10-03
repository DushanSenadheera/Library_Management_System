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
    public partial class updateBooks : Form
    {
        public updateBooks()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string bookID = txtID.Text;
            string ISBN = txtISBN.Text;
            string name = txtName.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Update [books] Set ISBN='" + txtISBN.Text + "',name='" + txtName.Text + "',author='" + txtAuthor.Text + "',publisher='" + txtPublisher.Text + "',price='" + txtPrice.Text + "',quantity='" + txtQuantity.Text + "' Where bookID='"+txtID.Text+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if(txtISBN.Text=="" || txtName.Text=="" || txtAuthor.Text=="" || txtPublisher.Text=="" || txtPrice.Text=="" || txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Check Your Book ID");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book details updated Successfully");
                    conn.Close();
                    addBooks adbk = new addBooks();
                    adbk.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From [books] Where bookID='"+txtID.Text+"'";
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

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            addBooks adbk = new addBooks();
            adbk.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            bookList bklst = new bookList();
            bklst.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            deleteBooks delbk = new deleteBooks();
            delbk.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {
            deleteBooks delbk = new deleteBooks();
            delbk.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
