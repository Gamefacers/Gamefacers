using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public int PlatformId { get; set; }
        public string GroupDesc { get; set; }


    }
}