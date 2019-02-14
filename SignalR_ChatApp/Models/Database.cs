using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatApp.Models
{
    public class Database
    {
        // Verander 'localhost' naar uiteindelijke adres van de database!
        // Verander 'AnalyseDb' naar de finale database!
        private string connectionString = "Data Source = localhost; Initial Catalog = AnalyseDb; Integrated Security = True";

        private Logger l = new Logger();

        #region CREATE
        public bool AddUser(User user)
        {
            bool returnValue = false;

            string query = "INSERT INTO [User] SELECT '@Name', @MsgCount;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@MsgCount", System.Data.SqlDbType.Int);
                command.Parameters["@Name"].Value = user.Name;
                command.Parameters["@MsgCount"].Value = user.MsgCount;

                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    l.Write("AddUser Rows affected: " + rowsAffected.ToString());
                    returnValue = true;
                    return returnValue;
                }
                catch (Exception e)
                {
                    l.Write(e);
                    return returnValue;
                }
            }
        }
        #endregion

        #region READ
        public List<User> RetrieveUsers()
        {
            string query = "SELECT * FROM [User]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                List<User> userList = new List<User>();

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userList.Add(new User
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                MsgCount = (int)reader["MsgCount"]
                            });
                        }
                    }

                    l.Write("RetrieveUsers Users returned: " + userList.Count());
                    return userList;
                }
                catch (Exception e)
                {
                    l.Write(e);
                    return null;
                }
            }
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}
