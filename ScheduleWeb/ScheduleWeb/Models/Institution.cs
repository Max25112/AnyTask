using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScheduleWeb.Models
{
    public class Institution
    {
        [Key]
        public int InstID { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// название
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// регион
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// город
        /// </summary>
    }
}