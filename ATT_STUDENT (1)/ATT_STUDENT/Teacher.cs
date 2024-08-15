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

namespace ATT_STUDENT
{
    public partial class Teacher : Form
    {
        public Teacher()
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
                connection.Open();
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
            finally
            {
                connection.Close();
            }
            return connection;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            MainTeacher main = new MainTeacher();
            main.ShowDialog();
            Dispose();
        }
        private void GetUser()
        {
            SqlConnection connection = GetConnection();
            // Open connection
            connection.Open();
            // Check connection
            if (connection.State == ConnectionState.Open)
            {
                // build query
                string query = "SELECT * FROM Teacher";
                // Declare a SQLCommand to prepare for query execution
                SqlCommand command = new SqlCommand(query, connection);
                // Declare a SqlDataAdapter to convert query result to data table
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                // Fill the data table
                adapter.Fill(data);
                // Đổ dữ liệu
                dtgTeacher.DataSource = data;
            }
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string FullName = txtfullname.Text;
            string Gender;
            string Email = txtemail.Text;
            string Address = txtadress.Text;
            string Phone = txtphone.Text;
            string dob = txtdob.Text;
            string Major = txtmajor.Text;
            if (rdNam.Checked)
            {
                Gender = "Nam";
            }
            else
            {
                Gender = "Nu";
            }

            SqlConnection connection = GetConnection();
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                string query = "INSERT INTO Teacher (FullName, DateOfBirth, Gender, Address, Phone, Email, Major) " +
                               "VALUES (@FullName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @Major)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FullName", FullName);
                command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dob;
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Major", Major);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Add Teacher success");
                    GetUser();
                }
                else
                {
                    MessageBox.Show("Cannot add Teacher");
                }
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtTeacherID.Text))
            {
                string FullName = txtfullname.Text;
                string Gender;
                string Email = txtemail.Text;
                string Address = txtadress.Text;
                string Phone = txtphone.Text;
                string dob = txtdob.Text;
                string Major = txtmajor.Text;
                if (rdNam.Checked)
                {
                    Gender = "Nam";
                }
                else
                {
                    Gender = "Nu";
                }

                SqlConnection connection = GetConnection();
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    string query = "UPDATE Teacher SET FullName = @FullName, " +
                                                            "DateOfBirth = @DateOfBirth, " +
                                                            "Gender = @Gender, " +
                                                            "Address = @Address, " +
                                                            "Phone = @Phone, " +
                                                            "Email = @Email, " +
                                                            "Major = @Major " +
                                                            "WHERE TeacherID = @TeacherID";


                    SqlCommand command = new SqlCommand(query, connection);
                    
                    command.Parameters.AddWithValue("@FullName", FullName);
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dob;
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Major", Major);
                    command.Parameters.AddWithValue("@TeacherID", txtTeacherID.Text);
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Update success");
                        GetUser();
                    }
                    else
                    {
                        MessageBox.Show("Cannot update Teacher");
                    }
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("No Teacher is selected");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTeacherID.Text))
            {
                // Validate and convert StudentID
                if (int.TryParse(txtTeacherID.Text, out int TeacherID) && TeacherID > 0)
                {
                    SqlConnection connection = GetConnection();
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        // Build query
                        string query = "DELETE FROM Teacher WHERE TeacherID = @TeacherID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StudentID", TeacherID); // Use correct parameter name

                        // Get number of rows affected
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Delete success");
                            GetUser(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Cannot delete Teacher");
                        }
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Invalid TeacherID");
                }
            }
            else
            {
                MessageBox.Show("No Teacher is selected");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchValue = txttimkiem.Text;

            SqlConnection connection = GetConnection();
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                SqlCommand command;
                string query;

                if (!string.IsNullOrEmpty(searchValue))
                {

                    query = "SELECT * FROM Teacher WHERE FullName LIKE @SearchValue";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                }
                else
                {

                    query = "SELECT * FROM Teacher";
                    command = new SqlCommand(query, connection);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dtgTeacher.DataSource = data;

                if (data.Rows.Count == 0 && !string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("No records found.");
                }
            }
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTeacherID_Click(object sender, EventArgs e)
        {







































        }
    }   
}
