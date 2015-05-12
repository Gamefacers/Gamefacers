using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamefacers.Models;
using Gamefacers.Repositories;
using Microsoft.AspNet.Identity;

namespace Gamefacers.Controllers
{
    public class HomeController : Controller
    {
        IStatusRepo statusRepo = new StatusRepo();
        IGroupRepo groupRepo = new GroupRepo();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Group> groups = groupRepo.GetYourGroups(User.Identity.GetUserId());
                return View(groups);
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
            
        }

        public ActionResult MyProfile()
        {
            ViewBag.Message = "Your Profile page.";

            return View();
        }

        public ActionResult Notification()
        {
            ViewBag.Message = "Your Notification page.";

            return View();
        }

        public ActionResult PlayStation()
        {
            ViewBag.Message = "Playstation Page";

            return View();
        }

        public ActionResult Xbox()
        {
            ViewBag.Message = "Xbox Page";

            return View();
        }

        public ActionResult PC()
        {
            ViewBag.Message = "PC Page";

            return View();
        }

        public ActionResult Other()
        {
            ViewBag.Message = "Other Page";

            return View();
        }

        public ActionResult UsersProfile()
        {
            ViewBag.Message = "UsersProfile";

            return View();
        }
    }
}