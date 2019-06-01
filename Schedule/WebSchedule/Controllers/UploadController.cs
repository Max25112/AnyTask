using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WindowsFormsAppSchedule;
using WebSchedule.Models.DataAccessPostgreSqlProvider;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            return View();
        }



        public ActionResult List()
        {
            List<DbInstitution> list;
            using (var db = new ScheduleDbContext())
            {
                list = db.Institutions.Include(s => s.Lessons).ToList();
                list = db.Institutions.Include(s => s.Teaches).ToList();
            }

            return View(list);
        }


       
    }
}