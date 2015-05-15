using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class StatusRepo : IStatusRepo 
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Status> GetAllStatuses(int GroupId)
        {
            return (from status in db.Statuses where status.GroupId == GroupId select status).ToList().OrderByDescending(d => d.DateCreated);

        }

        public void PostStatus(Status status)
        {
           
            
            db.Statuses.Add(status);
            db.SaveChanges();
        }

       public IEnumerable<Status> GetMyStatuses(string UserId)
        {
            return (from myStatus in db.Statuses where myStatus.UserId == UserId select myStatus).ToList().OrderByDescending(d => d.DateCreated);
        }

        public DateTime GetTime(int StatusId)
        {
            return (from time in db.Statuses where time.ID == StatusId select time.DateCreated).Single();
        }

        public IEnumerable<Status> GetMyGroupStatuses(IEnumerable<int> GroupId)
        {
            return (from myGS in db.Statuses where GroupId.Contains(myGS.GroupId) select myGS).ToList().OrderByDescending(d => d.DateCreated);
        }

        public IEnumerable<int> GetAllStatusesIds(int GroupId)
        {
            return (from statusId in db.Statuses where statusId.GroupId == GroupId select statusId.ID).ToList();
        }

        public IEnumerable<int> GetAllMyGroupStatusesIds(IEnumerable<int> GroupId)
        {
            return
                (from myStatusIds in db.Statuses where GroupId.Contains(myStatusIds.GroupId) select myStatusIds.ID).ToList();
        }
    }
}