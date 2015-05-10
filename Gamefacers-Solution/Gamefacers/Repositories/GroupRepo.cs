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

        public IEnumerable<Group> GetYourGroups(int UserId)
        {
            
            return (from groups in db.Groups where UserId == 1 select groups).ToList();
        }
    }
}