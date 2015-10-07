using MVCEmpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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
            if (!ModelState.IsValid)
                return View(u);
            return View();
        }
    }
}