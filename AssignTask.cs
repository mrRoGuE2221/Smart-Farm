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
    public partial class AssignTask : Form
    {
        public AssignTask()
        {
            InitializeComponent();
            string[] status = new string[3];
            status[0] = "Pending";
            status[1] = "Working";
            status[2] = "Completed";
            tstatuscomboBox1.DataSource = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string taskID = taskidtextBox1.Text.Trim();
            string status = tstatuscomboBox1.SelectedItem?.ToString();
            string description = tdestextBox2.Text.Trim();
            string workerID = wtextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(taskID) || string.IsNullOrWhiteSpace(status) ||
                string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(workerID))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=RIAD\\SQLEXPRESS; database=SmartFarm; integrated security=SSPI";
            string query = "INSERT INTO TaskInfo ([Task-ID], Status, Description, [Worker-ID]) VALUES (@TaskID, @Status, @Description, @WorkerID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskID", taskID);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@WorkerID", workerID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Task assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to assign task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerPage p = new ManagerPage();
            p.Show();
        }
    }
}
