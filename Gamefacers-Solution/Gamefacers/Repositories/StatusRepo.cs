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
            return (from status in db.Statuses where GroupId == 1 select status).ToList();

        }

    }
}