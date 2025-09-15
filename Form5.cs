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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smart_Stock_Manager
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\HP\Desktop\NET_M6_Project\Smart Stock Manager\SSM_DATABASE.mdf"";Integrated Security=True");

        public Form5()
        {
            InitializeComponent();
        }

 

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Name from ProductTable";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Name"].ToString());
            }
            con.Close();
            display_data();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Quantity from ProductTable where Name ='" + comboBox1.SelectedItem.ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox2.Text= reader["Quantity"].ToString();
            }
            con.Close();
        }
        private void display_data()
        {
            con.Open();
            SqlCommand CMD = con.CreateCommand();
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = "Select * from StockTransactionsTable";
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = comboBox1.Text;
            int CurrentStock = int.Parse(textBox2.Text);
            int EnterQuantity = int.Parse(textBox3.Text);
            string TransactionType = comboBox2.SelectedItem.ToString();
            DateTime TransactionDate = dateTimePicker1.Value;

            int newStock = CurrentStock;
            if(TransactionType == "IN")
            {
                newStock = CurrentStock + EnterQuantity;
            }
            else //if(TransactionType == "OUT")
            {
                if (CurrentStock >= EnterQuantity)
                {
                    newStock = CurrentStock - EnterQuantity;
                }
                else
                {
                    MessageBox.Show("Not enough stock Available!!!");
                }
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE ProductTable SET Quantity = '"+ newStock+"' WHERE Name ='"+Name+"'";
            cmd.ExecuteNonQuery();
            con.Close();
           
            MessageBox.Show("Quantity Update Successfully!");


            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into StockTransactionsTable values  ('" + Name + "','" + EnterQuantity + "','" + TransactionType + "','" + TransactionDate + "','" + newStock + "')";
            cmd1.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Quantity Update Successfully!");
             

        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            Cleartext();
        }
        private void Cleartext()
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1 = null;
            comboBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox2.Text = row.Cells[3].Value.ToString();
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
            }
            comboBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }
    }
}
