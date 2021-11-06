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
    public partial class login : Form
    {
        // Create connection with the Database
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3ULN8UAV\SQLEXPRESS;Initial Catalog=Library_Management;Integrated Security=True;Pooling=False");
        int count = 0;   
        public login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from library_person where username='"+ textBox1.Text +"' and password= '"+ textBox2.Text +"'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32( dt.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Username And Password Dose not match");
            }
            else
            {
                this.Hide();
                MDI_USER mu = new MDI_USER();
                mu.Show();
            }
                
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
