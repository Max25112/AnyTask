using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreSchedule2.Models
{
    public class Teach
    {
        public int ID { get; set; }
        /// <summary>
        /// id
        /// </summary>
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
    }
}
