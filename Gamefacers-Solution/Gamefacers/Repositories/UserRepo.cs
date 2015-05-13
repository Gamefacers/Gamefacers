using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamefacers.Models;
using Microsoft.AspNet.Identity;

namespace Gamefacers.Repositories
{
    public class UserRepo : IUserRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public string GetFullName(string UserId)
        {
            return (from user in db.Users where user.Id == UserId select user.FullName).Single();
        }

        public string GetEmail(string UserId)
        {
            return (from email in db.Users where email.Id == UserId select email.Email).Single();
        }
        
            
            
        
    }
}