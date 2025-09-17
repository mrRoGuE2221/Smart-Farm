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
    public partial class AdminPage : Form
    {
        string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";
        public AdminPage()
        {
            InitializeComponent();
            LoadOrderInfo();
        }

        private void LoadOrderInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
         SELECT 
             [Order-Id], 
             [Product-Id], 
             [Product Name], 
             Quantity, 
             Price, 
             (CAST(Quantity AS float) * Price) AS [Total price], 
             [Buyer-Id], 
             Confirmation
         FROM dbo.OrderInfo";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading OrderInfo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkerDashboard_Click(object sender, EventArgs e)
        {
            WorkerDashboard WD= new WorkerDashboard();
            WD.Show();
            this.Hide();
        }

        private void BuyerDashboard_Click(object sender, EventArgs e)
        {
            BuyerDashboard BD1= new BuyerDashboard();
            BD1.Show(); 
            this.Hide();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewProductInfo_Click(object sender, EventArgs e)
        {
            ProductDashboard Pd1 = new ProductDashboard();
            Pd1 .Show();
            this.Hide();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
           Profile p1 = new Profile();
            p1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FinanaceDashboard fd1= new FinanaceDashboard();
            fd1.Show();
            this.Hide();
        }

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

          
            int orderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Order-Id"].Value);
            string confirmationValue = dataGridView1.CurrentRow.Cells["Confirmation"].Value?.ToString().Trim();

            if (string.IsNullOrEmpty(confirmationValue))
            {
                MessageBox.Show("Please enter 'Accept' or 'Decline' in the Confirmation column before confirming.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                  
                    string updateQuery = "UPDATE dbo.[OrderInfo] SET Confirmation = @Confirmation WHERE [Order-Id] = @OrderId";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Confirmation", confirmationValue);
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }

                   
                    if (confirmationValue.Equals("Accept", StringComparison.OrdinalIgnoreCase))
                    {
                        
                        int productId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Product-Id"].Value);
                        string productName = dataGridView1.CurrentRow.Cells["Product Name"].Value.ToString();
                        double unitPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Price"].Value);
                        int quantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Quantity"].Value);
                        double totalSell = unitPrice * quantity;
                        DateTime dateTimeNow = DateTime.Now;

                        string insertIncomeQuery = @"
                    INSERT INTO dbo.[Income] ([Product Id], [Product Name], [Unit Price], Quantity, [Total Sell], [Date and time])
                    VALUES (@ProductId, @ProductName, @UnitPrice, @Quantity, @TotalSell, @DateTimeNow)";

                        using (SqlCommand cmd = new SqlCommand(insertIncomeQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@ProductName", productName);
                            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@TotalSell", totalSell);
                            cmd.Parameters.AddWithValue("@DateTimeNow", dateTimeNow);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show(" Order confirmed and added to Income table.");
                    }
                    else if (confirmationValue.Equals("Decline", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(" Order declined.");
                    }
                    else
                    {
                        MessageBox.Show("Invalid confirmation value. Please enter 'Accept' or 'Decline'.");
                    }
                }

                LoadOrderInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error confirming order: " + ex.Message);
            }
        }
    }
}
