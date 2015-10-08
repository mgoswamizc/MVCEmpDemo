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

        public ActionResult Edit(int? id)
        {
            Department department = dbCtx.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department dept)
        {
            if (!ModelState.IsValid) return View(dept);

            dbCtx.Entry(dept).State = EntityState.Modified;
            dbCtx.SaveChanges();
            return RedirectToAction("Index");            
        }

        public ActionResult Delete(int? id)
        {
            Department department = dbCtx.Departments.Find(id);
            dbCtx.Departments.Remove(department);
            dbCtx.SaveChanges();            
            return RedirectToAction("Index");
        }
    }
}