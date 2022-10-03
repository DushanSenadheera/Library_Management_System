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
    public partial class searchBooks : Form
    {
        public searchBooks()
        {
            InitializeComponent();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            borrowBooks brbks = new borrowBooks();
            brbks.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library Management System\Library Management System\LibraryManagementSystemDB.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "Select name,author,publisher From [books] Where name = '" + txtSearch.Text + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(qry, conString);
            DataSet set = new DataSet();

            adapter.Fill(set, "books");
            DGV2.DataSource = set.Tables["books"];
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            userProfile user = new userProfile();
            user.Show();
            this.Hide();
        }
    }
}
