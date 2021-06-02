using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTMA.Models;

namespace WebAppTMA.Controllers
{
    [Authorize]
    public class DashboradController : Controller
    {
        TMAdb db = new TMAdb();
        // GET: Dashborad
        public ActionResult Index()
        {
            ViewBag.message = db.users.Count();
            ViewBag.s = db.resources.Count();
            ViewData["p"] = db.successDeplyments.Count();

            return View();
        }
    }
}