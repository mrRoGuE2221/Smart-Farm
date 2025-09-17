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

namespace WindowsFormsApp1
{
    public partial class Inventory : Form
    {
        private SqlDataAdapter ADAPTER;
        private DataTable dataT;
        string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";
        public Inventory()
        {
            InitializeComponent();
            FillDataGridView("Select * From InventoryInfo");
        }
        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                ADAPTER = new SqlDataAdapter(query, connectionString);
                SqlCommandBuilder builder = new SqlCommandBuilder(ADAPTER);

                dataT = new DataTable();
                ADAPTER.Fill(dataT);
                dataGridView1.DataSource = dataT;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ADAPTER == null || dataT == null)
            {
                MessageBox.Show("No data loaded to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                ADAPTER.Update(dataT);
                MessageBox.Show("Inventory information updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridView("SELECT * FROM InventoryInfo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              this.Close();
            ManagerPage managerPage = new ManagerPage();    
            managerPage.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
