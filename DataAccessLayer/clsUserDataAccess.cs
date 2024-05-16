using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Data;


namespace DataAccessLayer
{
    public class clsUserDataAccess
    {


        public static bool isUserExist(string username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SP_IsUserExist";

            SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Username", username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()){

                    isFound = true;

                    reader.Close();
                }


            } catch(Exception exception)
            {

                Console.WriteLine("DEBUG: {0}",exception.Message);

            } finally
            {
                connection.Close();
            }


            return isFound;
        }

        public static bool isUserActive(string username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SP_IsUserActive";

            SqlCommand command = new SqlCommand(query,connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Username",username);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;

                    reader.Close();
                }


            } catch(Exception exception)
            {
                Console.WriteLine("DEBUG: {}",exception.Message);
            }
            finally
            {
                connection.Close();
            }



            return isFound;

        }

        public static bool login(ref int userID  ,string username , string password , ref bool isActive)
        {
            bool isLoggedIn = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SP_Login";

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    userID = (int)reader["UserID"];
                    isActive = (bool)reader["IsActive"];                    

                    isLoggedIn = true;
                }


            } catch(Exception exception) 
            {

                Console.WriteLine("DEBUG: {0}", exception.Message);

            } finally
            {
                connection.Close();
            }



            return isLoggedIn;
        }












    }
}
