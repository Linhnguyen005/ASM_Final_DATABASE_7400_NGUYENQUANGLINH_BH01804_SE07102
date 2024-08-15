using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATT_STUDENT
{
    public partial class Student : Form
    {
        public Student()
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

        private void button1_Click(object sender, EventArgs e)
        {           
            string FullName = txtfullname.Text;
            string Gender;
            string Email = txtemail.Text;
            string Address = txtadress.Text;
            string Phone = txtphone.Text;
            string dob = txtdob.Text;
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
                string query = "INSERT INTO Student (FullName, DateOfBirth, Gender, Address, Phone, Email) " +
                               "VALUES (@FullName, @DateOfBirth, @Gender, @Address, @Phone, @Email)";

                SqlCommand command = new SqlCommand(query, connection);
               
                command.Parameters.AddWithValue("@FullName", FullName);
                command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dob;
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Add student success");
                    GetUser();
                }
                else
                {
                    MessageBox.Show("Cannot add student");
                }
            }
            connection.Close();
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
                string query = "SELECT * FROM Student";
                // Declare a SQLCommand to prepare for query execution
                SqlCommand command = new SqlCommand(query, connection);
                // Declare a SqlDataAdapter to convert query result to data table
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                // Fill the data table
                adapter.Fill(data);
                // Đổ dữ liệu
                dtgstudent.DataSource = data;
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStudentID.Text))
            {
                // Validate and convert StudentID
                if (int.TryParse(txtStudentID.Text, out int StudentID) && StudentID > 0)
                {
                    SqlConnection connection = GetConnection();
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        // Build query
                        string query = "DELETE FROM Student WHERE StudentID = @StudentID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StudentID", StudentID); // Use correct parameter name

                        // Get number of rows affected
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Delete success");
                            GetUser(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Cannot delete user");
                        }
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Invalid StudentID");
                }
            }
            else
            {
                MessageBox.Show("No user is selected");
            }
        }

        private void dtgstudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgstudent.SelectedCells[0].RowIndex;
            int StudentID = Convert.ToInt32(dtgstudent.Rows[index].Cells[0].Value);
            txtStudentID.Text = StudentID.ToString();
            txtfullname.Text = Convert.ToString(dtgstudent.Rows[index].Cells[1].Value);
            txtdob.Text = Convert.ToString(dtgstudent.Rows[index].Cells[2].Value);
            txtGender.Text = Convert.ToString(dtgstudent.Rows[index].Cells[3].Value);
            txtadress.Text = Convert.ToString(dtgstudent.Rows[index].Cells[4].Value);
            txtemail.Text = Convert.ToString(dtgstudent.Rows[index].Cells[5].Value);
            txtemail.Text = Convert.ToString(dtgstudent.Rows[index].Cells[6].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStudentID.Text))
            {
                string FullName = txtfullname.Text;
                string Gender;
                string Email = txtemail.Text;
                string Address = txtadress.Text;
                string Phone = txtphone.Text;
                string dob = txtdob.Text;
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
                    string query = "UPDATE Student SET FullName = @FullName, " +
                                                            "DateOfBirth = @DateOfBirth, " +
                                                            "Gender = @Gender, " +
                                                            "Address = @Address, " +
                                                            "Phone = @Phone, " +
                                                            "Email = @Email " +
                                                            "WHERE StudentID = @StudentID";

                    // Declare SqlCommand to prepare for query execution
                    SqlCommand command = new SqlCommand(query, connection);
                    // Pass value to parameters
                    command.Parameters.AddWithValue("@FullName", FullName);
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dob;
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@StudentID", txtStudentID.Text); // Add the StudentID parameter

                    // Get number of rows affected
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Update success");
                        GetUser();
                    }
                    else
                    {
                        MessageBox.Show("Cannot update Student");
                    }
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("No Student is selected");
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
                    // Search based on full name
                    query = "SELECT * FROM Student WHERE FullName LIKE @SearchValue";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%"); // Use LIKE operator with wildcard
                }
                else
                {
                    // Retrieve all records when no search term is provided
                    query = "SELECT * FROM Student";
                    command = new SqlCommand(query, connection);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dtgstudent.DataSource = data;

                if (data.Rows.Count == 0 && !string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("No records found.");
                }
            }
            connection.Close();
        }

        private void txtStudentID_Click(object sender, EventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
