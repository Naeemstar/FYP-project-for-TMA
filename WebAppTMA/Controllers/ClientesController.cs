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
    public class ClientesController : Controller
    {
        private TMAdb db = new TMAdb();
        [HttpGet]
        public ActionResult mainpage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView(db.clientes.ToList());
        }

      
       

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,clientType,address,phone")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
           
            var client  = db.clientes.Find(id);
           
            return PartialView(client);
        }

       
        [HttpPost]
      
        public ActionResult Edit(Clientes clientes)
        {

            db.Entry(clientes).State = System.Data.Entity.EntityState.Modified;
            
            db.SaveChanges();
            return RedirectToAction("mainpage");
            
            
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var client = db.clientes.Find(id);
            db.clientes.Remove(client);
            db.SaveChanges();

            return RedirectToAction("mainpage");
        }
        // GET: Clientes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Clientes clientes = db.clientes.Find(id);
        //    if (clientes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clientes);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int? id)
        //{
        //    var client = db.clientes.Find(id);
        //    db.clientes.Remove(client);
        //    db.SaveChanges();
        //    return RedirectToAction("index");
        //}


    }
}
