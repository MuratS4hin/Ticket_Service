using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Ticket_Class
{
    public static class DataBase
    {
        public static void SetAndExit(List<Users> u , List<Admins> a)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = "CREATE TABLE UserTable(username VARCHAR(50),password INT,ticket VARCHAR(300),answer VARCHAR(300) ,role VARCHAR(5))";
                createTableCmd.ExecuteNonQuery();
                    
                createTableCmd.CommandText = "CREATE TABLE AdminTable(username VARCHAR(50),password INT role VARCHAR(5))";
                createTableCmd.ExecuteNonQuery();
                
                //Seed some data:
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var VARIABLE in u)
                    {
                        
                        var insertCmd = connection.CreateCommand();
                        // insertCmd.CommandText = "INSERT INTO UserTable (username,password,ticket,answer,role) VALUES()";
                        insertCmd.Parameters.AddWithValue("@username", VARIABLE.Username);
                        insertCmd.Parameters.AddWithValue("@password", VARIABLE.Password);
                        insertCmd.Parameters.AddWithValue("@ticket", VARIABLE.Ticket);
                        insertCmd.Parameters.AddWithValue("@answer", VARIABLE.Answer);
                        insertCmd.Parameters.AddWithValue("@role", VARIABLE.Role);
                        insertCmd.CommandText = "INSERT INTO UserTable (username,password,ticket,answer,role) SELECT 0 , 1, 2, 3,4";
                        insertCmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var VARIABLE in a)
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.CommandText = "INSERT INTO UserTable (username,password,ticket) VALUES()";
                        insertCmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                
                connection.Close();
            }
        }
    }
}