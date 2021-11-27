using mini_3.Database;
using mini_3.Models;
using System;
using System.Linq;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window11.xaml
    /// </summary>
    public partial class Window11 : Window
    {
        public Window11()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Window2 y = new Window2();
            y.Show();
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(stname.Text) || String.IsNullOrEmpty(crowd.Text) || String.IsNullOrEmpty(officer_id.Text) )
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {

                try {
                    using (Databaserepo repo1 = new Databaserepo())
                    {
                        int x = Convert.ToInt32(officer_id.Text);
                        var admin = repo1.Admins.Where(a => a.AdminID == x).ToArray();
                        if (admin.Length == 1)
                        {
                            Station station = new Station()
                            {

                                Station_name = stname.Text,
                                Crowd_capacity = Convert.ToInt32(crowd.Text),
                                Distance = Convert.ToInt32(distance.Text),
                                Admin = repo1.Admins.Find(x)



                            };
                            repo1.Stations.Add(station);
                            repo1.SaveChanges();
                            MessageBox.Show("Station is added succesfully!", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            stname.Clear();
                            crowd.Clear();
                            distance.Clear();
                            officer_id.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please enter authorized officer id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    };
                }
                catch
                {
                    MessageBox.Show("Please enter crowd capacity and distance as integers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            stname.Clear();
            crowd.Clear();
            distance.Clear();
            officer_id.Clear();
        }
    }
}
