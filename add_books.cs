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

namespace Mini_project
{
    public partial class add_books : Form

    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3ULN8UAV\SQLEXPRESS;Initial Catalog=Library_Management;Integrated Security=True;Pooling=False");

        public add_books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values ('"+textBox1.Text +"','"+ textBox2.Text + "','"+ textBox3.Text + "','"+ dateTimePicker1.Text + "','"+ textBox5.Text + "','"+textBox6.Text+"','"+ textBox6.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            // for hiding all values
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";            
            textBox5.Text = "";
            textBox6.Text = "";

            MessageBox.Show("New Book has been Inserted Successfully!");



            

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
