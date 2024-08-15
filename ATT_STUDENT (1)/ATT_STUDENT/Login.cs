using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATT_STUDENT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=DESKTOP-NI8N4RT\\SQLEXPRESS;Initial Catalog=StudentSystem;Integrated Security=True";

        // Build function to connect to SQL Server
        private SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                // Connect to SQL Server
                connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                // Notify user when connection fail
                MessageBox.Show(
                    "Cannot connect to server",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return connection;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            
            ClearData();
            Dispose();
        }
        private void ClearData()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            // Get data from user inputs
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            // Validate data
            // Handle when username is empty
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(
                    "Username cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                txtUsername.Focus();
            }
            // Handle when password is empty
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                txtUsername.Focus();
            }
            // If username and password are not empty, then query database to get data
            else
            {
                // Get SQL server connection
                SqlConnection connection = GetConnection();
                // Open the connection
                connection.Open();
                // Check if connect to database success
                if (connection != null)
                {
                    // Build query
                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password AND role = @role";                  
                    // Initialize SqlCommand to add parameters and execute query
                    SqlCommand command = new SqlCommand(query, connection);
                    // Add params based on user inputs
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);
                    // Set role = 1 to check admin role of user
                    command.Parameters.AddWithValue("role", 1);
                    // Get number of record
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    // If number of record > 0 (An account satisfy the login credential)
                    // Then notify user and redirect to Product management form
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Welcome back, Student: " + username,
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                        Student std = new Student();
                        this.Hide();
                        std.Show();
                    }
                    else
                    {

                        // Check for teacher role
                        query = "SELECT * FROM Users WHERE Username = @username AND Password = @password AND Role = @role";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("username", username);
                        command.Parameters.AddWithValue("password", password);
                        command.Parameters.AddWithValue("role", 2);
                        result = Convert.ToInt32(command.ExecuteScalar());
                        if (result > 0)
                        {
                            MessageBox.Show
                                ("Welcome back, Teacher: " + username, 
                                "Success",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                            Teacher teacher = new Teacher();
                            this.Hide();
                            teacher.Show();
                        }
                        
                    connection.Close();
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
