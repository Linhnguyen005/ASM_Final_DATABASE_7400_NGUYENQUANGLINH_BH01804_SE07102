using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ATT_STUDENT
{
    public partial class Grade : Form
    {
        public Grade()
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           string scorename = txtScorename.Text;
           string Part1 = txtP1.Text;
           string Part2 = txtP2.Text;
           string Final = txtFinal.Text;
           int StudentID = Convert.ToInt32(cmbStudent.SelectedValue);
           int CourseID;

            if (int.TryParse(cmbCourse.SelectedValue.ToString(), out CourseID))
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        string query = "INSERT INTO Score (ScoreName, Part1, Part2, Final, StudentID, CourseID) " +
                                       "VALUES (@ScoreName, @Part1, @Part2, @Final, @StudentID, @CourseID)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ScoreName", scorename);
                            command.Parameters.AddWithValue("@Part1", Part1);
                            command.Parameters.AddWithValue("@Part2", Part2);
                            command.Parameters.AddWithValue("@Final", Final);
                            command.Parameters.AddWithValue("@StudentID", StudentID);
                            command.Parameters.AddWithValue("@CourseID", CourseID);

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
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid CourseID. Please select a valid course.");
            }
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
                string query = "SELECT * FROM Score";
                // Declare a SQLCommand to prepare for query execution
                SqlCommand command = new SqlCommand(query, connection);
                // Declare a SqlDataAdapter to convert query result to data table
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                // Fill the data table
                adapter.Fill(data);
                // Đổ dữ liệu
                dtgScore.DataSource = data;
            }
            connection.Close();
        }
        private void dtgScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgScore.SelectedCells[0].RowIndex;
            int ScoreID = Convert.ToInt32(dtgScore.Rows[index].Cells[0].Value);
            int StudentID = Convert.ToInt32(dtgScore.Rows[index].Cells[5].Value);  
            int CourseID = Convert.ToInt32(dtgScore.Rows[index].Cells[6].Value);
            txtScoreID.Text = ScoreID.ToString();
            txtScorename.Text = Convert.ToString(dtgScore.Rows[index].Cells[1].Value);
            txtP1.Text = Convert.ToString(dtgScore.Rows[index].Cells[2].Value);
            txtP2.Text = Convert.ToString(dtgScore.Rows[index].Cells[3].Value);
            txtFinal.Text = Convert.ToString(dtgScore.Rows[index].Cells[4].Value);
            txtStudentID.Text = Convert.ToString(dtgScore.Rows[index].Cells[5].Value);
            txtScoreID.Text = Convert.ToString(dtgScore.Rows[index].Cells[6].Value);
            txtStudentID.Text = StudentID.ToString();
            txtCourseID.Text = CourseID.ToString();
        }
        private void LoadStudents()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string query = "SELECT StudentID, FullName FROM Student"; 
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                adapter.Fill(data);

                cmbStudent.DataSource = data;
                cmbStudent.DisplayMember = "FullName"; 
                cmbStudent.ValueMember = "StudentID"; 
            }
            connection.Close();
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            string scorename = txtScorename.Text;
            string Part1 = txtP1.Text;
            string Part2 = txtP2.Text;
            string Final = txtFinal.Text;
            int StudentID = Convert.ToInt32(cmbStudent.SelectedValue);
            int CourseID;

            
            int ScoreID = Convert.ToInt32(txtScoreID.Text); 

            if (int.TryParse(cmbCourse.SelectedValue.ToString(), out CourseID))
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        string query = "UPDATE Score SET " +
                                       "ScoreName = @ScoreName, " +
                                       "Part1 = @Part1, " +
                                       "Part2 = @Part2, " +
                                       "Final = @Final, " +
                                       "StudentID = @StudentID, " +
                                       "CourseID = @CourseID " +
                                       "WHERE ScoreID = @ScoreID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ScoreName", scorename);
                            command.Parameters.AddWithValue("@Part1", Part1);
                            command.Parameters.AddWithValue("@Part2", Part2);
                            command.Parameters.AddWithValue("@Final", Final);
                            command.Parameters.AddWithValue("@StudentID", StudentID);
                            command.Parameters.AddWithValue("@CourseID", CourseID);
                            command.Parameters.AddWithValue("@ScoreID", ScoreID);

                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Update success");
                                GetUser();
                            }
                            else
                            {
                                MessageBox.Show("Cannot update Score");
                            }
                        }
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid CourseID. Please select a valid course.");
            }
            //if (!string.IsNullOrEmpty(txtScoreID.Text))
            //{
            //    string scorename = txtScorename.Text;
            //    string part1 = txtP1.Text;
            //    string part2 = txtP2.Text;
            //    string final = txtFinal.Text;
            //    string studentID = cmbStudent.Text;
            //    string courseID = cmbCourse.Text;
                

            //    SqlConnection connection = GetConnection();
            //    connection.Open();

            //    if (connection.State == ConnectionState.Open)
            //    {
            //        string query = "UPDATE Score SET scorename = @Scorename, " +
            //                                                "part1 = @Part1, " +
            //                                                "part2 = @Part2, " +
            //                                                "final = @Final, " +
            //                                                "studentID = @StudentID, " +
            //                                                "courseID = @CourseID " +
            //                                                "WHERE ScoreID = @ScoreID";


            //        SqlCommand command = new SqlCommand(query, connection);

            //        command.Parameters.Add("@Scorename", SqlDbType.NVarChar).Value = scorename;
            //        command.Parameters.Add("@Part1", SqlDbType.NVarChar).Value = part1;
            //        command.Parameters.Add("@Part2", SqlDbType.NVarChar).Value = part2;
            //        command.Parameters.Add("@Final", SqlDbType.NVarChar).Value = final;
            //        if (int.TryParse(studentID, out int parsedStudentID))
            //        {
            //            command.Parameters.Add("@StudentID", SqlDbType.Int).Value = parsedStudentID;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid StudentID. Please enter a valid number.");
            //            return;
            //        }
            //        \
            //        command.Parameters.Add("@CourseID", SqlDbType.Int).Value = int.Parse(courseID);
            //        command.Parameters.Add("@ScoreID", SqlDbType.Int).Value = int.Parse(txtScoreID.Text);
            //        int result = command.ExecuteNonQuery();

            //        if (result > 0)
            //        {
            //            MessageBox.Show("Update success");
            //            GetUser();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Cannot update Score");
            //        }
            //    }
            //    connection.Close();
            //}
            //else
            //{
            //    MessageBox.Show("No Score is selected");
            //}
        }
        private void LoadCoursesIntoComboBox()
            {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        string query = "SELECT CourseID, CourseName FROM Courses";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cmbCourse.DataSource = dataTable;
                        cmbCourse.DisplayMember = "CourseName";  // Tên hiển thị trong ComboBox
                        cmbCourse.ValueMember = "CourseID";      // Giá trị ẩn (CourseID)
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void Grade_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadCoursesIntoComboBox();
        }
    }
}
