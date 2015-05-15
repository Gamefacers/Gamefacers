using System;
using System.Collections;
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

            string userId = User.Identity.GetUserId();
            IEnumerable<int> groupId = groupRepo.GetMyGroupId(userId);
            FrontPageViewModel viewModel = new FrontPageViewModel
            {
                Groups = groupRepo.GetMyGroupNames(groupId),
                Statuses = statusRepo.GetMyGroupStatuses(groupId),
                Platforms = platformRepo.GetAllPlatforms()
            };
            return View(viewModel);
        }

        public ActionResult MyProfile()
        {
            IEnumerable<Status> myStatuses = statusRepo.GetMyStatuses(User.Identity.GetUserId());

            ViewBag.email = user.GetEmail(User.Identity.GetUserId());
            ViewBag.user = user.GetFullName(User.Identity.GetUserId());
            return View(myStatuses);

            
        }

        public ActionResult PlayStation()
        {

           IEnumerable<Group> pgroups = groupRepo.GetAllGroups(1);

           return View(pgroups);
        }

        public ActionResult Xbox()
        {
            IEnumerable<Group> xgroups = groupRepo.GetAllGroups(2);

            return View(xgroups);
        }

        public ActionResult PC()
        {
            IEnumerable<Group> pcgroups = groupRepo.GetAllGroups(3);

            return View(pcgroups);
        }

        public ActionResult Other()
        {
            IEnumerable<Group> ogroups = groupRepo.GetAllGroups(4);

            return View(ogroups);
        }

        public ActionResult UsersProfile(string FriendId)
        {

            return View();
        }
    }
}