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

        private IUserRepo user = new UserRepo();
        private IStatusRepo statusRepo = new StatusRepo();
        private IGroupRepo groupRepo = new GroupRepo();
        private IFriendshipRepo friendRepo = new FriendshipRepo();
        private IPlatformRepo platformRepo = new PlatformRepo();
        private IStatusCommentRepo statusCommentRepo = new StatusCommentRepo();



        public ActionResult Index()
        {

            string userId = User.Identity.GetUserId();
            
            IEnumerable<string> getFriendId = friendRepo.GetAllFriends(userId);
            IEnumerable<int> groupId = groupRepo.GetMyGroupId(userId);
            IEnumerable<int> statusId = statusRepo.GetAllMyGroupStatusesIds(groupId);
            FrontPageViewModel viewModel = new FrontPageViewModel
            {
                
                Groups = groupRepo.GetMyGroupNames(groupId),
                Statuses = statusRepo.GetMyGroupStatuses(groupId),
                Platforms = platformRepo.GetAllPlatforms(),
                StatusComments = statusCommentRepo.GetStatusComments(statusId),
                Members = user.GetUsersFromIds(getFriendId)

            };

            

            return View(viewModel);
        }

        public ActionResult MyProfile()
        {
            string userId = User.Identity.GetUserId();
             
            IEnumerable<string> getFriendId = friendRepo.GetAllFriends(userId);
            IEnumerable<int> groupId = groupRepo.GetMyGroupId(userId);
            IEnumerable<int> statusId = statusRepo.GetAllMyGroupStatusesIds(groupId);
            FrontPageViewModel viewModel = new FrontPageViewModel
            {
                Statuses = statusRepo.GetMyStatuses(userId),
                StatusComments = statusCommentRepo.GetStatusComments(statusId),
                Members = user.GetUsersFromIds(getFriendId),
                Groups = groupRepo.GetMyGroupNames(groupId)
            };
            
            ViewBag.email = user.GetEmail(User.Identity.GetUserId());
            ViewBag.user = user.GetFullName(User.Identity.GetUserId());
            return View(viewModel);


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

        [HttpPost]
        public ActionResult PostHomeComment(int StatusId, int GroupId, FormCollection collection)
        {
            var newCommentText = collection["StatusComment.CommentText"];
            if (newCommentText == null)
            {
                return Redirect("/Group/GroupIndex/");
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


                return Redirect("/Home/Index/");
            }


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