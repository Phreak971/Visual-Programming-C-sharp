using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Server
{
    class dbConnection
    {
        public static SqlConnection connection;
        static dbConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(TCP_Server.Properties.Resources.costr);
                connection.Open();
            }
        }
        public static DataTable SearchByName(string name)   //returns the results from database
        {
            string query = "Select * From Student where name = @name;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader); //now the reader has transfered the results to the Datatable
            return table;
        }
    }
}
