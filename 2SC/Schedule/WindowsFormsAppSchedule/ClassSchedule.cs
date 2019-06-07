using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppSchedule
{
    public class Lessons
    {
       
        /// <summary>
        /// День
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// Класс
        /// </summary>
        public string Class { get; set; }
        public List<Lesson>  LessonDay{get; set;}

    }
    public class Lesson
    {
        public string Subject { get; set; }
        /// <summary>
        /// предмет дисциплина
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Класс аудиория
        /// </summary>
        public override string ToString()
        {
            return $"Дисциплина: {Subject}, Аудитория: {Audience}";
        }
}

    public class Teach
    {
        public string Position { get; set; }
        /// <summary>
        /// должность
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// категория
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// предмет дисциплина
        /// </summary
        public string Name { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// фамилия
        /// </summary>
       

        public override string ToString()
        {
            return $"Имя: {Name},  Фамилия: {Surname}, Должность: {Position}, Дисциплина: {Subject}, Категория: {Category}";
        }
    }
}
