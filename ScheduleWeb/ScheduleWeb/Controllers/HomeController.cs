using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleWeb.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace ScheduleWeb.Controllers
{
    public class HomeController : Controller
    {
        ScheduleContext scheduleContext = new ScheduleContext();
        public ActionResult Index()
        {
            IEnumerable<Teach> teaches = scheduleContext.Teaches;
            ViewBag.Teaches = teaches;
            return View();
        }
        public ActionResult InstitutionW()
        {
            IEnumerable<Institution> institution = scheduleContext.Institutiones;
            ViewBag.Institutiones = institution;
            return View();
        }
        //public ActionResult Lesson()
        //{
        //    IEnumerable<Lisson> lessons = scheduleContext.Lessons;
        //    ViewBag.Lessons = lessons;
        //    return View();
        //}
        [HttpPost]
        public void Index(Teach teach)
        {

            scheduleContext.Teaches.Add(teach);
            scheduleContext.SaveChanges();
            Response.Redirect(Request.Url.ToString());
        }
        [HttpPost]
        public void InstitutionW(Institution institution)
        {
            scheduleContext.Institutiones.Add(institution);
            //scheduleContext.SaveChanges();
            //Response.Redirect(Request.Url.ToString());
            scheduleContext.SaveChanges();
            Response.Redirect(Request.Url.ToString());

        }
    }
}