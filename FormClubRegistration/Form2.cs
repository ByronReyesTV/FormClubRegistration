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
    public partial class Form2 : Form
    {
        //public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JSNHHF1\SQLEXPRESS;Initial Catalog=simple_databaseDB;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        //SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database (Connection String)
            String ConnectionString = "Data Source=COMPLAB1-12;Initial Catalog=ClubRegistrtionDB;Integrated Security=True";

            //2. establish connection (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection (c# sqlconnection open)
            con.Open();

            //4. prepare query
            string studentnumber = textBox1.Text;

            string Query = "UPDATE table_club SET first_name = '" + textBox2.Text + "', middle_name = '" + textBox3.Text + "', last_name = '" + textBox4.Text + "', age = '" + textBox5.Text + "', gender = '" + comboBox1.Text + "', program = '" + comboBox2.Text + "' WHERE student_id = " + textBox1.Text;
            SqlCommand cmd = new SqlCommand(Query, con);

            //5. execute query (c# sqlcommand class)
            var reader = cmd.ExecuteNonQuery();

            MessageBox.Show("Data Updated successfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
