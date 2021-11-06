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

    public partial class issue_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3ULN8UAV\SQLEXPRESS;Initial Catalog=Library_Management;Integrated Security=True;Pooling=False");

        public issue_books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info where student_roll_number= '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("This Roll Number not found!");
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {                    
                    studentname.Text = dr["student_name"].ToString();
                    studentbarach.Text = dr["student_branch"].ToString();
                    studentsem.Text = dr["student_sem"].ToString();
                    stucontactnumber.Text = dr["contact_number"].ToString();
                    stuemailid.Text = dr["student_email"].ToString();
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void issue_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void bookname_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;

            if (e.KeyCode != Keys.Enter)
            {
                listBox1.Items.Clear();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_name like('%"+bookname.Text+"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());


                if (count > 0)
                {
                    listBox1.Visible = true;
                    foreach(DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["books_name"].ToString());
                    }
                }



            }
        }

        private void bookname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bookname.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            bookname.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

                int books_qty = 0;
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from books_info where Books_name = '"+ bookname.Text +"'";
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                foreach(DataRow dr2 in dt2.Rows)
                {
                    books_qty = Convert.ToInt32(dr2["Available_quantity"].ToString());
                }

                if (books_qty > 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into issue_books values('" + textBox1.Text + "','" + studentname.Text + "','" + studentbarach.Text + "','" + studentsem.Text + "','" + stucontactnumber.Text + "','" + stuemailid.Text + "','" + bookname.Text + "','" + dateTimePicker1.Value.ToString() + "','')";
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update books_info set  Available_quantity = Available_quantity-1 where books_name = '" + bookname.Text + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Book Issued Successfully!");
                }
                else
                {
                    MessageBox.Show("Sorry, Books Not Available!");
                }          
         

        }
    }
}
