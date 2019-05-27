using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
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
        string FilePathUser = "UserName.txt";

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
            this.Close();
        }

        private void Exel_Click(object sender, RoutedEventArgs e)
        {
            int row = 1;
            List<User> vUser = new List<User>();
            string[] arStr = File.ReadAllLines(FilePathUser);

            foreach (string str in arStr)
            {
                var splitededStr = str.Split(' ');
                row++;
                vUser.Add(new User()
                {
                    UserName = splitededStr[0],
                    Password = splitededStr[1],

                }
            );
            }

            string fileName = @"D:\AnyTask\Transport\Transport\bin\Debug\Users.xlsx"; //имя Excel файла  
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWb = xlApp.Workbooks.Open(fileName); //открываем Excel файл
            Excel.Worksheet xlSht = xlWb.Sheets[1]; //первый лист в файле
            
            xlSht.Cells[1, "A"] = "User";
            xlSht.Cells[1, "B"] = "Password";
            int iLastRow = xlSht.Cells[xlSht.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row;  //последняя заполненная строка в столбце А
            foreach (User users in vUser)
            {
                iLastRow++;
                xlSht.Cells[iLastRow, "A"] = users.UserName;
                xlSht.Cells[iLastRow, "B"] = users.Password;
            }
            xlApp.Visible = true;
           // xlWb.Close(true); //закрыть и сохранить книгу
            xlApp.Quit();
            MessageBox.Show("Файл успешно сохранён!");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Word_Click(object sender, RoutedEventArgs e)
        {
            
            object myTemplate = @"D:\AnyTask\Transport\Transport\bin\Debug\Users.docx";
            object oMissing = System.Reflection.Missing.Value;
            object SaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            object OriginalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdWordDocument;
            object RouteDocument = false;
            object _0 = null;

            Word._Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Add(ref myTemplate, ref oMissing, ref oMissing, ref oMissing); ;
            
            //заполняем документ текстом
            Word.Paragraph par = wordDoc.Paragraphs.Last;
            par.Range.Font.Size = 14;
            par.Range.Font.Name = "Times New Roman";
            par.Range.Text = "Exel-записывет в Exel файл логин и серилезованный пароль \n" +
                "File-'Загрузить из файла' записывает в таблицу даннные о водителей";
            //wordDoc.Close(true);
            wordApp.Visible = true;
        }
    }


}
