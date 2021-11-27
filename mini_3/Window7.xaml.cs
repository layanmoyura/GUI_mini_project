using mini_3.Database;
using System.Linq;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
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
            if (string.IsNullOrEmpty(stname.Text))
            {
                MessageBox.Show("Please enter a station name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Databaserepo repo = new Databaserepo();
                var station = repo.Stations.Where(a => a.Station_name == stname.Text).ToArray();
                if (station.Length == 0)
                {
                    MessageBox.Show("Please enter a valid station name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    int z = station[0].StationID;

                    var noticelist = repo.Notices.Where(x => x.Station.StationID == z).Select(x => new { x.DateTime, x.Notice_content }).ToList();
                    if (noticelist.Count == 0)
                    {
                        MessageBox.Show("No notices for this station!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        datagrid.ItemsSource = noticelist;
                    }
                }
            }
        }
    }
}
