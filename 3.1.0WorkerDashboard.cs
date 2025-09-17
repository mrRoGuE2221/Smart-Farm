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
    public partial class WorkerDashboard : Form
    {
        private SqlDataAdapter adapter;
        private DataTable dt;
        string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";

        public WorkerDashboard()
        {
            InitializeComponent();
            FillDataGridView("SELECT * FROM WorkerInfo");

        }
        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connectionString);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            WorkerRegistration WR = new WorkerRegistration();
            WR.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            AdminPage Ap2 = new AdminPage();
            Ap2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM WorkerInfo 
                 WHERE [Worker Id] LIKE @searchTerm 
                    OR Username LIKE @searchTerm 
                    OR Phone LIKE @searchTerm 
                    OR Address LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No worker found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (adapter == null || dt == null)
            {
                MessageBox.Show("No data loaded to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                adapter.Update(dt);
                MessageBox.Show("Worker information updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridView("SELECT * FROM WorkerInfo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string workerId = dataGridView1.SelectedRows[0].Cells["Worker Id"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete Worker ID: {workerId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM WorkerInfo WHERE [Worker Id] = @WorkerId";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@WorkerId", workerId);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Worker removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDataGridView("SELECT * FROM WorkerInfo");
                        }
                        else
                        {
                            MessageBox.Show("No matching worker found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting worker: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
