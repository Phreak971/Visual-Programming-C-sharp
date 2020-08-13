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

namespace Navigation_Data_Passing_Between_Pages
{
    /// <summary>
    /// Interaction logic for new_Page.xaml
    /// </summary>
    public partial class new_Page : Page
    {
        public new_Page()
        {
            InitializeComponent();
        }
        public new_Page(string textRecieved)
        {
            InitializeComponent();
            tb_text.Text = textRecieved;    //set the text of the textblock to the recieved text from the previous page
        }
    }
}
