using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_project
{
    public partial class MDI_USER : Form
    {
        private int childFormNumber = 0;

        public MDI_USER()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
           add_books ab = new add_books();
           ab.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_books vb = new view_books();
            vb.Show();

        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_student_info asi = new add_student_info();
            asi.Show();
        }

        private void viewStudentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_student_info vsi = new view_student_info();
            vsi.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issue_books ib = new issue_books();
            ib.Show();
                
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return_books rb = new return_books();
            rb.Show();
        }

        private void issueBooksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            issue_books ib = new issue_books();
            ib.Show();
        }

        private void returnBooksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            return_books rb = new return_books();
            rb.Show();
        }

        private void returnBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            return_books rb = new return_books();
            rb.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure You Want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning )== DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void booksStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            books_record br = new books_record();
            br.Show();
        }
    }
}
