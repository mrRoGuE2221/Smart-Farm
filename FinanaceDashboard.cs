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
    public partial class FinanaceDashboard : Form
    {
        string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";

        SqlDataAdapter expenseAdapter;
        DataTable expenseTable;

        SqlDataAdapter incomeAdapter;
        DataTable incomeTable;

        public FinanaceDashboard()
        {
            InitializeComponent();
            LoadExpenseData();
            LoadIncomeData();
            CalculateTotals();
        }

        private void LoadExpenseData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT [Expense Id], [Expense Catagory], Details, [Date and Time], Amount FROM dbo.[Expense]";
                    expenseAdapter = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(expenseAdapter);

                    expenseTable = new DataTable();
                    expenseAdapter.Fill(expenseTable);
                    dataGridView1.DataSource = expenseTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Expense data: " + ex.Message);
            }
        }

        private void LoadIncomeData()
        {
            try
            {
                string query = "SELECT [Product Id], [Product Name], [Unit Price], Quantity, [Total Sell], [Date and time] FROM dbo.[Income]";
                incomeAdapter = new SqlDataAdapter(query, connectionString); 
                SqlCommandBuilder builder = new SqlCommandBuilder(incomeAdapter);

                incomeTable = new DataTable();
                incomeAdapter.Fill(incomeTable);
                dataGridView2.DataSource = incomeTable;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Income data: " + ex.Message);
            }
        }


        private void CalculateTotals()
        {
            double totalExpense = 0;
            double totalIncome = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Amount"].Value != null && double.TryParse(row.Cells["Amount"].Value.ToString(), out double amount))
                {
                    totalExpense += amount;
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Total Sell"].Value != null && double.TryParse(row.Cells["Total Sell"].Value.ToString(), out double sell))
                {
                    totalIncome += sell;
                }
            }

            textBox1.Text = totalExpense.ToString("F2");
            textBox2.Text = totalIncome.ToString("F2");
            textBox3.Text = (totalIncome - totalExpense).ToString("F2");
        }

        private void FinanaceDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadExpenseData();
            LoadIncomeData();
            CalculateTotals();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (expenseAdapter == null)
                {
                    LoadExpenseData();
                    if (expenseAdapter == null)
                    {
                        MessageBox.Show("Expense data could not be loaded. Update cancelled.");
                        return;
                    }
                }

                expenseAdapter.Update(expenseTable);
                MessageBox.Show("✅ Expense table updated successfully.");
                LoadExpenseData();
                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Expense table: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                incomeAdapter.Update(incomeTable);

               
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataRow row in incomeTable.Rows)
                    {
                      
                        if (row.RowState == DataRowState.Modified)
                        {
                            string updateOrderInfoQuery = @"
                                                  UPDATE dbo.[OrderInfo]
                                                  SET [Price] = @Price,
                                             [Quantity] = @Quantity,
                                              [Total price] = @TotalSell
                                                 WHERE [Product-Id] = @ProductId";

                            using (SqlCommand cmd = new SqlCommand(updateOrderInfoQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Price", row["Unit Price"]);
                                cmd.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                                cmd.Parameters.AddWithValue("@TotalSell", row["Total Sell"]);
                                cmd.Parameters.AddWithValue("@ProductId", row["Product Id"]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show(" Income table updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating tables: " + ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            AdminPage AP3 = new AdminPage();    
            AP3.Show();
            this.Close();
        }
    }
}
