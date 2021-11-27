using mini_3.Database;
using System;
using System.Linq;
using System.Windows;
using System.Text;
using System.Security.Cryptography;

namespace mini_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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


        public void Button_Click_user_log(object sender, RoutedEventArgs e)

        {
            if (String.IsNullOrEmpty(ID.Text))
            {
                MessageBox.Show("User id or Password is incorrect! Please try again!", "Login Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                {
                    try {
                        Databaserepo repo = new Databaserepo();

                        string y = Encrypt(Password.Password);
                        int x = Convert.ToInt32(ID.Text);
                        var userid = repo.Users.Where(a => a.UserID == x).ToArray();
                        var userpass = repo.Users.Where(b => b.Password == y).ToArray();

                        if ((userpass.Length != 0 && userid.Length != 0) && (userpass[0].UserID == x))
                        {

                            Window1 w1 = new Window1();
                            w1.Show();
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("User id or Password is incorrect! Please try again!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    catch
                    {
                        MessageBox.Show("User id should be an integer", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    


                }
            }
            
            
        }

        private void Button_Click_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void Button_Click_user_reg(object sender, RoutedEventArgs e)
        {
            Registeru R = new Registeru();
            R.Show();
            this.Close();
        }

        private void Button_Click_officer_reg(object sender, RoutedEventArgs e)
        {
            Adminreg R = new Adminreg();
            R.Show();
            this.Close();
        }

        public void Button_Click_officer_log(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ID.Text))
            {
                MessageBox.Show("Officer id or Password is incorrect! Please try again!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                {
                    try
                    {
                        Databaserepo repo = new Databaserepo();
                        int x = Convert.ToInt32(ID.Text);
                        string y = Encrypt(Password.Password);
                        var adminid = repo.Admins.Where(a => a.AdminID == x).ToArray();
                        var adminpass = repo.Admins.Where(b => b.Password == y).ToArray();

                        if ((adminpass.Length != 0 && adminid.Length != 0) && (adminpass[0].AdminID == x))
                        {

                            Window2 w1 = new Window2();
                            w1.Show();
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Officer id or Password is incorrect! Please try again!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    catch
                    {
                        MessageBox.Show("User id should be an integer", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    

                }
            }
        }

        private void Button_Click_visipass(object sender, RoutedEventArgs e)
        {
            vispassword.Text = Password.Password;
            Password.Visibility = Visibility.Collapsed;
            vispassword.Visibility = Visibility.Visible;
        }

        

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Password.Visibility = Visibility.Visible;
            vispassword.Visibility = Visibility.Collapsed;
        }
    }
}
