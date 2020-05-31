using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            CompanyEntities ce = new CompanyEntities();

            //ViewBag.departments = ce.Departments.ToList();
            ViewData["departments"] = ce.Departments.ToList();

            return View();
        }

        public ViewResult Welcome()
        {
            return View();
        }

        public string WelcomeWithDate()
        {
            return "Welcome Faizan" + DateTime.Now.ToString();
        }

        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(string name, string location, string departmentHead)
        {
            //Department is a data object which is made by Entity Framework. Its a db table snapshot converted into class
            Department dept = new Department();
            dept.Name = name;
            dept.Location = location;
            dept.DepartmentHead = departmentHead;

            //Company Entities is a connection string
            CompanyEntities ce = new CompanyEntities();

            //System.Data.Entity.EntityState is crud operation enum
            ce.Entry(dept).State = System.Data.Entity.EntityState.Added;
            ce.SaveChanges();

            return View();
        }

        //Parameterized
        //public ActionResult AddDepartmentSubmit(string name, string location, string departmentHead)
        //{
        //    //Department is a data object which is made by Entity Framework. Its a db table snapshot converted into class
        //    Department dept = new Department();
        //    dept.Name = name;
        //    dept.Location = location;
        //    dept.DepartmentHead = departmentHead;

        //    //Company Entities is a connection string
        //    CompanyEntities ce = new CompanyEntities();

        //    //System.Data.Entity.EntityState is crud operation enum
        //    ce.Entry(dept).State = System.Data.Entity.EntityState.Added;
        //    ce.SaveChanges();

        //    return RedirectToAction("index");
        //}

        //Context Object
        //public ActionResult AddDepartmentSubmit()
        //{
        //    //Department is a data object which is made by Entity Framework. Its a db table snapshot converted into class
        //    Department dept = new Department();
        //    dept.Name = Request.Form["name"];
        //    dept.Location = Request.Form["location"];
        //    dept.DepartmentHead = Request.Form["departmentHead"];

        //    //Company Entities is a connection string
        //    CompanyEntities ce = new CompanyEntities();

        //    //System.Data.Entity.EntityState is crud operation enum
        //    ce.Entry(dept).State = System.Data.Entity.EntityState.Added;
        //    ce.SaveChanges();

        //    return RedirectToAction("index");
        //}
    }
}