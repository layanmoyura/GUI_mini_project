using mini_3.Database;
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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            Databaserepo repo = new Databaserepo();
            var trainlist = repo.Trains.Select(x => new { x.TrainID, x.Starting_at, x.Destination, x.Starting_time, x.Ending_time, x.Location, x.Available_seats }).ToList();
            datagrid.ItemsSource = trainlist;
        }

       

       
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();
            x.Show();
            this.Close();
        }

        
    }
}
