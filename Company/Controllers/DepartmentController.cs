using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Controllers
{
    public class DepartmentController : Controller
    {
        public string Index()
        {
            return "Welcome faizan from Department/Index";
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
    }
}