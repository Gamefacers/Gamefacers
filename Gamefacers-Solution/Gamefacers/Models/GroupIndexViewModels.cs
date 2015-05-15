using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class GroupIndexViewModels
    {
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public Status Status { get; set; }
    }
}