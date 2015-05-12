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
            return (from status in db.Statuses where status.GroupId == GroupId select status).ToList();

        }

        public void PostStatus(string UserId, int GroupId, string StatusText)
        {
            Status status = new Status();
            status.UserId = UserId;
            status.DateCreated = DateTime.Now;
            status.GroupId = GroupId;
            status.StatusText = StatusText;

            db.Statuses.Add(status);
            db.SaveChanges();
        }

        public string EditStatus(int StatusId)
        {
            return null;
        }
    }
}