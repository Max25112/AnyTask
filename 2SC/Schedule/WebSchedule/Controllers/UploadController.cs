using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WindowsFormsAppSchedule;
using WebSchedule.Models.DataAccessPostgreSqlProvider;


namespace WebSchedule.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(Lessons));
                var lesssons = (Lessons)xs.Deserialize(stream);


                using (var db = new ScheduleDbContext())
                {
                    var dbs = new DbLessons()
                    {
                        Day = lesssons.Day,
                        Class = lesssons.Class,
                    };
                    dbs.LessonDay = new Collection<DbLesson>();
                    foreach (var lesson in lesssons.LessonDay)
                    {
                        dbs.LessonDay.Add(new DbLesson()
                        {
                            Subject = lesson.Subject,
                            Audience = lesson.Audience
                        });
                    }
                    db.Lessons.Add(dbs);
                    db.SaveChanges();
                }

                return View(lesssons);
            }
        }



        public ActionResult List()
        {
            List<DbLessons> list;
            using (var db = new ScheduleDbContext())
            {
                list = db.Lessons.Include(s => s.LessonDay).ToList();
            }

            return View(list);
        }

    }
}