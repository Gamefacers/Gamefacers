using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Gamefacers.Models
{
    public class GroupMember
    {
        public int ID { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
    }
}