using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Stock_Manager
{
    public partial class Report : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\HP\Desktop\NET_M6_Project\Smart Stock Manager\SSM_DATABASE.mdf"";Integrated Security=True");
        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM ProductTable", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView1.DataSource = dt4;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM ProductTable WHERE Quantity < 5", con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            dataGridView1.DataSource = dt5;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da6 = new SqlDataAdapter("SELECT * FROM StockTransactionsTable", con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            dataGridView1.DataSource = dt6;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}
