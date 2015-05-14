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

       
        public ActionResult AddFriend(string FriendId)
        {
            Friendship newFriendship = new Friendship
            {
                UserId = User.Identity.GetUserId(),
                FriendId = FriendId,
            };
                
                friendsRepo.AddFriend(newFriendship);


            return Redirect("/Home/UsersProfile?FriendId=" + FriendId  );
           
        }

        

        public ActionResult GetFriendList(string UserId)
        {
            IEnumerable<Friendship> friend = friendsRepo.GetAllFriends(User.Identity.GetUserId());
            
            return View(friend);
        }

     
        
    }
}
