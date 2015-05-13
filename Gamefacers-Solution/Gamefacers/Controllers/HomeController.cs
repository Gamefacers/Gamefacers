using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamefacers.Models;
using Gamefacers.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Gamefacers.Controllers
{
    public class HomeController : Controller
    {   

        ApplicationUser user = new ApplicationUser();
        IStatusRepo statusRepo = new StatusRepo();
        IGroupRepo groupRepo = new GroupRepo();
        IFriendshipRepo friendRepo = new FriendshipRepo();


       

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult MyProfile()
        {
            var x = User.Identity.GetUserId();
            //var use = new ApplicationUser{FullName = user.FullName, Email = user.Email};
            //IEnumerable<ApplicationUser> use = user.GetInfo(User.Identity.GetUserId());
            return View(x);

            
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
            return View();
        }
    }
}