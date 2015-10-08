using MVCEmpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;

namespace MVCEmpDemo.Controllers
{
    public class HomeController : Controller
    {
        private MVCEntities dbCtx = new MVCEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //GET:LogIn
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel log)
        {
            if (!ModelState.IsValid) return View(log);

            var user = dbCtx.Users.Where(w => w.Username == log.UserName && w.Password == log.Password).FirstOrDefault();

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(log.UserName, false);
                Session["username"] = log.UserName;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMsg = "Invalid user name and pasword";
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            ViewBag.DeptList = dbCtx.Departments.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            ViewBag.DeptList = dbCtx.Departments.ToList(); 
            if (!ModelState.IsValid) return View(u);

            try
            {
                var isUserExist = dbCtx.Users.Where(w => w.Username == u.Username).Count();
                if (isUserExist == 0)
                {
                    dbCtx.Users.Add(u);
                    dbCtx.SaveChanges();

                    ViewBag.Message = "User \"" + u.Username + "\" created successfully! You will redirected in 3 seconds!";
                    ViewBag.Bool = true;

                    Response.AppendHeader("Refresh", "3;url=/Home/Login");
                }
                else
                {
                    ViewBag.Message = "User \"" + u.Username + "\" already exist!";
                    ViewBag.Bool = false;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                    }
                }
                throw;
            }
                //catch (Exception)
            //{
            //    ViewBag.Message = "Something went wrong, Please send your error details here - dsavlani@zerochaos.com";
            //    ViewBag.Bool = false;
            //}
            return View();
        }

        [Authorize]
        public ActionResult Detail()
        {
                var uname = Session["Username"].ToString();
                var user = dbCtx.Users.Where(m => m.Username == uname).FirstOrDefault();
                //User user = dbCtx.Users.Find(name);
                return View(user);
        }
    }
}