using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class GroupRepo : IGroupRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Group> GetYourGroups(string UserId)
        {
            
            return (from g in db.Groups where g.UserId == UserId select g).ToList();
        }

        public IEnumerable<Group> GetAllGroups(int PlatformId)
        {
            return (from everygroup in db.Groups where everygroup.PlatformId == PlatformId select everygroup).ToList();
            
        }

        public void JoinGroup(string UserId, int GroupId)
        {

        }

        public void CreateGroup(string UserId, int GroupId, int PlatformId, string GroupDesc, string GroupName, int StatusId)
        {
            Group NewGroup = new Group();
            NewGroup.PlatformId = PlatformId;
            NewGroup.UserId = UserId;
            NewGroup.GroupName = GroupName;
            NewGroup.GroupDesc = GroupDesc;
            NewGroup.StatusId = StatusId;

            db.Groups.Add(NewGroup);
            db.SaveChanges();
        }

        public int LeaveGroup(int GroupId)
        {
            return 0;
        }
    }
}