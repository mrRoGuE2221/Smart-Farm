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
    public partial class BuyerDashboard : Form
    {
        private SqlDataAdapter adapter;
        private DataTable dt;
        string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";
        public BuyerDashboard()
        {
            InitializeComponent();
            FillDataGridView("SELECT * FROM BuyerInfo");
        }
        private void FillDataGridView(string query)
        {
            adapter = new SqlDataAdapter(query, connectionString); 
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter); 

            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyerRegister buyerRegister = new BuyerRegister();
            buyerRegister.Show();
           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            AdminPage Ad3 = new AdminPage();
            Ad3.Show();
            this.Hide();
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
                MessageBox.Show("Buyer information updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                FillDataGridView("SELECT * FROM BuyerInfo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM BuyerInfo 
                  WHERE [Buyer-Id] LIKE @searchTerm 
                     OR Username LIKE @searchTerm 
                     OR Phone LIKE @searchTerm 
                     OR Address LIKE @searchTerm";

            adapter = new SqlDataAdapter(query, connectionString);
            adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                dataGridView1.DataSource = null; 
                MessageBox.Show("No buyer found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string buyerId = dataGridView1.SelectedRows[0].Cells["Buyer-Id"].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete Buyer ID: " + buyerId + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM BuyerInfo WHERE [Buyer-Id] = @BuyerId";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@BuyerId", buyerId);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Buyer removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDataGridView("SELECT * FROM BuyerInfo"); // Refresh grid
                        }
                        else
                        {
                            MessageBox.Show("No matching buyer found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting buyer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
