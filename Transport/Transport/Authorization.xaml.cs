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
    public partial class Authorization : Window
    {
        string FilePath = "UserName.txt";
        bool IfLog = true;
        public Authorization()
        {
            InitializeComponent();
            List<string> items = new List<string>();
            string[] arStr = File.ReadAllLines("log.txt");
            if (arStr.Length != 0)
            {
                IfLog = false;
                foreach (string str in arStr)
                {
                    var splitededStr = str.Split(' ');
                    UserNameBox.Text = splitededStr[0];
                    userPasswordBox.Password = splitededStr[1];
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            bool entrance = true;
            bool ifSingIn = false;
            bool IfEmpry = false;
            Authorization AuthorizationWindow = new Authorization();
            if (UserNameBox.Text == String.Empty)
            {
                MessageBox.Show("Введите имя пользователя и пароль");
                IfEmpry = true;
                //this.Close();
            }

            if (UserNameBox.Text == "admin" && userPasswordBox.Password == "admin" && !IfEmpry)
            {
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();
                entrance = false;
                ifSingIn = true;
            }

            if (!IfEmpry)
            {
                if (entrance && IsUserAuth())
                {
                    Window1 Window1 = new Window1();
                    Window1.Show();
                    ifSingIn = true;
                    this.Close();
                }
            }
            if (ifSingIn && IfLog)
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(UserNameBox.Text + " " + userPasswordBox.Password);
                }
            }
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            WindowSignOut WindowSignOut = new WindowSignOut();
            WindowSignOut.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public bool IsUserAuth()
        {
            bool IsTrue = false;
            List<string> items = new List<string>();
            string[] arStr = File.ReadAllLines(FilePath);
            foreach (string str in arStr)
            {
                var splitededStr = str.Split(' ');
                var password = userPasswordBox.Password;
                var userCriptPassword = GetHashSHA1(password);
                var cpassword = splitededStr[1];
                if (UserNameBox.Text == splitededStr[0] && userCriptPassword == splitededStr[1])
                {
                    IsTrue = true;
                    break;
                }

            }
            if (IsTrue == false) MessageBox.Show("Не правильный логин или пароль");
            return IsTrue;
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
