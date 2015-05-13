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


     
        
        
        
        
        
        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            string discription = collection["GroupDesc"];

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
