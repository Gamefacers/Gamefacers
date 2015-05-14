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

        IUserRepo user = new UserRepo();
        IStatusRepo statusRepo = new StatusRepo();
        IGroupRepo groupRepo = new GroupRepo();
        IFriendshipRepo friendRepo = new FriendshipRepo();
        IPlatformRepo platformRepo = new PlatformRepo();

       

        public ActionResult Index()
        {
            FrontPageViewModel viewModel = new FrontPageViewModel
            {
                Groups = null,
                Platforms = platformRepo.GetAllPlatforms()
            };
            return View(viewModel);
        }

        public ActionResult MyProfile()
        {

            ViewBag.email = user.GetEmail(User.Identity.GetUserId());
            ViewBag.user = user.GetFullName(User.Identity.GetUserId());
            return View();

            
        }

        public ActionResult Notification()
        {
            ViewBag.Message = "Your Notification page.";

            return View();
        }

        public ActionResult PlayStation(int PlatformId)
        {
            IEnumerable<Group> groups = groupRepo.GetAllGroups(PlatformId);

            return View(groups);
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