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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click_logout(object sender, RoutedEventArgs e)
        {
            MainWindow R = new MainWindow();
            R.Show();
            this.Close();
        }

        private void Button_Click_updatetrain(object sender, RoutedEventArgs e)
        {
            Window8 y = new Window8();
            y.Show();
            this.Close();
        }

        private void Button_Click_changeprice(object sender, RoutedEventArgs e)
        {
            Window9 y = new Window9();
            y.Show();
            this.Close();
        }

        private void Button_Click_givenotice(object sender, RoutedEventArgs e)
        {
            Window10 y = new Window10();
            y.Show();
            this.Close();
        }

        private void Button_Click_addstation(object sender, RoutedEventArgs e)
        {
            Window11 y = new Window11();
            y.Show();
            this.Close();
        }

        private void Button_Click_viewdata(object sender, RoutedEventArgs e)
        {
            Window12 y = new Window12();
            y.Show();
            this.Close();
        }
    }
}
