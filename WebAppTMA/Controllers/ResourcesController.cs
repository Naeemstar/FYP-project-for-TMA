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
    public class ResourcesController : Controller
    {
        private TMAdb db = new TMAdb();

       public ActionResult mainIndex()
        {
            return View();
        }
        public ActionResult Index()
        {
            return PartialView(db.resources.ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resources resources = db.resources.Find(id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        // GET: Resources/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,quantity")] Resources resources)
        {
            if (ModelState.IsValid)
            {
                db.resources.Add(resources);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resources);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            
            Resources resources = db.resources.Find(id);
            
            return PartialView(resources);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,quantity")] Resources resources)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resources).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("mainIndex");
            }
            return View(resources);
        }

        // GET: Resources/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Resources resources = db.resources.Find(id);
        //    if (resources == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(resources);
        //}

        // POST: Resources/Delete/5
        [HttpPost]
        
        public ActionResult Delete(int? id)
        {
            Resources resources = db.resources.Find(id);
            db.resources.Remove(resources);
            db.SaveChanges();
            return RedirectToAction("mainIndex");
        }

       
    }
}
