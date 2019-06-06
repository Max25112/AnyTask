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
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsAppSchedule
{
    public partial class AdminTeacherWindow : Form
    {
       // public List<TeacherWin> listTeach = new List<TeacherWin>();
        public string spath = @"D:\AnyTask\Schedule\WindowsFormsAppSchedule\bin\Debug\teach.xml";
        string fileContent = string.Empty;
        string filePath = string.Empty;

        void CreateXML()
        {
            XDocument doc = new XDocument(new XElement("Teachers"));

            doc.Root.Add(new XElement("Teacher",
                new XElement("Position", "Учитель"),
                new XElement("Category", "II"),
                new XElement("Subject", "Русский язык"),
                new XElement("Name", "Вера"),
                new XElement("Surname", "Дедушева")));

            doc.Save(spath);
        }
        public void OpenDial()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"D:\AnyTask\Schedule\WindowsFormsAppSchedule\bin\Debug";
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

        }
        public void SaveDial()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    //Get the path of specified file
                    filePath = saveFileDialog1.FileName;
                    myStream.Close();
                }
            }

        }
        public AdminTeacherWindow()
        {
            InitializeComponent();
        }
       // XmlSerializer formatter = new XmlSerializer(typeof(TeacherWin));
        private static void Xml()
        {
            var doc = new XmlDocument();
            doc.Load("XMLFile.xml");

            XmlNode root = doc.DocumentElement;

            XmlElement elem = doc.CreateElement("ip");
            elem.InnerText = "PEREMENNAYA";

            root.ReplaceChild(elem, root.FirstChild);

            doc.Save(Console.Out);
        }

        private void Button1_Click(object sender, EventArgs e)
        {


            XDocument xmlDoc = XDocument.Load("teach.xml");
            var list = xmlDoc.Root.Elements("id")
                           .Select(element => element.Value)
                           .ToList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //CreateXML();
            OpenDial();
            //TeacherWin teach = new TeacherWin(PositionBox.Text, Convert.ToInt64(CategoryBox.Text), SubjectBox.Text, NameBox.Text, SurnameBox.Text);

            XDocument doc = XDocument.Load(filePath);

            doc.Root.Add(new XElement("Teacher",
                new XElement("Position", PositionBox.Text),
                new XElement("Category", CategoryBox.Text),
                new XElement("Subject", SubjectBox.Text),
                new XElement("Name", NameBox.Text),
                new XElement("Surname", SurnameBox.Text)));
            doc.Save(filePath);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            XDocument doc = new XDocument(new XElement("Teachers"));

            doc.Root.Add(new XElement("Teacher",
                new XElement("Position", PositionBox.Text),
                new XElement("Category", CategoryBox.Text),
                new XElement("Subject", SubjectBox.Text),
                new XElement("Name", NameBox.Text),
                new XElement("Surname", SurnameBox.Text)));
            SaveDial();
            doc.Save(filePath);
        }
    }
    //[Serializable]
    //public class TeacherWin : Teach
    //{

    //    // стандартный конструктор без параметров
    //    public TeacherWin()
    //    { }

    //    public TeacherWin(string position, int category, string subject, string name, string surname)
    //    {
    //        Position = position;
    //        Category = category;
    //        Subject = subject;
    //        Name = name;
    //        Surname = surname;
    //    }

    //    public static implicit operator TeacherWin(TeacherWin v)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
