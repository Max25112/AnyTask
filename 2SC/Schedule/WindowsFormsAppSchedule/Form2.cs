using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsAppSchedule
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var lesson = new LessonDay() { Lesson = new Lesson() };
            if (lesson.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(lesson.Lesson);
            }
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "расписание|*.xml" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;
            var lesson = new Lessons()
            {
                Day = textBox1.Text,
                Class = textBox2.Text,
                LessonDay = listBox1.Items.OfType<Lesson>().ToList()
            };
            var xs = new XmlSerializer(typeof(Lessons));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, lesson);
            file.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = listBox1.SelectedItem is LessonDay;
        }
    }
}
