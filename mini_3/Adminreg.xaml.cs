using mini_3.Database;
using mini_3.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Adminreg : Window
    {
        public Adminreg()
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

        public static string Decrypt(string encrypted)
        {
            var b = Convert.FromBase64String(encrypted);
            var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);
            return Encoding.UTF8.GetString(decrypted);
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            this.Close();
        }

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(workplace.Text)  || String.IsNullOrEmpty(contactno.Text) || String.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Please fill all fields", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
           
            else
            {
                using (Databaserepo repo = new Databaserepo())
                {
                    Admin admin = new Admin()
                    {
                        
                        Name = name.Text,
                        workplace = workplace.Text,
                        Contact_no = contactno.Text,
                        Password = Encrypt(password.Password)

                    };
                    repo.Admins.Add(admin);
                    repo.SaveChanges();
                    MessageBox.Show("Registration is succesful ! and auto generated officer id is sent to your email.", "Success Message",MessageBoxButton.OK,MessageBoxImage.Information);
                    name.Clear();
                    workplace.Clear();
                    contactno.Clear();
                    password.Clear();
                };
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            name.Clear();
            workplace.Clear();
            contactno.Clear();
            password.Clear();
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

    }
}
