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
    public class ProfileController : Controller
    {
        IUserRepo userRepo = new UserRepo();  
        IFriendshipRepo friendshipRepo = new FriendshipRepo();
        IStatusCommentRepo statusCommentRepo = new StatusCommentRepo();
        IStatusRepo statusRepo = new StatusRepo();
        IGroupRepo groupRepo = new GroupRepo();

        
        public ActionResult ProfileIndex(string id)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<string> getFriendId = friendshipRepo.GetAllFriends(userId);
            IEnumerable<int> groupId = groupRepo.GetMyGroupId(userId);
            IEnumerable<int> statusId = statusRepo.GetAllMyGroupStatusesIds(groupId);
            
            FrontPageViewModel viewModel= new FrontPageViewModel{
                Members = userRepo.GetUsersFromIds(getFriendId),
                Statuses = statusRepo.GetMyStatuses(id),
                StatusComments = statusCommentRepo.GetStatusComments(statusId)
            };
            ViewBag.name = userRepo.GetFullName(id);
            ViewBag.email = userRepo.GetEmail(id);
            ViewBag.id = id;


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PostProfileComment(int StatusId, int GroupId, FormCollection collection)
        {
            var newCommentText = collection["StatusComment.CommentText"];
            if (newCommentText == null)
            {
                return Redirect("/Home/MyProfile/");
            }

            else
            {
                StatusComment newComment = new StatusComment
                {
                    CommentText = newCommentText,
                    DateCreated = DateTime.Now,
                    UserId = User.Identity.GetUserId(),
                    StatusId = StatusId,
                };

                statusCommentRepo.PostComment(newComment);


                return Redirect("/Home/MyProfile/");
            }

        }
    }
}