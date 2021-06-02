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
    public class projectsController : Controller
    {
        private TMAdb db = new TMAdb();

       public ActionResult mainproject()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var successDeplyments = db.successDeplyments.Include(s => s.User);
            return PartialView(successDeplyments.ToList());
        }

       

        // GET: projects/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name");
            return PartialView();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,project_Name,project_Budget,project_Status,UserId")] SuccessDeplyment successDeplyment)
        {
            if (ModelState.IsValid)
            {
                db.successDeplyments.Add(successDeplyment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", successDeplyment.UserId);
            return View(successDeplyment);
        }

        // GET: projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuccessDeplyment successDeplyment = db.successDeplyments.Find(id);
            if (successDeplyment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", successDeplyment.UserId);
            return PartialView(successDeplyment);
        }

        
        [HttpPost]
       
        public ActionResult Edit([Bind(Include = "Id,project_Name,project_Budget,project_Status,UserId")] SuccessDeplyment successDeplyment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(successDeplyment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("mainproject");
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", successDeplyment.UserId);
            return View(successDeplyment);
        }

        // GET: projects/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SuccessDeplyment successDeplyment = db.successDeplyments.Find(id);
        //    if (successDeplyment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(successDeplyment);
        //}

        // POST: projects/Delete/5
        [HttpPost]
      
        public ActionResult Delete(int id)
        {
            SuccessDeplyment successDeplyment = db.successDeplyments.Find(id);
            db.successDeplyments.Remove(successDeplyment);
            db.SaveChanges();
            return RedirectToAction("mainproject");
        }

        
    }
}
