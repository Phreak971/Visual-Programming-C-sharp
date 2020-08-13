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

namespace Navigation_Click_Button_or_HyperLink_Csharp
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

        private void Click_Navigation(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Page to Navigate to.xaml", UriKind.Relative);    //create and initialize a Uniform Resource Identifier for the page to Navigate
            NavigationService.Navigate(uri);    //navigate to the new page
        }
    }
}
