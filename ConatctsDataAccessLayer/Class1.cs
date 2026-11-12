using System;
using System.Data;
using System.Data.SqlClient;


namespace ConatctsDataAccessLayer
{
    public class clsContactDataAccess
    {
        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName,
            ref string Email, ref string Phone, ref string Address,
            ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //The record was found, so set the output parameters
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];

                    //ImagePath: allow null in database so we should handle null values
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    //The record was not found, so set the output parameters to default values
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }


        public static int AddNewContact(string FirstName, string LastName, string Email, string Phone, string Address,
            DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            //this function will return the new contact ID if the contact was added successfully, or -1 if there was an error
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath) " +
                "VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath); " +
                "SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }


            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ContactID;

        }


        public static bool UpdateContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address,
            DateTime DateOfBirth, int CountryID, string ImagePath)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth," +
                " CountryID = @CountryID, ImagePath = @ImagePath WHERE ContactID = @ContactID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }


            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;


        }

    }
}
