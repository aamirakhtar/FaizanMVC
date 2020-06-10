﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;
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

            ViewBag.departments = ce.Departments.ToList();
            ViewData["departments"] = ce.Departments.ToList();


            #region ADO.Net
            /*
            string connString = ConfigurationManager.ConnectionStrings["DefaultConn"].ToString();

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("select * from department", conn);

            //command.Parameters.AddWithValue("@Name", userName);
            //command.Parameters.AddWithValue("@Description", "hello");
            conn.Open();
            var reader = cmd.ExecuteReader();
            reader.Close();

            List<Department> departments = new List<Department>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    //ORM
                    Department dept = new Department();
                    dept.Id = rdr.GetInt32(0);
                    dept.Name = rdr.GetString(1);
                    dept.Location = rdr.GetString(2);
                    dept.DepartmentHead = rdr.GetString(3);

                    departments.Add(dept);
                    //ORM

                    //The 0 stands for "the 0'th column", so the first column of the result.
                    // Do somthing with this rows string, for example to put them in to a list
                }
            }

            conn.Close();

            ViewBag.departments = departments.ToList();
            */
            #endregion

            return View();
        }

        public ActionResult Test()
        {
            TempData["msg"] = "hello";
            return RedirectToAction("index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string location, string departmentHead)
        {
            ////Department is a data object which is made by Entity Framework. Its a db table snapshot converted into class
            //Department dept = new Department();
            //dept.Name = name;
            //dept.Location = location;
            //dept.DepartmentHead = departmentHead;

            ////Company Entities is a connection string
            //CompanyEntities ce = new CompanyEntities();

            ////System.Data.Entity.EntityState is crud operation enum
            //ce.Entry(dept).State = System.Data.Entity.EntityState.Added;
            //ce.SaveChanges();

            #region ADO.Net
            string connString = ConfigurationManager.ConnectionStrings["DefaultConn"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            //SqlCommand command = new SqlCommand("insert into department values(@Name,@Location,@DepartmentHead)", conn);
            //command.Parameters.AddWithValue("@Name", name);
            //command.Parameters.AddWithValue("@Location", location);
            //command.Parameters.AddWithValue("@DepartmentHead", departmentHead);

            SqlCommand command = new SqlCommand($"insert into department values('{name}','{location}','{departmentHead}')", conn);

            conn.Open();
            var reader = command.ExecuteNonQuery();
            conn.Close();
            #endregion

            ViewBag.msg = "Department Added Successfully";

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