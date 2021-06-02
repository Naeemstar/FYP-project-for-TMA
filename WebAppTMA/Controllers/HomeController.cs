using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTMA.Models;

namespace WebAppTMA.Controllers
{
    public class HomeController : Controller
    {
        TMAdb db = new TMAdb();


        public ActionResult Index()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
      public ActionResult Complain()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complain(Complain cmpl)
        {
            db.Complains.Add(cmpl);
            db.SaveChanges();
            //ViewBag.message = "you are successfull complalint";
            return RedirectToAction("msg");
        }
        public ActionResult msg()
        {
            ViewBag.message = "your complalint are successfully Register ";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
           

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact cont)
        {
            db.contacts.Add(cont);
            db.SaveChanges();
            ViewBag.message = "your contact info is sent to the offic";
            return View();
        }

        public ActionResult Gallary()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Team()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       


    }
}