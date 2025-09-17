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
    public partial class BuyerOrder : Form
    {
        public BuyerOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";
            string productName = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM OrderInfo
                     WHERE [Product Name] LIKE @ProductName";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");


                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "Select * from OrderInfo ";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();


            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                sb.Append(col.HeaderText + "\t");
            }
            sb.AppendLine();


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append((cell.Value?.ToString() ?? "") + "\t");
                }
                sb.AppendLine();
            }


            ShowOrders smo = new ShowOrders();
            smo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyerPage bp = new BuyerPage();
            bp.Show();
            this.Close();
        }

        private void BuyerOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
