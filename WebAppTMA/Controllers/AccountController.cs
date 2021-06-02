using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using WebAppTMA.Models;
using System.Net;

namespace WebAppTMA.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        TMAdb db = new TMAdb();
        // GET: Account
        public ActionResult toindex()
        {
            return View();
        }
        public ActionResult Index(/*string search*/)
        {
           
            var a = db.users.Include(x=>x.Role).ToList();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    a = a.Where(p =>p.Name!=null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            //}
            return PartialView(a);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
            return PartialView(user);
        }
        [HttpPost]
        public ActionResult Edit(user user, HttpPostedFileBase Profilepic)
        {
            //var abb = User.Identity.Name;
            //var usr = db.users.Where(x => x.Email == abb).FirstOrDefault().Name;
            //File f = new File();
            //f.sum;yield=
            if (ModelState.IsValid)
            {
                user a = db.users.Find(user.UserId);

                if (Profilepic != null)
                {
                    a.Name = user.Name;
                    a.Contact = user.Contact;
                    a.Email = user.Email;
                    a.Password = user.Password;
                    string filename = Path.GetFileName(Profilepic.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extension = Path.GetExtension(Profilepic.FileName);
                    string path = Path.Combine(Server.MapPath("/imageee/"), _filename);
                    a.profile = "~/imageee/" + _filename;
                    Profilepic.SaveAs(path);
                }
                else
                {
                    a.Name = user.Name;
                    a.Contact = user.Contact;
                    a.Email = user.Email;
                    a.Password = user.Password;


                }
                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("toindex");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);

        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            user user = db.users.Find(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("toindex");
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
                string path = Path.Combine(Server.MapPath("/imageee/"), _filename);
                user.profile = "~/imageee/" + _filename;
                file.SaveAs(path);
                db.users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("toindex");

            }



                ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);     
        }
        [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Login(user u)
        {
            var status = db.users.Where(x => x.Email == u.Email && x.Password == u.Password).FirstOrDefault();
            if (status != null)
            {
                FormsAuthentication.SetAuthCookie(u.Email, false);
                return RedirectToAction("index", "Dashborad");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            

        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}