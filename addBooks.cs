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
    public partial class addBooks : Form
    {
        public addBooks()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string ISBN = txtISBN.Text;
            string name = txtName.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "INSERT INTO [books] (ISBN,name,author,publisher,price,quantity) VALUES('" + ISBN + "','" + name + "','" + author + "','" + publisher + "','" + price + "','" + quantity + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if(ISBN == "" || name =="" || author=="" || publisher=="" || price=="" || quantity == "")
                {
                    MessageBox.Show("Please fill relevent book details");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Added Successfully");
                } 
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                addBooks adbk = new addBooks();
                adbk.Show();
                this.Hide();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            updateBooks upbk = new updateBooks();
            upbk.Show();
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

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtISBN.Text = "";
            txtName.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }
    }
}
