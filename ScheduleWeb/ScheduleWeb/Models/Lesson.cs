using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScheduleWeb.Models
{
    public class Lesson
    {
        [Key]
        public int LesID { get; set; }
        public string Discplina { get; set; }
        /// <summary>
        /// предмет дисциплина
        /// </summary>
        public string Klass { get; set; }
        /// <summary>
        /// Класс аудиория
        /// </summary>
        public string Domashka { get; set; }
        /// <summary>
        /// домашняя работа
        /// </summary>
    }
}