using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Company;

namespace Company.Controllers
{
    public class AccountController : Controller
    {
        private CompanyEntities ce = new CompanyEntities();

        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User ur = null;
            //Authentication
            if (ce.Users.ToList().Exists(u => u.UserId == user.UserId && u.Password == user.Password))
                ur = ce.Users.ToList().Single(u => u.UserId == user.UserId && u.Password == user.Password);

            if (ur != null)
            {
                //FormsAuthentication.SetAuthCookie(user.UserId, true);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                ur.UserId,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(30),
                                true,
                                ur.Role.Name,
                                FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                return RedirectToAction("index", "home");
            }
            else
                ViewBag.msg = "Invalid Credentials";

            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }

        public static string GetHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString;
        }
    }
}
