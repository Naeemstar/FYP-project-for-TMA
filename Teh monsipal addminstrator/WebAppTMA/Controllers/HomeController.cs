﻿using System;
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallary()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Team()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}