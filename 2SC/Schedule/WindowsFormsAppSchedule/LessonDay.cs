using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSchedule
{
    public partial class LessonDay : Form
    {
        public LessonDay()
        {
            InitializeComponent();
        }
        public Lesson Lesson { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            Lesson.Subject = textBox1.Text;
            Lesson.Audience = textBox2.Text;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Lesson.Subject = textBox1.Text;
            Lesson.Audience = textBox2.Text;
        }
    }
}
