using mini_3.Database;
using mini_3.Models;
using System;
using System.Linq;
using System.Windows;
using System.Security.Cryptography;
using System.Text;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {


        int paid = 0;
        public Window6()
        {
            InitializeComponent();
        }

        public static string Encrypt(string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
            return Convert.ToBase64String(encrypted);
        }





        static Aes getAes()
        {
            var keyBytes = new byte[16];
            var skeyBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            Array.Copy(skeyBytes, keyBytes, Math.Min(keyBytes.Length, skeyBytes.Length));

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            return aes;
        }

        private void Button_Click__Back(object sender, RoutedEventArgs e)


        {
            if (paid == 0 )
            {
                MessageBox.Show("You have to pay for the ticket first!", "info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else {
                Window5 y = new Window5();
                y.Show();
                this.Close();
            }
        }

        private void Button_Click_Pay(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(card_no.Text) || string.IsNullOrEmpty(name_on_card.Text) || string.IsNullOrEmpty(bank.Text) || string.IsNullOrEmpty(card_type.Text) || string.IsNullOrEmpty(date.Text))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (Databaserepo repo = new Databaserepo())
                {
                    int x = repo.Tickets.Max(p => p.TicketID);

                    Payment payment = new Payment()
                    {
                        Card_no = card_no.Text,
                        Name_on_card = name_on_card.Text,
                        Bank = bank.Text,
                        Card_type = card_type.Text,
                        Payment_date = date.Text,
                        Pin = Encrypt(password.Password),
                        Ticket = repo.Tickets.Find(x)
                        
                    };

                    repo.Payments.Add(payment);
                    repo.SaveChanges();

                    paid++;

                    MessageBox.Show("Price of the ticket is paid succesfully! You will recieve a E-ticket via your given email", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    card_no.Clear();
                    name_on_card.Clear();
                    card_copy.Clear();
                    bank.Clear();
                    date.SelectedDate = null;
                    password.Clear();

                }

            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            card_no.Clear();
            name_on_card.Clear();
            card_copy.Clear();
            bank.Clear();
            date.SelectedDate = null;
            password.Clear();
        }
    }
}
