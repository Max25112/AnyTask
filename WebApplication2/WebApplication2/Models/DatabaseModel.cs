using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebCoreSchedule2.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        public class WebCoreSchedule2DbContext : DbContext
        {
            public WebCoreSchedule2DbContext()
            {

                Database.EnsureCreated();
            }

            public WebCoreSchedule2DbContext(DbContextOptions<WebCoreSchedule2DbContext> options) : base(options)
            {
            }

            public DbSet<Teach> Teaches { get; set; }
            public DbSet<Lesson> Lessons { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(WebCoreSchedule2DbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }
        public class Teach
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public class Lesson
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}
