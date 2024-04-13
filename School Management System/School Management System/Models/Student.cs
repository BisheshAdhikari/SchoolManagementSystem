using System.Data.SqlClient;

namespace School_Management_System.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }   
        public string Gender { get; set; }
        public string GradeId { get; set; }
        public Login Login { get; set; }

        public string GradeName { get; set; }
        public List<Grade> GetGradesList() {
        
        List<Grade> gradeList = new List<Grade>();
        string connectionString = @"Data Source=DESKTOP-5IUS8C1\SQL22;Initial Catalog=StudentManagementSystem;User Id=sa;Password=123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT GradeId,GradeName FROM Grade";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Grade grade = new Grade();
                            string gradeID = reader["GradeId"].ToString();
                            string GradeName = reader["GradeName"].ToString();
                            grade.GradeId = Convert.ToInt32(gradeID);
                            grade.GradeName = GradeName;

                            gradeList.Add(grade);
                        }
                    }
                }
            }
            return gradeList;
        }
        public string SaveStudent()
        {
            string connectionString = @"Data Source=DESKTOP-5IUS8C1\SQL22;Initial Catalog=StudentManagementSystem;User Id=sa;Password=123;";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Define the SQL query to insert data
                    string query = "Insert into Username values('"+this.Login.Username+"','"+this.Login.Password+"') Insert into Student values((select max(UserId) from Username),'" + this.FirstName + "','"+this.LastName+ "','"+Convert.ToDateTime(this.DateOfBirth) + "','"+this.Gender + "','"+this.GradeId + "')";


                    // Create a SqlCommand object with the SQL query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows were affected.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }




            return "sucess";


        }


        public List<Student> GetStudentList() { 
            List<Student> studentList = new List<Student>();
            string connectionString = @"Data Source=DESKTOP-5IUS8C1\SQL22;Initial Catalog=StudentManagementSystem;User Id=sa;Password=123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select g.GradeName, s.* from Student s Inner Join Grade g on s.GradeId = g.GradeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student();
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string dateOfBirth = reader["DateOfBirth"].ToString();
                            string gender = reader["Gender"].ToString();
                            string gradeId = reader["GradeId"].ToString();
                            string gradeName= reader["GradeName"].ToString();
                            student.FirstName = firstName;
                            student.LastName = lastName;
                            student.DateOfBirth = dateOfBirth;
                            student.Gender = gender;
                            student.GradeId = gradeId;
                            student.GradeName = gradeName;
                            studentList.Add(student);
                        }
                    }
                }
            }
            return studentList;







        }
    }

    
}
