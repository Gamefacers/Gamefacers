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

       
        public ActionResult AddFriend(string id)
        {
            Friendship newFriendship = new Friendship
            {
                UserId = User.Identity.GetUserId(),
                FriendId = id,
            };
                
                friendsRepo.AddFriend(newFriendship);


            return Redirect("/Profile/ProfileIndex?id=" + id  );
           
        }

        



     
        
    }
}
