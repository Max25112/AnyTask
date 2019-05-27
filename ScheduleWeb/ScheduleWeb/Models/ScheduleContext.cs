using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ScheduleWeb.Models
{
    public class ScheduleContext : DbContext
    {
        
        public DbSet<Teach> Teaches { get; set; } 
        public DbSet<Institution> Institutiones { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}