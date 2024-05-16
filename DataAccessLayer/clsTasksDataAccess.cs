using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class clsTasksDataAccess
    {

        public static DataTable getAllTasks()
        {

            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            SqlCommand command = new SqlCommand("SP_GetAllTasks", connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    dataTable.Load(reader);

                }


                reader.Close();

            }
            catch (Exception exception)
            {
                Console.WriteLine("DEBUG: Exception {0}", exception.Message);

            }
            finally
            {
                connection.Close();
            }


            return dataTable;
        } 

        public static bool deleteAllTasks()
        {
            int numberOfAffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SP_DeleteAllTasks";

            SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {

                connection.Open();

                numberOfAffectedRows = command.ExecuteNonQuery();


            } catch(Exception exception)
            {

                Console.WriteLine("DEBUG: Exception {0}", exception.Message);

            } finally
            {
                connection.Close();
            }




            return numberOfAffectedRows > 0;
        }

        public static bool addTask(string task)
        {
            int numberOfAffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SP_AddNewTask";

            SqlCommand command = new SqlCommand(query,connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@task", task);

            try
            {
                connection.Open();

                numberOfAffectedRows = command.ExecuteNonQuery();


            }
            catch (Exception exception) 
            {
                Console.WriteLine("DEBUG: Exception {0}", exception.Message);
            }
            finally
            {
                connection.Close();
            }




            return numberOfAffectedRows > 0;

        }

        public static bool deleteTask(int taskID)
        {
            int numberOfAffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SP_DeleteTask";

            SqlCommand command = new SqlCommand(query,connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TaskID", taskID);

            try
            {
                connection.Open();

                numberOfAffectedRows = command.ExecuteNonQuery();

            } catch(Exception exception) 
            {
                Console.WriteLine("DEBUG: Exception {0}", exception.Message);
            } finally
            {
                connection.Close();
            }


            return numberOfAffectedRows > 0;

        }
    }
}
