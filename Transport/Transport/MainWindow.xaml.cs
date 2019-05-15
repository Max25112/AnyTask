using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class User
    {

        public string UserName { get; set; }
        public string Password { get; set; }

    }
    class PrintExel
    {
        public static void ExportToExcel(List<User> vUser)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = workBook.ActiveSheet;
            workSheet.Cells[1, "A"] = "User";
            workSheet.Cells[1, "B"] = "Password";
            workBook.Close(true, "Users.xlsx");
            excelApp.Quit();
            MessageBox.Show("Файл успешно сохранён!");
            string parser = File.ReadAllText(@"UserName.txt", Encoding.Default);
            int parsers = Convert.ToInt32(parser);
            int row = 1;
            foreach (User users in vUser)
            {
                row++;
                workSheet.Cells[parsers, "A"] = users.UserName;
                workSheet.Cells[parsers, "B"] = users.Password;
            }

        }

    }
    public partial class MainWindow : Window
    {
        string FilePath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        public class transport
        {
            public string Bus { get; set; }
            public string Stay { get; set; }
            public string LicenseNumber { get; set; }
            public string Driver { get; set; }
            public string Conductor { get; set; }
            public int Time { get; set; }
        }

        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    App.Current.Shutdown();
        //}
        public partial class ListViewGridViewSample : Window
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransportList.ItemsSource = LoadCollectionData();

        }
        private List<transport> LoadCollectionData()
        {
            List<transport> items = new List<transport>();
            items.Add(new transport()
            {
                Bus = "19А",
                Stay = "Профессорская",
                LicenseNumber = "AAA000BBB",
                Driver = "Иванов Иван Иванович",
                Conductor = "Иванов Иван Иванович",
                Time = 4
            }
            );
            return items;
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public List<transport> ListInitialization()
        {
            List<transport> items = new List<transport>();
            string[] arStr = File.ReadAllLines(FilePath);

            foreach (string str in arStr)
            {
                var splitededStr = str.Split('*');
                
                items.Add(new transport()
                {
                    Bus = splitededStr[0],
                    Stay = splitededStr[1],
                    LicenseNumber = splitededStr[2],
                    Driver = splitededStr[3],
                    Conductor = splitededStr[4],
                    Time = Int32.Parse(splitededStr[5])
                }
            );
            }
            return items;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
            TransportList.ItemsSource = ListInitialization();
        }

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

        private void Exel_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
