using System;
using System.Collections.Generic;
using System.Data;  //This is to use DataTable class
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating A Table
            DataTable Movies = new DataTable("Movies"); //Parameterized Constructor Accepts Table Name
            //Add Columns to Table
            Movies.Columns.Add("Movie Id", typeof(int));
            Movies.Columns.Add("Title", typeof(string));      //(ColumnName, DataType)
            Movies.Columns.Add("Release Date", typeof(DateTime));
            Movies.Columns.Add("Director", typeof(string));
            Movies.Columns.Add("Genre", typeof(string));
            Movies.Columns.Add("Gross in USD", typeof(double));
            //Add Primary Key
            Movies.PrimaryKey = new DataColumn[] { Movies.Columns["Movie Id"] };
            //Add Rows/Data to the Table
            // we should add rows to table inside try catch to handle exceptions ... otherwise runtime error will be generated when a primary key is repeated
            try
            {
                Movies.Rows.Add(1, "Memento", DateTime.Parse("2000-09-04"), "Christopher Nolan", "Drama/Crime", 39.70);
                Movies.Rows.Add(2, "The Godfather", DateTime.Parse("1972-03-14"), "Francis Ford Coppola", "Drama/Crime", 286.00);
                Movies.Rows.Add(3, "Donnie Brasco", DateTime.Parse("1997-02-28"), "Mike Newell", "Drama/Crime", 124.90);
                Movies.Rows.Add(4, "Memento", DateTime.Parse("1960-06-16"), "Alfred Hitchcock", "Mystery/Thriller", 50.00);
                Movies.Rows.Add(4, "Memento", DateTime.Parse("1960-06-16"), "Alfred Hitchcock", "Mystery/Thriller", 50.00); //violating primary key
            }
            catch (ConstraintException e)
            {
                Console.WriteLine(e.Message);
            }
            //Display Table
            foreach (DataRow row in Movies.Rows)
            {
                Console.WriteLine(string.Format("{0,-3}\t{1,-16}\t{2,-18}\t{3,-23}\t{4,-16}\t{5,-6}", row["Movie Id"], row["Title"], row["Release Date"],
                     row["Director"], row["Genre"], row["Gross in USD"]));
                //The String format and other things are used to align the output ... no need to worry we can also output simply like
                // Console.WriteLine(row["Director"] + "\t" + row["Genre"] .....etc); 
            }
        }
    }
}
