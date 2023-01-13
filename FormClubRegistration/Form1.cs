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

namespace FormClubRegistration
{
    public partial class Form1 : Form
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=COMPLAB1-12;Initial Catalog=ClubRegistrtionDB;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            /* Data insert function */

            conn.Open();
            string check = @"(SELECT COUNT (*) FROM table_club WHERE student_id = '" + textBox1.Text + "')";
            string sqlQuery = "INSERT INTO table_club (student_ID, first_name, middle_name, last_name, age, gender, program) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "')";
            SqlCommand cmd2 = new SqlCommand(check, conn);
            cmd = new SqlCommand(sqlQuery, conn);
            int count = (int)cmd2.ExecuteScalar();
            conn.Close();

            if (count > 0)
            {
                MessageBox.Show("Data Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();

                textBox1.Focus();
            }
            else
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Registered Successfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database (Connection String)
            String ConnectionString = "Data Source=COMPLAB1-12;Initial Catalog=ClubRegistrtionDB;Integrated Security=True";

            //2. establish connection (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection (c# sqlconnection open)
            con.Open();

            //4. prepare query
            string Query = "SELECT * FROM table_club";
            SqlCommand cmd = new SqlCommand(Query, con);

            //5. execute query (c# sqlcommand class)
            var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["student_id"], reader["first_name"], reader["middle_name"], reader["last_name"], reader["age"], reader["gender"], reader["program"]);
            }

            //6. close connection (c# sqlcommand close)
            con.Close();
        }
    }
}
