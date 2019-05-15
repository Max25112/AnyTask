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
using System.IO;
using System.Security.Cryptography;

namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для WindowSignOut.xaml
    /// </summary>


    public partial class WindowSignOut : Window
    {
        private WindowSignOut _windowClose;
        string writePath = "UserName.txt";
        public WindowSignOut()
        {
            InitializeComponent();
        }
        private void Button_SignOut(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == passwordBoxRepeat.Password)
            {
                var user = UserName.Text;
                var password = PasswordBox.Password;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.Write(user + " " + GetHashSHA1(password) + "\n");
                }
                this.Close();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        string GetHashSHA1(string input)
        {
            byte[] hash;
            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }
    }
}
