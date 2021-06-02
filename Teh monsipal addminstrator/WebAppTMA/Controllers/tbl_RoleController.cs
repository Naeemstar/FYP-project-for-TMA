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
        private TMAdb db = new TMAdb();

        // GET: tbl_Role
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
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
            return View();
        }

        // POST: tbl_Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // POST: tbl_Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,RoleName")] Rolee tbl_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Role);
        }

        // GET: tbl_Role/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: tbl_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rolee tbl_Role = db.Roles.Find(id);
            db.Roles.Remove(tbl_Role);
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
