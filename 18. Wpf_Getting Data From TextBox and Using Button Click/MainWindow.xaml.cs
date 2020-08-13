using System;
using System.Collections.Generic;
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

namespace Wpf_Getting_Data_From_TextBox_and_Using_Button_Click
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Ye Fucntion call hoga jb button Click hoga
        {
            //Jb button click hoga hum TextBox se Text utha k aik messageBox me show kara denge .... Message Box aik dabba sa bna ata ha usme string hota ha
            String BoxText = MyTextBox.Text;    //TextBoxKaNaam.Text; wo text return krta ha jo textbox me likha hoga
            if (BoxText.Equals(""))  //Agr text box khaali tha
            {
                MessageBox.Show("Nothing to Show"); //Ye Message show krde ga
            }
            else    //agr text box khaali nai tha
            {
                MessageBox.Show(BoxText);   //toh Message me wo text show ho jaye ga jo textbox me hoga
            }
        }
    }
}
