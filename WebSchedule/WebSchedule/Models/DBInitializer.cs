using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ScheduleWeb.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<ScheduleContext>
    {
        protected override void Seed(ScheduleContext context)
        {

            //context.Teaches.Add(new Teach() { Position = "Учитель", Category = 1, Subject = "Математика", Name = "Эльвира", Surname = "Каменева" });
            context.Institutiones.Add(new Institution() { Title = "№25", Region = "Свердловская область", City = "Екатеринбург"});
            base.Seed(context);
        }
    }
}