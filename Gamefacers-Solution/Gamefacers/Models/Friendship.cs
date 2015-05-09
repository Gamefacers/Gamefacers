using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class Friendship
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
    }
}