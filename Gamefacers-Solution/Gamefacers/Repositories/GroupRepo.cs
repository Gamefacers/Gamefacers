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
            return null;
        }

        public bool JoinGroup(string UserId, int GroupId)
        {
            return true;
        }

        public int CreateGroup()
        {
            return 0;
        }

        public int LeaveGroup(int GroupId)
        {
            return 0;
        }
    }
}