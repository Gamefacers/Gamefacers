using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class StatusCommentRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void PostCommnet(string UserId, int StatusId, string CommentText)
        {
            StatusComment comment = new StatusComment();
            comment.UserId = UserId;
            comment.StatusId = StatusId;
            comment.DateCreated = DateTime.Now;
            comment.CommentText = CommentText;

            db.StatusComments.Add(comment);
            db.SaveChanges();
        }

        public string EditComment(int StatusCommentId)
        {
            return null;
        }
    }
}