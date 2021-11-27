using mini_3.Database;
using mini_3.Models;
using System;
using System.Linq;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        public Window8()
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
            
        { Databaserepo repo1 = new Databaserepo();
            var idlist = repo1.Trains.Where(a => a.TrainID == ID.Text).ToArray();
            if (idlist.Length != 0)
            {
                MessageBox.Show("Train is already added!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                if (String.IsNullOrEmpty(ID.Text) || String.IsNullOrEmpty(start.Text) || String.IsNullOrEmpty(destination.Text) || String.IsNullOrEmpty(starttime.Text) || String.IsNullOrEmpty(endtime.Text) || String.IsNullOrEmpty(location.Text) || String.IsNullOrEmpty(seats.Text) || String.IsNullOrEmpty(officer_id.Text))
                {
                    MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                else
                {


                    using (Databaserepo repo = new Databaserepo())
                    {
                        int x = Convert.ToInt32(officer_id.Text);
                        var admin = repo.Admins.Where(a => a.AdminID == x).ToArray();
                        if (admin.Length == 1)
                        {
                            Train train = new Train()
                            {

                                TrainID = ID.Text,
                                Starting_at = start.Text,
                                Destination = destination.Text,
                                Starting_time = starttime.Text,
                                Ending_time = endtime.Text,
                                Available_seats = Convert.ToInt32(seats.Text),
                                Location = location.Text,
                                Admin = repo.Admins.Find(x)



                            };
                            repo.Trains.Add(train);
                            repo.SaveChanges();
                            MessageBox.Show("Train is added succesfully!", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            ID.Clear();
                            start.Clear();
                            destination.Clear();
                            starttime.Clear();
                            endtime.Clear();
                            seats.Clear();
                            location.Clear();
                            officer_id.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Please enter authorized officer id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    };
                } 
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if ((String.IsNullOrEmpty(ID.Text)  || String.IsNullOrEmpty(officer_id.Text) || String.IsNullOrEmpty(seats.Text) || ( String.IsNullOrEmpty(start.Text)) && String.IsNullOrEmpty(destination.Text) && String.IsNullOrEmpty(starttime.Text) && String.IsNullOrEmpty(endtime.Text) && String.IsNullOrEmpty(location.Text) ))
            {
                MessageBox.Show("Please fill required fields for updating", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {


                using (Databaserepo repo = new Databaserepo())
                {
                    int x = Convert.ToInt32(officer_id.Text);
                    var train = repo.Trains.Where(a => a.TrainID == ID.Text).ToArray();
                    var admin = repo.Admins.Where(a => a.AdminID == x).ToArray();
                    if (admin.Length == 1 && train.Length == 1)
                    {

                        try {
                            var train1 = repo.Trains.Find(ID.Text);
                            if (!string.IsNullOrEmpty(start.Text)) { train1.Starting_at = start.Text; }
                            if (!string.IsNullOrEmpty(destination.Text)) { train1.Destination = destination.Text; }
                            if (!string.IsNullOrEmpty(starttime.Text)) { train1.Starting_time = starttime.Text; }
                            if (!string.IsNullOrEmpty(endtime.Text)) { train1.Ending_time = endtime.Text; }
                            if (!string.IsNullOrEmpty(location.Text)) { train1.Location = location.Text; }

                            train1.Available_seats = Convert.ToInt32(seats.Text);
                            train1.Admin = repo.Admins.Find(x);
                            repo.SaveChanges();
                            MessageBox.Show("Train is updated succesfully!", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            ID.Clear();
                            start.Clear();
                            destination.Clear();
                            starttime.Clear();
                            endtime.Clear();
                            seats.Clear();
                            location.Clear();
                            officer_id.Clear();
                        }
                        catch
                        {
                            MessageBox.Show("Please enter integer vakue for available seats", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please enter authorized officer id and existing train id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                };
            }
        }

       
    }
}
