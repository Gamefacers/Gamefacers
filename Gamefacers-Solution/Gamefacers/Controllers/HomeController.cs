﻿using System;
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
                //Groups = groupRepo.GetAllGroups(),
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

        public ActionResult UsersProfile()
        {
            return View();
        }
    }
}