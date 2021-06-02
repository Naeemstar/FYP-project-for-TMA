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
    public class tbl_RoleController : Controller
    {
         TMAdb db = new TMAdb();
        [HttpGet]
        public ActionResult indexmain()
        {
            return View();
        }
         [HttpGet]
        public ActionResult Index()
        {
            return PartialView(db.Roles.ToList());
        }

        // GET: tbl_Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rolee tbl_Role = db.Roles.Find(id);
            if (tbl_Role == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Role);
        }

        // GET: tbl_Role/Create
        public ActionResult Create()
        {
            return PartialView();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,RoleName")] Rolee tbl_Role)
        {
            if (ModelState.IsValid)
            {
                
                db.Roles.Add(tbl_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Role);
        }

        // GET: tbl_Role/Edit/5
        public ActionResult Edit(int? id)
        {
            
            Rolee tbl_Role = db.Roles.Find(id);
           
            return PartialView(tbl_Role);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rolee tbl_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("indexmain");
            }
            return View(tbl_Role);
        }

        // GET: tbl_Role/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Rolee tbl_Role = db.Roles.Find(id);
        //    if (tbl_Role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_Role);
        //}

        // POST: tbl_Role/Delete/5
        [HttpPost]
       
        public ActionResult Delete(int? id)
        {
            var Role = db.Roles.Find(id);
            db.Roles.Remove(Role);
            db.SaveChanges();
            return RedirectToAction("indexmain");
        }

        
    }
}
