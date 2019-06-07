using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebSchedule.Models
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
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int LessonsId { get; set; }
            [ForeignKey("LessonsId")]

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
       
    }
}
