using Gamefacers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamefacers.Models;
using Microsoft.AspNet.Identity;

namespace Gamefacers.Controllers
{
    public class GroupController : Controller
    {
        IUserRepo user = new UserRepo();
        IGroupRepo groupRepo = new GroupRepo();
        IStatusRepo statusRepo = new StatusRepo();
        IStatusCommentRepo statusCommentRepo = new StatusCommentRepo();
        

        // GET: Group
        public ActionResult GroupList()
        {
            if (User.Identity.IsAuthenticated)
            {
              
                
               
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }
        //GET: GroupPage/GroupId
        public ActionResult GroupIndex(int id)
        {

            
            IEnumerable<string> membersUserIds = groupRepo.GetGroupMembersIds(id);
            GroupIndexViewModels viewModel = new GroupIndexViewModels()
            {
                Members = user.GetUsersFromIds(membersUserIds),
                Statuses = statusRepo.GetAllStatuses(id),


                
            };

            ViewBag.photo = groupRepo.GetPhotoUrl(id);
            ViewBag.desc = groupRepo.GetGroupDesc(id);
            ViewBag.Id = id;
           

            return View(viewModel);
        }

        
        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var newGroupName = collection["GroupName"];
            var newGroupPhotoUrl = collection["PhotoUrl"];
            var nPLatformId = collection["PlatformId"];
           
            var newGroupDesc = collection["GroupDesc"];
            Group newGroup = new Group 
            { GroupName = newGroupName, 
                PhotoUrl = newGroupPhotoUrl, 
                PlatformId = Convert.ToInt32(nPLatformId), 
                GroupDesc = newGroupDesc};

            groupRepo.CreateGroup(newGroup);
            
                


                return RedirectToAction("Index", "Home");
           
        }

      

        //POST: PostStatus/GroupId
        [HttpPost]
        public ActionResult PostStatus(int id, FormCollection collection)
        {
            var newStatusText = collection["Status.StatusText"];
            if (newStatusText == null)
            {
                return Redirect("/Group/GroupIndex/" + id.ToString());
            }
            
            else
            {
                Status newStatus = new Status
                {
                    StatusText = newStatusText,
                    DateCreated = DateTime.Now,
                    UserId = User.Identity.GetUserId(),
                    GroupId = id,
                };

                statusRepo.PostStatus(newStatus);


                return Redirect("/Group/GroupIndex/" + id.ToString());
            }
        }

        // GET: Group/Join/GroupId
        public ActionResult Join(int id)
        {
            GroupMember newGroupMember = new GroupMember
            {
                GroupId = id,
                UserId = User.Identity.GetUserId()
            };

            groupRepo.JoinGroup(newGroupMember);

            return Redirect("/Group/GroupIndex/" + id.ToString());
        }

        [HttpPost]
        public ActionResult PostComment(int StatusId, int GroupId, FormCollection collection)
        {
            var newCommentText = collection["StatusComment.CommentText"];
            if (newCommentText == null)
            {
                return Redirect("/Group/GroupIndex/" + GroupId.ToString() );
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


                return Redirect("/Group/GroupIndex/" + GroupId.ToString());
            }
        }

       
        
    }
}
