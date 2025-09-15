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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smart_Stock_Manager
{
    public partial class Product : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\HP\Desktop\NET_M6_Project\Smart Stock Manager\SSM_DATABASE.mdf"";Integrated Security=True");
        public Product()
        {
            InitializeComponent();
        }
    

        private void Product_Load(object sender, EventArgs e)
        {
            display_data();
        }
        public void display_data()
        { 
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from ProductTable";
            cmd.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into ProductTable values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

            cmd.ExecuteNonQuery();
            con.Close();

            display_data();
            MessageBox.Show("Record Insert Successfully 👍");
            cleartext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update ProductTable set Name='" + textBox2.Text + "'where ProductID='" + textBox1.Text + "'update ProductTable set Category= '" + comboBox1.Text + "'where ProductID='" + textBox1.Text + "'update ProductTable set Price= '" + textBox4.Text + "'where ProductID='" + textBox1.Text + "'update ProductTable set Quantity= '" + textBox5.Text + "'where ProductID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully!!!");
            cleartext();
            
        }

        private void button3_Click(object sender, EventArgs e)
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
                cmd.CommandText = "delete from ProductTable where ProductID='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                display_data();
                MessageBox.Show("Record Deleted Successfully 👍");
                cleartext();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cleartext();
            textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    comboBox1.Text = row.Cells[2].Value.ToString();
                    textBox4.Text = row.Cells[3].Value.ToString();
                    textBox5.Text = row.Cells[4].Value.ToString();
                }
                textBox1.Enabled= false;
               

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
 
        }
        private void cleartext()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
            textBox1.Enabled = true;
        }

    }
}
