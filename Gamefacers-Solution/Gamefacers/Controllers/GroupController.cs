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
        IGroupRepo groupRepo = new GroupRepo();

        // GET: Group
        public ActionResult GroupList()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<GroupMember> groups = groupRepo.GetYourGroups(User.Identity.GetUserId());
                
               
                return View(groups);
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        public ActionResult GroupIndex()
        {
          //  ViewBag.photo = groupRepo.

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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
