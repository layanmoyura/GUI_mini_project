using mini_3.Database;
using mini_3.Models;
using System;
using System.Linq;
using System.Windows;


namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        
        int loaded = 0;
        double value = 0;
       
        public Window5()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            Window1 y = new Window1();
            y.Show();
            this.Close();
        }

        private void Button_Click_Pay(object sender, RoutedEventArgs e)


        {
            if (string.IsNullOrEmpty(fromst.Text) || string.IsNullOrEmpty(tost.Text) || string.IsNullOrEmpty(classID.Text) || string.IsNullOrEmpty(userid.Text))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {

                if (loaded !=0 )
                {
                    if (MessageBox.Show("Do you want to continue the payment.If you press yes you should pay the value!",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try {
                            using (Databaserepo repo = new Databaserepo())
                            {
                                int x = Convert.ToInt32(classID.Text);
                                int z = Convert.ToInt32(userid.Text);
                                if (repo.Users.Find(z) != null)
                                {
                                    Ticket ticket = new Ticket()
                                    {
                                        From = fromst.Text,
                                        To = tost.Text,
                                        Class = repo.Classes.Find(x),
                                        User = repo.Users.Find(z),
                                        Value = (float)value

                                    };
                                    repo.Tickets.Add(ticket);
                                    repo.SaveChanges();

                                    Window6 yx = new Window6();
                                    yx.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please enter authorized user id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                

                               
                            }
                            
                        }
                        catch
                        {
                            MessageBox.Show("Please enter authorized user id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        



                      
                    }
                    else
                    {
                        loaded = 0;
                        value = 0;
                    }

                }

                else
                {
                    MessageBox.Show("Please check the value of ticket before going into payment window!", "info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(fromst.Text) || string.IsNullOrEmpty(tost.Text) || string.IsNullOrEmpty(classID.Text))
            {
                MessageBox.Show("Please fill starting and ending stations with relevant class to load value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            


            else 
            {
                Databaserepo repo = new Databaserepo();
                var fromstation = repo.Stations.Where(a => a.Station_name == fromst.Text).ToArray();
                var tostation = repo.Stations.Where(a => a.Station_name == tost.Text).ToArray();

                if(fromstation.Length == 0 || tostation.Length == 0)
                {
                    MessageBox.Show("Please give valid station names!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    int x = Convert.ToInt32(classID.Text);
                    var class1 = repo.Classes.Find(x);
                    double price = class1.Price_per_unit_distance;

                    var dis1 = fromstation[0].Distance;
                    var dis2 = tostation[0].Distance;

                    double dis = dis1 - dis2;

                    double val = price * Math.Abs(dis);

                    val = Math.Round((Double)val, 2);

                    string tkt_price = "Rs." + Convert.ToString(val);

                    value = val;
                    list.Items.Add(" ");
                    list.Items[0]=tkt_price;

                    loaded++;




                }


            }

            
           
            
        }
    }
}
