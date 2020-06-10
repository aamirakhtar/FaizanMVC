using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            CompanyEntities ce = new CompanyEntities();
            ViewBag.employees = ce.Employees.ToList();

            return View();
        }

        public ActionResult Create()
        {
            CompanyEntities ce = new CompanyEntities();
            ViewBag.departments = ce.Departments.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, int age, int departmentId, string dob)
        {
            CompanyEntities ce = new CompanyEntities();
            ViewBag.departments = ce.Departments.ToList();

            //Employee is a data object which is made by Entity Framework. Its a db table snapshot converted into class
            Employee emp = new Employee();
            emp.Name = name;
            emp.Age = age;
            emp.DepartmentId = departmentId;
            emp.DateOfBirth = DateTime.Parse(dob);

            //Company Entities is a connection string

            //System.Data.Entity.EntityState is crud operation enum
            ce.Entry(emp).State = System.Data.Entity.EntityState.Added;
            ce.SaveChanges();

            ViewBag.msg = "Employee Added Successfully";

            return View();
        }
    }
}