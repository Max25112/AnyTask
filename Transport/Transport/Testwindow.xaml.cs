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

namespace Transport
{
    /// <summary>
    /// Логика взаимодействия для Testwindow.xaml
    /// </summary>
    public partial class Testwindow : Window
    {
        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }
        public Testwindow()
        {
            InitializeComponent();
            
        }
    }
}
