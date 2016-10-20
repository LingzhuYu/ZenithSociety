using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithSociety.Models;
using System.Data.Entity;


namespace ZenithSociety.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var mondayOfTheWeek = getMondayOfTheWeek();

            var events = db.Events.Include(m => m.Activity).Include(n => n.ApplicationUser)
                           .Where(p => p.IsActive == true);

            ViewBag.DateFormat = "{0:dddd MMMM dd, yyyy}";
            ViewBag.TimeFormat = "{0:h:mm tt}";

            return View(events.ToList().Where(d => (d.StartDate >= mondayOfTheWeek) && (d.EndDate <= mondayOfTheWeek.AddDays(7)))
                        .OrderBy(d => d.StartDate));
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        ////Now displays events pertaining to this week only
        //public ActionResult Show()
        //{
        //    var mondayOfTheWeek = getMondayOfTheWeek();

        //    var events = db.Events.Include(m => m.Activity).Include(n => n.ApplicationUser).Where(p => p.IsActive == true);

        //    ViewBag.DateFormat = "{0:dddd MMMM dd, yyyy}";
        //    ViewBag.TimeFormat = "{0:h:mm tt}";

        //    return View(events.ToList().Where(d => (d.StartDate >= mondayOfTheWeek) && (d.EndDate <= mondayOfTheWeek.AddDays(7))).OrderBy(d => d.StartDate));
        //}

        //Gets the monday of this week using DateTime.Now as basis
        private DateTime getMondayOfTheWeek()
        {
            var currentDay = DateTime.Now;
            var currentHour = currentDay.Hour;
            var currentMinute = currentDay.Minute;
            var currentSecond = currentDay.Second;

            var delta = DayOfWeek.Monday - currentDay.DayOfWeek;

            DateTime mondayOfTheWeek = currentDay.AddDays(delta).AddHours(-1 * currentHour).AddMinutes(-1 * currentMinute).AddSeconds(-1 * currentSecond);
            return mondayOfTheWeek;
        }
    }
}