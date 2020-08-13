using System.Data;
using System.Data.SqlClient;


namespace Database_saving_and_getting_data
{
    class db
    {
        private static SqlConnection Connection;    //SqlConnection object contains the connection established with database
        static db() //create connection in static constructor so it is established as soon as the class in accessed
        {
            if (Connection == null) //if connection is not established
            {
                string connection_string = Properties.Resources.constr; //getting the saved connection string in Project properties
                Connection = new SqlConnection(connection_string);  //initializing connection by conn string ie address to of the database
                Connection.Open();  //connect
            }
        }
        public static void Save(string name, string roll, string address)
        {
            string query = "Insert Into UserData Values(@roll ,@name, @address);";    //The Command To be executed on the database
            SqlCommand command = new SqlCommand(query, Connection); //creating the command by query string and the connection to the database
            command.Parameters.AddWithValue("@name", name); // setting value of @name as name
            command.Parameters.AddWithValue("@roll", roll); // setting value of @roll as roll
            command.Parameters.AddWithValue("@address", address); // setting value of @address as address
            command.ExecuteNonQuery();  //execute the command on the database
            command.Dispose();  //release command
        }
        public static DataTable GetData()
        {
            string query = "Select * From UserData;";   //The query to get required Columns and Rows ... this query will give the whole table
            SqlCommand command = new SqlCommand(query, Connection); //creating command
            SqlDataReader reader = command.ExecuteReader(); //When we execute the reader the resulting table is saved in reader
            DataTable tb = new DataTable(); //create a new DataTable
            tb.Load(reader);    //load the table in reader to the tb DataTable
            command.Dispose();  //release command
            reader.Close(); //close the reader
            return tb;  //return the datatable with results
        }
    }
}