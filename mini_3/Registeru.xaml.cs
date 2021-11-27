using mini_3.Database;
using mini_3.Models;
using System;
using System.Windows;
using System.Security.Cryptography;
using System.Text;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Registeru.xaml
    /// </summary>
    public partial class Registeru : Window
    {
        public Registeru()
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


        private void Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            password2.Text = password.Password;
            password.Visibility = Visibility.Collapsed;
            password2.Visibility = Visibility.Visible;
        }



        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            password.Visibility = Visibility.Visible;
            password2.Visibility = Visibility.Collapsed;
        }




        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(firstname.Text) || String.IsNullOrEmpty(lastname.Text) || String.IsNullOrEmpty(age.Text) || String.IsNullOrEmpty(contactno.Text) || String.IsNullOrEmpty(email.Text) || String.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (!((bool)check.IsChecked))
            {
                MessageBox.Show("Please accept Terms and Conditions", "Error",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    using (Databaserepo repo = new Databaserepo())
                    {
                        User user = new User()
                        {
                            Firstname = firstname.Text,
                            Lastname = lastname.Text,
                            Age = Convert.ToInt32(age.Text),
                            Contact_no = contactno.Text,
                            Email = email.Text,
                            Password = Encrypt(password.Password)

                        };
                        repo.Users.Add(user);
                        repo.SaveChanges();
                        MessageBox.Show("Registration is succesful ! and auto generated user id is sent to your email.", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        firstname.Clear();
                        lastname.Clear();
                        age.Clear();
                        contactno.Clear();
                        email.Clear();
                        password.Clear();
                        check.IsChecked = false;
                    };
                }
                catch
                {
                    MessageBox.Show("Please enter integr value for age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            this.Close();

        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            firstname.Clear();
            lastname.Clear();
            age.Clear();
            contactno.Clear();
            email.Clear();
            password.Clear();
            check.IsChecked = false;
        }

       

       
    }
}
