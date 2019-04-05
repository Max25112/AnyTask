using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Lesson
    {
        public string Subject { get; set; }
        /// <summary>
        /// предмет дисциплина
        /// </summary>
        public string Classes { get; set; }
        /// <summary>
        /// Класс аудиория
        /// </summary>
        public DateTime ClassTime { get; set; }
        /// <summary>
        /// время занятий
        /// </summary>
        //public List<Lesson> Lessons { get; set; }
    }
    public class Institutions
    {
        public string Region { get; set; }
        /// <summary>
        /// регион
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// город
        /// </summary>
        public string Institution { get; set; }
        /// <summary>
        /// учреждение
        /// </summary>
        public string Teaches { get; set; }
        /// <summary>
        /// учитель преподаватель
        /// </summary>
        
    }
    public class Teach
    {
        public string Position { get; set; }
        /// <summary>
        /// должность
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// категория
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// фамилия
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// предмет дисциплина
        /// </summary
        public List<Teach> Teaches { get; set;}
        public override string ToString()
        {
            return $"Имя: {Name},  Фамилия: {Surname}, Должность: {Position}, Дисциплина: {Subject}, Категория: {Category}";
        }
    }
}
