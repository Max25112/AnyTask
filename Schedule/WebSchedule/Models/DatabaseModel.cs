using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

            public DbSet<DbInstitution> Institutions { get; set; }
            public DbSet<DbLesson> Lessons { get; set; }
            public DbSet<DbTeach> Teaches { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(ScheduleDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }
        public class DbInstitution
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
            public virtual Collection<DbLesson> Lessons { get; set; }
            /// <summary>
            /// Работники
            /// </summary>
            public virtual Collection<DbTeach> Teaches { get; set; }
        }
        public class DbLesson
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LesID { get; set; }
            [ForeignKey("TeachId")]
            public virtual DbTeach Teacher { get; set; }
            public string Discplina { get; set; }
            /// <summary>
            /// предмет дисциплина
            /// </summary>
            public string Class { get; set; }
            /// <summary>
            /// Класс аудиория
            /// </summary>
            public string HomeWork { get; set; }
            /// <summary>
            /// домашняя работа
            /// </summary>
            public virtual DbInstitution Institution { get; set; }
        }
        public class DbTeach
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
            public virtual DbInstitution Institutions { get; set; }
        }
    }  
}
