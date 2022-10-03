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
    public partial class bookList : Form
    {
        public bookList()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "Select  * From books";

            SqlDataAdapter adapter = new SqlDataAdapter(qry, conString);
            DataSet set = new DataSet();

            adapter.Fill(set, "books");
            DGV1.DataSource = set.Tables["books"];
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            addBooks adbks = new addBooks();
            adbks.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            updateBooks upbks = new updateBooks();
            upbks.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            deleteBooks delbks = new deleteBooks();
            delbks.Show();
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
