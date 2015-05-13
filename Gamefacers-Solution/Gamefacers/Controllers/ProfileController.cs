using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamefacers.Repositories;

namespace Gamefacers.Controllers
{
    public class ProfileController : Controller
    {
        IFriendshipRepo friendRepo = new FriendshipRepo();
        IGroupRepo groupRepo = new GroupRepo();
       
        
        public ActionResult Index()
        {
            return View();
        }
    }
}