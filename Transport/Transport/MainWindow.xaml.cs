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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FilePath { get; set; }
        string[] Itemstring;

        public MainWindow()
        {
            InitializeComponent();
        }
        public class transport
        {
            public string Bus { get; set; }
            public string Stay { get; set; }
            public string LicenseNumber { get; set; }
            public string Model { get; set; }
            public string Driver { get; set; }
            public string Conductor { get; set; }
            public int Time { get; set; }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
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
                Model = "Kia Granbird",
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
                    Model = splitededStr[3],
                    Driver = splitededStr[4],
                    Conductor = splitededStr[5],
                    Time = Int32.Parse(splitededStr[6])
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
    }
}
