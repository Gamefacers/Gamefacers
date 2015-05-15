using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class StatusCommentRepo : IStatusCommentRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void PostComment(StatusComment newComment)
        {
           
            db.StatusComments.Add(newComment);
            db.SaveChanges();
        }

        public string EditComment(int StatusCommentId)
        {
            return null;
        }
    }
}