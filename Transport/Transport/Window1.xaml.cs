using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    App.Current.Shutdown();
        //}

        private void ExitAccont_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("log.txt", String.Empty);
            Authorization authorization = new Authorization();
            authorization.Show();
            //System.Threading.Thread.Sleep(2000); 
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"log.txt", false))
            //{
            //    file.WriteLine("");
            //}

            this.Close();
        }
    }
}
