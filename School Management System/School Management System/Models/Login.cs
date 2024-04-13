using System.Data.Common;
using System.Data.SqlClient;

namespace School_Management_System.Models
{
    public class Login
    {
        public string Username { get; set; }

        public string Password { get; set; }


        public string SaveLogin() {

            string connectionString = @"Data Source=DESKTOP-5IUS8C1\SQL22;Initial Catalog=StudentManagementSystem;User Id=sa;Password=123;";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Define the SQL query to insert data
                    string query = "";


                    // Create a SqlCommand object with the SQL query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        //command.Parameters.AddWithValue("@FirstName", "John");
                        //command.Parameters.AddWithValue("@LastName", "Doe");
                        //command.Parameters.AddWithValue("@Age", 25);

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

    }
}
