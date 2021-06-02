using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppTMA.Models;

namespace WebAppTMA.Controllers
{
    public class NotifictionController : Controller
    {
        private TMAdb db = new TMAdb();

      public ActionResult notifimain()
        {
            return View();
        }
     
        public ActionResult Index()
        {
            var notifactions = db.Notifactions.Include(n => n.User);
            return PartialView(notifactions.ToList());
        }

        // GET: Notifiction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifaction notifaction = db.Notifactions.Find(id);
            if (notifaction == null)
            {
                return HttpNotFound();
            }
            return View(notifaction);
        }
        
        // GET: Notifiction/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name");
            return PartialView();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NotifiType,NotifisubmitTo,NotifisubmitFrom,UserId")] Notifaction notifaction)
        {
            if (ModelState.IsValid)
            {
                db.Notifactions.Add(notifaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", notifaction.UserId);
            return View(notifaction);
        }

        // GET: Notifiction/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifaction notifaction = db.Notifactions.Find(id);
            if (notifaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", notifaction.UserId);
            return PartialView(notifaction);
        }

       
        [HttpPost]
      
        public ActionResult Edit([Bind(Include = "Id,NotifiType,NotifisubmitTo,NotifisubmitFrom,UserId")] Notifaction notifaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notifaction).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("notifimain");
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", notifaction.UserId);
            return View(notifaction);
        }

        
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Notifaction notifaction = db.Notifactions.Find(id);
        //    if (notifaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(notifaction);
        //}

        // POST: Notifiction/Delete/5
        [HttpPost]
       
        public ActionResult Delete(int id)
        {
            Notifaction notifaction = db.Notifactions.Find(id);
            db.Notifactions.Remove(notifaction);
            db.SaveChanges();
            return RedirectToAction("notifimain");
        }

        
    }
}
