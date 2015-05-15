using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class FrontPageViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<Friendship> Friendships { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<GroupMember> GroupMembers { get; set; } 
    }
}