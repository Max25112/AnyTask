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

namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //private void FillListView()
        //{
        //    List<string> columnNames = new List<string> { "Маршрут", "Автобус", "Госномер", "Модель", "Водитель", "Кондуктор", "Время" };
        //    List<string> bindingColumns = new List<string>(columnNames.Count) { "Route", "Bus", "LicenseNumber", "Model", "Driver", "Conductor", "Time" };
        //    Очищаем
        //    LvItemData.Items.Clear();
        //    Создаем GridView
        //    GridView gv = new GridView();
        //    gv.AllowsColumnReorder = true;
        //    Создаем колонки
        //    for (int i = 0; i < columnNames.Count; i++)
        //    {
        //        GridViewColumn gvc = new GridViewColumn();
        //        gvc.Header = columnNames[i];
        //        Binding bind = new Binding(bindingColumns[i]);
        //        gvc.DisplayMemberBinding = bind;
        //        gv.Columns.Add(gvc);
        //    }
        //    LvItemData.View = gv;
        //    LvItemData.ItemsSource = DataList;
        //}

        //public class SomeObject
        //{
        //    public int Length { get; set; }
        //    public int Width { get; set; }
        //    public int Height { get; set; }
        //    public int Weight { get; set; }

        //    public SomeObject(int Length, int Width, int Height, int Weight)
        //    {
        //        this.Length = Length;
        //        this.Width = Width;
        //        this.Height = Height;
        //        this.Weight = Weight;
        //    }
        //}
        public List<string[]> ArrayCollection { get; set; }
        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
