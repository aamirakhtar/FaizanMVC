using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        public class LogEntry
        {
            public string date { get; set; }
            public string type { get; set; }
            public string severity { get; set; }
            public string msg { get; set; }
            public string color { get; set; }
        }

        public ActionResult Index()
        {
            //List<LogEntry> logEntries = new List<LogEntry>();

            //List<string> lines = System.IO.File.ReadAllLines("D:/faizan_log.txt").ToList();

            //foreach (var line in lines)
            //{
            //    string str = "[00:00:57.546|BCRM|3] Skip update records because the service is paused Type a message";

            //    string[] msgParts = str.Split('|');                

            //    LogEntry logEntry = new LogEntry();
            //    logEntry.date = msgParts[0].Trim('[');
            //    logEntry.type = msgParts[1];
            //    logEntry.severity = msgParts[2].Split(']')[0];
            //    logEntry.msg = msgParts[2].Split(']')[1].Trim(' ');

            //    logEntries.Add(logEntry);
            //}

            //foreach(var entry in logEntries)
            //{
            //    if(entry.severity == "3")
            //    {
            //        entry.color = "red";
            //    }
            //}

            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}