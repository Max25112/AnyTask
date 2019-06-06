using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebApplication.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        // >dotnet ef migration add testMigration in AspNet5MultipleProject
        public class ScheduleDbContext : DbContext
        {
            public ScheduleDbContext()
            {

                Database.EnsureCreated();
            }

            public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
            {
            }

            public DbSet<DbLessons> Lessons { get; set; }
            public DbSet<DbTeach> Teaches { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(ScheduleDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }
        public class DbLessons
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }     
            public string Day { get; set; }
            public string Class { get; set; }
            public virtual Collection<DbLesson> LessonDay { get; set; }

        }
        public class DbLesson
        {
            
            public int ID { get; set; }
            public virtual DbLessons Lessons { get; set; }
            public string Subject { get; set; }
            /// <summary>
            /// предмет дисциплина
            /// </summary>
            public string Audience { get; set; }
            /// <summary>
            /// Класс аудиория
            /// </summary>
        }
        public class DbTeach
        {
            /// <summary>
            /// id
            /// </summary>
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            /// <summary>
            /// должность
            /// </summary>
            public string Position { get; set; }
             /// <summary>
            /// категория
            /// </summary>
            public int Category { get; set; }
           /// <summary>
            /// предмет дисциплина
            /// </summary
            public string Subject { get; set; }
             /// <summary>
            /// имя
            /// </summary>
            public string Name { get; set; }
           /// <summary>
            /// фамилия
            /// </summary>
            public string Surname { get; set; }
            
        }
    }
}
