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
        

        // GET: Group
        public ActionResult GroupList()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<GroupMember> groups = groupRepo.GetGroupMembers(User.Identity.GetUserId());
                
               
                return View(groups);
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }

        public ActionResult GroupIndex(int id)
        {
            //IEnumerable<GroupMember> members = groupRepo.GetGroupMembers();
            
           // ViewBag.fullName = user.GetFullName()
            ViewBag.photo = groupRepo.GetPhotoUrl(id);
            ViewBag.desc = groupRepo.GetGroupDesc(id);

            return View();
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

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Group/Edit/5
        [HttpPost]
        public ActionResult PostStatus(int id, FormCollection collection)
        {
            var newStatusText = collection["StatusText"];
            
            Status newStatus = new Status
            {
                StatusText = newStatusText,
                DateCreated = DateTime.Now,
                UserId = User.Identity.GetUserId(),
                GroupId = id,
                };

            statusRepo.PostStatus(newStatus);


             return RedirectToAction("GroupIndex","Group");
          
        }

        // GET: Group/Delete/5
        public ActionResult Join(int id)
        {
            return View();
        }

        // POST: Group/Delete/5
        [HttpPost]
        public ActionResult Join(int id, FormCollection collection)
        {
            try
            {
                GroupMember newGroupMember = new GroupMember
                {
                    GroupId = id,
                    UserId = User.Identity.GetUserId()
                };
                
                groupRepo.JoinGroup(newGroupMember);

                return Redirect("/Group/" + id.ToString());
            }
            catch
            {
                return View();
            }
        }
    }
}
