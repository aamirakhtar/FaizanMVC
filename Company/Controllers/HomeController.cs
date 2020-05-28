using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome from Home/Index";
        }
    }
}