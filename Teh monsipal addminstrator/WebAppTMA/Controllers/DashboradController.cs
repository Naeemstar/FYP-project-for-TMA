using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTMA.Controllers
{      [Authorize]
    public class DashboradController : Controller
    {
        // GET: Dashborad
        public ActionResult Index()
        {
            return View();
        }
    }
}