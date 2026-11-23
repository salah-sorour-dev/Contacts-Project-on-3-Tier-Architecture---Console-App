using System;
using System.Data;
using System.Data.SqlClient;
using ContactsDataAccessLayer;

namespace ConatctsDataAccessLayer
{
    public class clsCountryDataAccess
    {

        public static bool GetCountryInfoByID(int CountryID, ref string CountryName, ref string Code, ref string Phone)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    CountryName = (string)reader["CountryName"];
                    //Code = (string)reader["Code"];
                    Code = Convert.ToString(reader["Code"]);
                    //Phone = (string)reader["PhoneCode"];
                    Phone = Convert.ToString(reader["PhoneCode"]);


                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;



        }


        public static bool GetCountryInfoByName(ref int ID, string CountryName, ref string Code, ref string Phone)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            String query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];
                    Code = (string)reader["Code"];
                    Phone = (string)reader["Phone"];
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool IsCountryExist(int CountryID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();  
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static bool IsCountryExist(string CountryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static int AddNewCountry(string CountryName)
        {
            //this function will return new country id if succeeded and -1 if not.
            int CountryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Countries (CountryName)
                            VALUES (@CountryName);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountryID = insertedID;
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

            return CountryID;


        }

        public static bool UpdateCountry(int ID, string CountryName, string Code, string Phone)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Countries
                                SET CountryName = @CountryName,
                                    Code = @Code,
                                    PhoneCode = @PhoneCode
                                    WHERE CountryID = @CountryID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryID", ID);
            command.Parameters.AddWithValue(@"CountryName", CountryName);
            command.Parameters.AddWithValue(@"Code", Code);
            command.Parameters.AddWithValue(@"PhoneCode", Phone);

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

            return (rowsAffected > 0);
        }
            

        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dataTable.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();

            }

            return dataTable;
        }


    }
}
