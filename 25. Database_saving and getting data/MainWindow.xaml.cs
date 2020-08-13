using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Database_saving_and_getting_data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Create a Database by going to project-> Add New Item-> Data -> Service Based Database
        //Goto Server Explorer and right click on the Database and see its properties...
        //copy the connection String from the database and paste it in a string in project -> Properties(last option) -> Resources 
        //Create a new table by right clicking the Tables option in the database in the server explorer
        //create a class db for database connection
        private void Save(object sender, RoutedEventArgs e)
        {
            //Take Data in the textboxes and save to The Database
            if (tb_address.Text == "" || tb_name.Text == "" || tb_rollnumber.Text == "")    // if any textbox is empty
            {
                MessageBox.Show("Field Cannot be Left Empty");
            }
            else
            {
                try
                {
                    db.Save(tb_name.Text, tb_rollnumber.Text, tb_address.Text); // add the data to the database
                    MessageBox.Show("Data Added Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed Adding to DataBase");
                }
            }
        }
        private void GetandShow(object sender, RoutedEventArgs e)
        {
            //GetData From The DataBase and Show it in the TextBlock on the Page
            DataTable getData;   //create DataTable
            getData = db.GetData(); //get the result Table and save it in the table created
            StringBuilder builder = new StringBuilder();    //we need a string or a string builder
            builder.AppendLine("Roll Number\t\tName\t\tAddress");   //add Headers
            foreach (DataRow row in getData.Rows)
            {
                builder.AppendLine(string.Format("{0}\t\t\t{1}\t\t{2}", row["Roll_number"].ToString(), row["Name"].ToString(), row["Address"].ToString())); //Add values for each row
            }
            tb_show.Text = builder.ToString();  //set Text in the TextBlock
        }
    }
}