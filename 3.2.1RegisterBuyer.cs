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
    public partial class BuyerRegister : Form
    {
        public BuyerRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";

            string id = textBox1.Text.Trim();
            string username = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();
            string address = textBox5.Text.Trim();
            string phone = textBox6.Text.Trim();
            string role = "buyer";

            
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(id, out int parsedId))
            {
                MessageBox.Show("Id must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(phone, out long parsedPhone))
            {
                MessageBox.Show("Phone must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string loginQuery = "INSERT INTO Login (Id, Role, Username, Password, Address, Phone) " +
                                "VALUES (@Id, @Role, @Username, @Password, @Address, @Phone)";

            string buyerInfoQuery = "INSERT INTO BuyerInfo ([Buyer-Id], Username, Password, Address, Phone) " +
                                    "VALUES (@Id, @Username, @Password, @Address, @Phone)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand loginCommand = new SqlCommand(loginQuery, connection);
                SqlCommand buyerCommand = new SqlCommand(buyerInfoQuery, connection);

                
                loginCommand.Parameters.AddWithValue("@Id", parsedId);
                loginCommand.Parameters.AddWithValue("@Role", role);
                loginCommand.Parameters.AddWithValue("@Username", username);
                loginCommand.Parameters.AddWithValue("@Password", password);
                loginCommand.Parameters.AddWithValue("@Address", address);
                loginCommand.Parameters.AddWithValue("@Phone", parsedPhone);

                
                buyerCommand.Parameters.AddWithValue("@Id", parsedId);
                buyerCommand.Parameters.AddWithValue("@Username", username);
                buyerCommand.Parameters.AddWithValue("@Password", password);
                buyerCommand.Parameters.AddWithValue("@Address", address);
                buyerCommand.Parameters.AddWithValue("@Phone", parsedPhone);

                try
                {
                    connection.Open();

                    int loginRows = loginCommand.ExecuteNonQuery();
                    int buyerRows = buyerCommand.ExecuteNonQuery();

                    if (loginRows > 0 && buyerRows > 0)
                    {
                        MessageBox.Show("Buyer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        BuyerDashboard bd = new BuyerDashboard(); 
                        bd.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register buyer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            BuyerDashboard BD2 = new BuyerDashboard();
            BD2.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
