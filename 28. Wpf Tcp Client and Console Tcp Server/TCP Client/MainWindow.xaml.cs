using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//create a class TcpClient to handle the tcp operations to send and recieve data from server
//we will send the name to server on button click and recieve a datatable that we will bind to the datagrid
namespace TCP_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable searchResults { set; get; } = new DataTable();   //the results will be saved in this
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //send name to server and get results
        {
            try { TcpClient.Create_Connection(); MessageBox.Show("Connected!"); }  //try connecting to server first
            catch (Exception) { MessageBox.Show("Connection Not Established"); return; }
            string name = tb_name.Text;
            if (name == "")
            {
                MessageBox.Show("No Name Entered!");
            }
            else
            {
                searchResults = TcpClient.Search(name); //sends name and recieves datatable with results 
                dataGrid_Student.ItemsSource = searchResults.DefaultView;   //binding datagrid to the datatable of results
            }
        }
    }
}