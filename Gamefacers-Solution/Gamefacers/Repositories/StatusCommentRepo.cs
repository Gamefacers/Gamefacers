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

        public IEnumerable<StatusComment> GetStatusComments(IEnumerable<int> StatusId)
        {
            return (from statusComments in db.StatusComments where StatusId.Contains(statusComments.StatusId) select statusComments).ToList();
        }
    }
}