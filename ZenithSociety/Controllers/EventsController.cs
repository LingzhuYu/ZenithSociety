using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using ZenithSociety.Models;
using System.Data.Entity.Migrations;

namespace ZenithSociety.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(m => m.Activity).Include(n => n.ApplicationUser);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Gets Activity Id from db and places it in @event
            var eventList = db.Events.Include(m => m.Activity);
            var currentEvent = eventList.Where(m => m.EventId == id).First();

            Event @event = db.Events.Find(id);
            @event.ActivityId = currentEvent.ActivityId;

            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDescription");
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,StartDate,EndDate,Id,CreationDate,IsActive,ActivityId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.CreationDate = DateTime.Now;
                @event.Id = User.Identity.GetUserId();
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,StartDate,EndDate,Id,CreationDate,IsActive,ActivityId")] Event @event)
        {
            @event.CreationDate = Convert.ToDateTime(String.Format("{0:MM'/'dd'/'yyyy hh:mm tt}", db.Events.Find(@event.EventId).CreationDate));
            @event.Id = db.Events.Find(@event.EventId).Id;

            if (ModelState.IsValid)
            {
                //db.Entry(@event).State = EntityState.Modified;
                db.Events.AddOrUpdate(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Gets Activity Id from db and places it in @event
            var eventList = db.Events.Include(m => m.Activity);
            var currentEvent = eventList.Where(m => m.EventId == id).First();

            Event @event = db.Events.Find(id);
            @event.ActivityId = currentEvent.ActivityId;

            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
