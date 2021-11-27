using mini_3.Database;
using mini_3.Models;
using System;
using System.Linq;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window10.xaml
    /// </summary>
    public partial class Window10 : Window
    {
        public Window10()
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
            if (String.IsNullOrEmpty(stname.Text) || String.IsNullOrEmpty(notice.Text) || String.IsNullOrEmpty(officer_id.Text) )
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {


                using (Databaserepo repo = new Databaserepo())
                {
                    int x = Convert.ToInt32(officer_id.Text);
                    var admin = repo.Admins.Where(a => a.AdminID == x).ToArray();
                    var station = repo.Stations.Where(a => a.Station_name == stname.Text).ToArray();
                    if (admin.Length == 1 && station.Length == 1)
                    {
                        Notice new_notice = new Notice()
                        {
                           Station = station[0],
                           DateTime = DateTime.Now,
                           Notice_content = notice.Text,
                           Admin = repo.Admins.Find(x)



                        };
                        repo.Notices.Add(new_notice);
                        repo.SaveChanges();
                        MessageBox.Show("Notice is added succesfully!", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        stname.Clear();
                        notice.Clear();
                        officer_id.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Please enter authorized officer id and existing station name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                };
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(stname.Text) || String.IsNullOrEmpty(officer_id.Text))
            {
                MessageBox.Show("Please fill required fields for remove notice! existing station name and authorized officer id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {


                using (Databaserepo repo = new Databaserepo())
                {
                    int x = Convert.ToInt32(officer_id.Text);
                    var y = repo.Stations.Where(a => a.Station_name == stname.Text).ToArray();
                    int z = y[0].StationID;

                    var admin = repo.Admins.Where(a => a.AdminID == x).ToArray();
                    if (admin.Length == 1 && y.Length ==1)
                    {

                        var notice1 = repo.Notices.Where(a => a.Station.StationID == z).ToList();
                        repo.Notices.RemoveRange(notice1);
                        repo.SaveChanges();
                        MessageBox.Show("Notices are removed succesfully!", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        stname.Clear();
                        notice.Clear();
                        officer_id.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Please enter authorized officer id and existing station name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                };
            }
        }

        
    }
}
