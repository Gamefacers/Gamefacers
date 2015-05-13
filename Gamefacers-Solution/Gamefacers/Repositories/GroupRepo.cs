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

        public IEnumerable<GroupMember> GetYourGroups(string UserId)
        {
            return (from member in db.GroupMembers where member.UserId == UserId select member).ToList();
        }

        public IEnumerable<Group> GetAllGroups(int PlatformId)
        {
            return (from everygroup in db.Groups where everygroup.PlatformId == PlatformId select everygroup).ToList();
            
        }

        public void JoinGroup(GroupMember Member)
        {
            db.GroupMembers.Add(Member);
            db.SaveChanges();
        }

        public void CreateGroup(string UserId, int GroupId, int PlatformId, string GroupDesc, string GroupName, int StatusId)
        {
            Group NewGroup = new Group();
            NewGroup.PlatformId = PlatformId;
            NewGroup.GroupName = GroupName;
            NewGroup.GroupDesc = GroupDesc;

            db.Groups.Add(NewGroup);
            db.SaveChanges();
        }

        public int LeaveGroup(int GroupId)
        {
            return 0;
        }
    }
}