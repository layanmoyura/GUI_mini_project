using mini_3.Database;
using mini_3.Models;
using System;
using System.Linq;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window9.xaml
    /// </summary>
    public partial class Window9 : Window
    {
        public Window9()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Window2 y = new Window2();
            y.Show();
            this.Close();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(id.Text) || String.IsNullOrEmpty(price.Text) || String.IsNullOrEmpty(officer_id.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {
                try {
                    using (Databaserepo repo = new Databaserepo())
                    {
                        int x = Convert.ToInt32(officer_id.Text);
                        int y = Convert.ToInt32(id.Text);

                        var admin = repo.Admins.Where(a => a.AdminID == x).ToArray();
                        if (admin.Length == 1)
                        {

                            var class1 = repo.Classes.Find(y);
                            class1.Price_per_unit_distance = Convert.ToDouble(price.Text);
                            class1.Admin = repo.Admins.Find(x);
                            repo.SaveChanges();
                            MessageBox.Show("Price is changed succesfully!", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            id.Clear();
                            price.Clear();
                            officer_id.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Please enter authorized officer id and price as numeric value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    };
                }
                catch
                {
                    MessageBox.Show("Please enter authorized officer id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            id.Clear();
            price.Clear();
            officer_id.Clear();
        }
    }
    }

