using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class StatusComment
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }   
        public DateTime DateCreated { get; set; }
        public string CommentText { get; set; }  
    }
}