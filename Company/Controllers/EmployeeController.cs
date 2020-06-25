﻿using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Controllers
{
    public class EmployeeController : Controller
    {
        public CompanyEntities ce { get; set; }

        public EmployeeController()
        {
            ce = new CompanyEntities();
        }

        public ActionResult Index()
        {
            ViewBag.employees = ce.Employees.ToList();

            return View();
        }

        //public ActionResult Create()
        //{
        //    ViewBag.departments = ce.Departments.ToList();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(string name, int age, int departmentId, string dob)
        //{
        //    ViewBag.departments = ce.Departments.ToList();

        //    //Employee is a data object which is made by Entity Framework. Its a db table snapshot converted into class
        //    Employee emp = new Employee();
        //    emp.Name = name;
        //    emp.Age = age;
        //    emp.DepartmentId = departmentId;
        //    emp.DateOfBirth = DateTime.Parse(dob);

        //    //Company Entities is a connection string

        //    //System.Data.Entity.EntityState is crud operation enum
        //    ce.Entry(emp).State = System.Data.Entity.EntityState.Added;
        //    ce.SaveChanges();

        //    ViewBag.msg = "Employee Added Successfully";

        //    return View();
        //}

        //public ActionResult Edit(int id)
        //{
        //    ViewBag.employee = ce.Employees.Where(e => e.Id == id).FirstOrDefault();

        //    ViewBag.departments = ce.Departments.ToList();

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, string name, int age, int departmentId, string dob)
        //{
        //    ViewBag.departments = ce.Departments.ToList();

        //    //Employee is a data object which is made by Entity Framework. Its a db table snapshot converted into class
        //    Employee emp = new Employee();
        //    emp.Id = id;
        //    emp.Name = name;
        //    emp.Age = age;
        //    emp.DepartmentId = departmentId;
        //    emp.DateOfBirth = DateTime.Parse(dob);

        //    //Company Entities is a connection string

        //    //System.Data.Entity.EntityState is crud operation enum
        //    ce.Entry(emp).State = System.Data.Entity.EntityState.Modified;
        //    ce.SaveChanges();

        //    ViewBag.employee = emp;

        //    ViewBag.msg = "Employee Updated Successfully";

        //    return View();
        //}

        public ActionResult Delete(int id)
        {
            ViewBag.employee = ce.Employees.Where(e => e.Id == id).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public ActionResult DeleteSubmit(int id)
        {
            try
            {
                Employee employee = ce.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (ce.Employees.ToList().Exists(e => e.Id == id))
                {
                    //Department is a data object which is made by Entity Framework. Its a db table snapshot converted into class

                    ce.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                    ce.SaveChanges();

                    TempData["msg"] = $"Employee: '{employee.Name}' Deleted Successfully";
                }
                else
                {
                    TempData["msg"] = $"Employee does not exist";
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }

            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            ViewBag.employee = ce.Employees.Where(e => e.Id == id).FirstOrDefault();

            return View();
        }

        #region Models

        public ActionResult Create()
        {
            //ViewBag.departments = ce.Departments.ToList();

            EmployeeModel model = new EmployeeModel();

            model.employee = new Employee();
            model.departments = ce.Departments.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            //ViewBag.departments = ce.Departments.ToList();
            model.departments = ce.Departments.ToList();

            //System.Data.Entity.EntityState is crud operation enum
            ce.Entry(model.employee).State = System.Data.Entity.EntityState.Added;
            ce.SaveChanges();

            ViewBag.msg = "Employee Added Successfully";

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            EmployeeModel model = new EmployeeModel();

            model.employee = ce.Employees.Where(e => e.Id == id).FirstOrDefault();
            model.departments = ce.Departments.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            model.departments = ce.Departments.ToList();

            //System.Data.Entity.EntityState is crud operation enum
            ce.Entry(model.employee).State = System.Data.Entity.EntityState.Modified;
            ce.SaveChanges();

            ViewBag.employee = model.employee;

            ViewBag.msg = "Employee Updated Successfully";

            return View(model);
        }

        #endregion
    }
}