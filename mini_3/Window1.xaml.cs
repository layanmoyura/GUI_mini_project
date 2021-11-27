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
using System.Windows.Shapes;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

       

        private void Button_Click_logout(object sender, RoutedEventArgs e)
        {
            MainWindow wM = new MainWindow();
            wM.Show();
            this.Close();
        }

        private void Button_Click_schedule(object sender, RoutedEventArgs e)
        {
            Window4 x = new Window4();
            x.Show();
            this.Close();
           
        }

       

        private void Button_Click_getticket(object sender, RoutedEventArgs e)
        {
            Window5 y = new Window5();
            y.Show();
            this.Close();
        }

        private void Button_Click_searchtrain(object sender, RoutedEventArgs e)
        {
            Window3 y = new Window3();
            y.Show();
            this.Close();
        }

        private void Button_Click_notices(object sender, RoutedEventArgs e)
        {
            Window7 y = new Window7();
            y.Show();
            this.Close();
        }
    }
}
