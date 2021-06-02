using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppTMA.Models;

namespace WebAppTMA.Controllers
{
    public class AccountController : Controller
    {
        TMAdb db = new TMAdb();
        // GET: Account
        public ActionResult Index()
        {
            var a = db.users.ToList();
            return View(a);
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user user,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //string filename = Path.GetFileNameWithoutExtension(user.ImagFile.FileName);
                //string extension = Path.GetExtension(user.ImagFile.FileName);
                //filename = filename + extension;
                //user.profile = "~/imageee/" + filename;
                //filename = Path.Combine(Server.MapPath("~/imageee/"), filename);
                //user.ImagFile.SaveAs(filename);
                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string extension = Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/imageee/"), _filename);
                user.profile = "~/imageee/" + _filename;
                file.SaveAs(path);
                db.users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");

            }



                ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);     
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user u)
        {
            var status = db.users.Where(x => x.Name == u.Name && x.Password == u.Password).FirstOrDefault();
            if(status!=null)
            {
                FormsAuthentication.SetAuthCookie(u.Name, false);
                return RedirectToAction("index", "Dashborad");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", u.RoleId);
            return View(u);

        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}