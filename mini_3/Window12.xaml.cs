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
    /// Interaction logic for Window12.xaml
    /// </summary>
    public partial class Window12 : Window
    {
        public Window12()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Window2 y = new Window2();
            y.Show();
            this.Close();
        }

        private void load_table(object sender, TextChangedEventArgs e)
        {
            Databaserepo repo = new Databaserepo();
            if (table.Text== "Train Schedule")
            {
                
                var trainlist = repo.Trains.Select(x => new { x.TrainID, x.Starting_at, x.Destination, x.Starting_time, x.Ending_time, x.Location, x.Available_seats,x.Admin.AdminID }).ToList();
                datagrid.ItemsSource = trainlist;
            }
            else if(table.Text == "Class Prices") 
            {
                var classlist = repo.Classes.Select(x => new { x.ClassID,x.Price_per_unit_distance,x.Admin.AdminID}).ToList();
                datagrid.ItemsSource = classlist;
            }
            else if (table.Text == "Stations")
            {
                var stationlist = repo.Stations.Select(x => new { x.StationID, x.Station_name,x.Crowd_capacity,x.Distance,x.Admin.AdminID}).ToList();
                datagrid.ItemsSource = stationlist;
            }
            else if (table.Text == "Notices")
            {
                var noticelist = repo.Notices.Select(x => new { x.NoticeID, x.DateTime,x.Station.Station_name ,x.Notice_content, x.Admin.AdminID }).ToList();
                datagrid.ItemsSource = noticelist;
            }
            else if (table.Text == "Officers")
            {
                var adminlist = repo.Admins.Select(x => new { x.AdminID,x.Name,x.workplace }).ToList();
                datagrid.ItemsSource = adminlist;
            }
            else if (table.Text == "Users")
            {
                var userlist = repo.Users.Select(x => new { x.UserID,x.Firstname,x.Lastname,x.Email,x.Contact_no }).ToList();
                datagrid.ItemsSource = userlist;
            }

            else if (table.Text == "Tickets")
            {
                var ticketlist = repo.Tickets.Select(x => new {x.TicketID,x.From,x.To,x.Value,x.User.UserID }).ToList();
                datagrid.ItemsSource = ticketlist;
            }
        }
    }
    
    
}
