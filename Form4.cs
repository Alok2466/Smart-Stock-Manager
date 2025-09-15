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
using System.Xml.Linq;

namespace Smart_Stock_Manager
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\HP\Desktop\NET_M6_Project\Smart Stock Manager\SSM_DATABASE.mdf"";Integrated Security=True");

        private void display_data()
        {
            con.Open();
            SqlCommand CMD = con.CreateCommand();
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = "Select * from SuppliersTable";
            CMD.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(CMD);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            con.Close();
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into SuppliersTable values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Record Added Successfully 👍");
            Cleartext();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand CMD = con.CreateCommand();
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = "update SuppliersTable set Name= '" + textBox2.Text + "'where SupplierID='" + textBox1.Text + "'update SuppliersTable set Contact= '" + textBox3.Text + "'where SupplierID='" + textBox1.Text + "'update SuppliersTable set Email= '" + textBox4.Text + "'where SupplierID='" + textBox1.Text + "'";
            CMD.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Record Updated Successfully!!");
            Cleartext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No Record to delete!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from SuppliersTable where SupplierID='" + textBox1.Text + "'";

                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Record delete successfully!!!");
                Cleartext();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cleartext();
            textBox1.Enabled = true;
            textBox1.Focus();
        }
        private void Cleartext()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
            textBox1.Enabled = false;



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            display_data();
        }
    }
}
