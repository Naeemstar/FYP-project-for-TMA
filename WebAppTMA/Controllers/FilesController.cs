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
    public class FilesController : Controller
    {
        private TMAdb db = new TMAdb();
        public ActionResult mainfile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
           
            return PartialView(db.files.ToList());
        }

        // GET: Files/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name");
            return PartialView();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( File file)
        {
            if (ModelState.IsValid)
            {
                var a = User.Identity.Name;
                var usr = db.users.Where(x=>x.Email==a).FirstOrDefault().UserId;
                file.submit_from = usr.ToString();
                db.files.Add(file);
                db.SaveChanges();
               
                return RedirectToAction("Index");
                
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name");
            return View(file);
        }

        // GET: Files/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return PartialView(file);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,sumitionDate,FilePath,submit_to,submit_from")] File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("mainfile");
            }
            return View(file);
        }

        // GET: Files/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    File file = db.files.Find(id);
        //    if (file == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(file);
        //}

        // POST: Files/Delete/5
        [HttpPost]
        
        public ActionResult Delete(int id)
        {
            File file = db.files.Find(id);
            db.files.Remove(file);
            db.SaveChanges();
            return RedirectToAction("mainfile");
        }

        
    }
}
