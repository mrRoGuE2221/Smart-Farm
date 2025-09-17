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
    public partial class WorkerRegistration : Form
    {
        public WorkerRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";

            string id = textBox1.Text.Trim();
            string role = textBox2.Text.Trim().ToLower();  
            string username = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();
            string address = textBox5.Text.Trim();
            string phone = textBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(username) ||
                 string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(id, out int parsedId))
            {
                MessageBox.Show("Id must be a valid integer number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(phone, out long parsedPhone))
            {
                MessageBox.Show("Phone must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            string loginQuery = "INSERT INTO Login (Id, Role, Username, Password, Address, Phone) VALUES (@Id, @Role, @Username, @Password, @Address, @Phone)";

           
            string extraQuery = "";

            if (role == "worker")
            {
                extraQuery = "INSERT INTO WorkerInfo ([Worker Id], Username, Password, Address, Phone) VALUES (@Id, @Username,@Password, @Address, @Phone)";
            }
            else if (role == "manager")
            {
                extraQuery = "INSERT INTO ManagerInfo ([Manager Id], Username,Password, Address, Phone) VALUES (@Id, @Username,@Password, @Address, @Phone)";
            }
            else
            {
                MessageBox.Show("Invalid role. Please enter either 'worker' or 'manager'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand loginCommand = new SqlCommand(loginQuery, connection);
                SqlCommand roleCommand = new SqlCommand(extraQuery, connection);

               
                loginCommand.Parameters.AddWithValue("@Id", parsedId);
                loginCommand.Parameters.AddWithValue("@Role", role);
                loginCommand.Parameters.AddWithValue("@Username", username);
                loginCommand.Parameters.AddWithValue("@Password", password);
                loginCommand.Parameters.AddWithValue("@Address", address);
                loginCommand.Parameters.AddWithValue("@Phone", parsedPhone);

               
                roleCommand.Parameters.AddWithValue("@Id", parsedId);
                roleCommand.Parameters.AddWithValue("@Username", username);
                roleCommand.Parameters.AddWithValue("@Password", password);
                roleCommand.Parameters.AddWithValue("@Address", address);
                roleCommand.Parameters.AddWithValue("@Phone", parsedPhone);

                try
                {
                    connection.Open();
                    int loginRows = loginCommand.ExecuteNonQuery();
                    int roleRows = roleCommand.ExecuteNonQuery();

                    if (loginRows > 0 && roleRows > 0)
                    {
                        MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        WorkerDashboard WD1 = new WorkerDashboard();
                        WD1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            WorkerDashboard WD2= new WorkerDashboard();
            WD2.Show();
            this.Hide();
        }
    }
}
