using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkerPage : Form
    {
        public WorkerPage()
        {
            InitializeComponent();
        }

        private void WorkerPage_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out the application?", "Confirm Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                Login bi = new Login();
                bi.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkerProfile Wp = new WorkerProfile();
            Wp.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viewtask vt = new Viewtask();
              vt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reportissue Ri = new Reportissue();
            Ri.Show();
        }
    }
}
