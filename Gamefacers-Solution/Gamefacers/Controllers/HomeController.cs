using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamefacers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }

        public ActionResult MyProfile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Notification()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}