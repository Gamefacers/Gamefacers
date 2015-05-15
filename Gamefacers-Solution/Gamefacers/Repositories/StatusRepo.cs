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

        public void PostStatus(Status status)
        {
           
            
            db.Statuses.Add(status);
            db.SaveChanges();
        }

        public string EditStatus(int StatusId)
        {
            return null;
        }

        /*public IEnumerable<Status> GetTime(int StatusId)
        {
            return (from time in db.Statuses where time.ID == StatusId select Status)
        } */

      
    }
}