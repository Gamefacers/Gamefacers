using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class GroupRepo : IGroupRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<string> GetGroupMembersIds(int GroupId)
        {
            return (from member in db.GroupMembers where member.GroupId == GroupId select member.UserId).ToList();
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

     

        public string GetPhotoUrl(int GroupId)
        {
            return (from photo in db.Groups where photo.ID == GroupId select photo.PhotoUrl).Single();
        }

        public string GetGroupDesc(int GroupId)
        {
            return (from desc in db.Groups where desc.ID == GroupId select desc.GroupDesc).Single();
        }


       

        public IEnumerable<Group> GetMyGroupNames(IEnumerable<int> GroupId)
        {
            return (from myGroupName in db.Groups where GroupId.Contains(myGroupName.ID) select myGroupName).ToList();
        }

        public IEnumerable<int> GetMyGroupId(string UserId)
        {
            return
                (from myGroupId in db.GroupMembers where myGroupId.UserId == UserId select myGroupId.GroupId).ToList();
        }





    }
}