using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization; 

namespace WindowsFormsAppSchedule
{
    
    public partial class AdminLessonWindows : Form
    {
        string FilePath { get; set; }
        public AdminLessonWindows()
        {
            InitializeComponent();
        }

        private void AdminWindows_Load(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void MenuItem_Click(object sender)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
            //TransportList.ItemsSource = ListInitialization();
        }
    }
    [Serializable]
    public class LessonWin  : Lesson
    {
        // стандартный конструктор без параметров
        public LessonWin()
        { }

        public LessonWin(string subject, string classes, DateTime classTime, string homeWork)
        {
            Subject = subject;
             Audience = classes;

        }
    }
}
