using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Multithreading
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Text = tb_get.Text;
            Thread set = new Thread(Set);   //set in child thread
            set.Start(Text);
            MessageBox.Show(Text); //showing in Main Thread
        }
        public void Set(object Text)
        {
            Action<string> action = new Action<string>(sss);
            this.Dispatcher.Invoke(action,Text);
        }
        public void sss(string Text)
        {
            tb_set.Text = Text;
        }
    }
}