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

        public IEnumerable<GroupMember> GetGroupMembers(string UserId)
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

        public void CreateGroup(Group group)
        {
          
            db.Groups.Add(group);
            db.SaveChanges();
        }

        public int LeaveGroup(int GroupId)
        {
            return 0;
        }

        public string GetPhotoUrl(int GroupId)
        {
            return (from photo in db.Groups where photo.ID == GroupId select photo.PhotoUrl).Single();
        }

        public string GetGroupDesc(int GroupId)
        {
            return (from desc in db.Groups where desc.ID == GroupId select desc.GroupDesc).Single();
        }

        public IEnumerable<Group> GetYorGroups(string UserId)
        {
            return (from g in db.Groups where g.UserId == UserId select g ).ToList();
        }
    }
}