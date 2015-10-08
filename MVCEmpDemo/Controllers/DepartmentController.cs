using MVCEmpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;


namespace MVCEmpDemo.Controllers
{

    public class DepartmentController : Controller
    {
        private MVCEntities dbCtx = new MVCEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(dbCtx.Departments.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            if (!ModelState.IsValid) return View(dept);
            var ExiastDept = dbCtx.Departments.Where(d => d.DeptName == dept.DeptName).Count();
            if (ExiastDept == 0)
            {
                dbCtx.Departments.Add(dept);
                dbCtx.SaveChanges();
                return RedirectToAction("Index"); 
            }
            else
            {
                ViewBag.SomeError = "Department Is Already Added";
                ViewBag.SucMsg = false;
                return View();
            }
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}