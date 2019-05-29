using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebCoreSchedule2.Models
{
    public class Lesson
    {
        [Key]
        public int LesID { get; set; }
        public string Discipline { get; set; }
        /// <summary>
        /// предмет дисциплина
        /// </summary>
        public string Audioria { get; set; }
        /// <summary>
        /// Класс аудиория
        /// </summary>
        public string HomeWork { get; set; }
        /// <summary>
        /// домашняя работа
        /// </summary>
        public string Class { get; set; }
    }
}
