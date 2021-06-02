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
    public class ComplainController : Controller
    {
        private TMAdb db = new TMAdb();
        public ActionResult maincom()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var complains = db.Complains.ToList();
            return PartialView(complains.ToList());
        }

        // GET: Complain/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        
       

       
      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,complainType,complaindata,UserId")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(complain);
        }

        // GET: Complain/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // POST: Complain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complain complain = db.Complains.Find(id);
            db.Complains.Remove(complain);
            db.SaveChanges();
            return RedirectToAction("maincom");
        }

      
    }
}
