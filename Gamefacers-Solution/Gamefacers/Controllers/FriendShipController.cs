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
    public class FriendShipController : Controller
    {
        IFriendshipRepo friendsRepo = new FriendshipRepo();

        // GET: FriendShip/Create
        public ActionResult AddFriend()
        {
            return View();
        }

        // POST: FriendShip/Create
        [HttpPost]
        public ActionResult AddFriend(string UserId, string FriendId)
        {
            
            friendsRepo.AddFriend(UserId, FriendId);




            return RedirectToAction("Index", "Home");
           
        }

        

        public ActionResult GetFriendList(string UserId)
        {
            IEnumerable<Friendship> friend = friendsRepo.GetAllFriends(User.Identity.GetUserId());
            
            return View(friend);
        }

     
        
    }
}
