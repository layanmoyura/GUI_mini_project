using mini_3.Database;
using System.Linq;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Window1 y = new Window1();
            y.Show();
            this.Close();
        }

        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(trainid.Text))
            {
                MessageBox.Show("Please enter a train id!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Databaserepo repo = new Databaserepo();
                var train = repo.Trains.Where(a => a.TrainID == trainid.Text).ToArray();
                if (train.Length == 0)
                {
                    MessageBox.Show("Please enter a valid train id!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    string z = train[0].TrainID;

                    var trainlist = repo.Trains.Where(x => x.TrainID == z).Select(x => new { x.TrainID, x.Starting_at, x.Destination, x.Starting_time, x.Ending_time, x.Location, x.Available_seats }).ToList();
                    datagrid.ItemsSource =trainlist ;
                    
                }
            }
        }
    }
}
