using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATT_STUDENT
{
    public partial class MainTeacher : Form
    {
        public MainTeacher()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainTeacher_Load(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            
            Student main = new Student();
            main.ShowDialog();
            this.Close();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            Teacher main = new Teacher();
            main.ShowDialog();
            this.Close();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            Grade main = new Grade();
            main.ShowDialog();
            this.Close();
        }
    }
}
