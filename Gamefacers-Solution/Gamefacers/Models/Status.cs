using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class Status
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }    
        public DateTime DateCreated { get; set; }
        public string StatusText { get; set; }  
    }
}