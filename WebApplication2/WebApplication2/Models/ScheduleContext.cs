using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebCoreSchedule2.Models
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Teach> Teaches { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
