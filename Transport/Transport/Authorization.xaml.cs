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

namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        string FilePath = "UserName.txt";
        public Authorization()
        {
            InitializeComponent();
        }
       
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization AuthorizationWindow = new Authorization();
            if (IsUserAuth())
            {
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();
            }
            if (UserNameBox.Text == "2")
            {
                Window1 Window1 = new Window1();
                Window1.Show();
                this.Close();
            }
            if (UserNameBox.Text == String.Empty)
            {
                MessageBox.Show("Введите имя пользователя и пароль");
                this.Close();
            }

            //Window2 Window2 = new Window2();
            //Window2.Show();
            //Window3 Window3 = new Window3();
            //Window3.Show();
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

                if (UserNameBox.Text == splitededStr[0] && userPasswordBox.Password == splitededStr[1])
                {
                    IsTrue= true;
                    break;
                }
            }
            return IsTrue;
        }
    }
}
