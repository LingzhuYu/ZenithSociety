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
            var events = db.Events.Include(m => m.Activity).Include(n => n.ApplicationUser);
            events.OrderByDescending(d => d.StartDate);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Show()
        {
            var events = db.Events.Include(m => m.Activity).Include(n => n.ApplicationUser);
            events.OrderByDescending(d => d.StartDate);

            ViewBag.DateFormat = "{0:dddd MMMM dd, yyyy}";
            ViewBag.TimeFormat = "{0:h:mm tt}";

            return View(events.ToList());
        }
    }
}