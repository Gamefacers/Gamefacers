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
            return (from user in db.Users where user.Id == UserId select user.FullName).SingleOrDefault();
        }

        public string GetEmail(string UserId)
        {
            return (from email in db.Users where email.Id == UserId select email.Email).SingleOrDefault();
        }

        public IEnumerable<string> GetUsersIds(string UserId)
        {
            return (from userId in db.Users where userId.Id == UserId select userId.Id).ToList();
        } 

        public IEnumerable<ApplicationUser> GetUsersFromIds(IEnumerable<string> ids)
        {
            return (from user in db.Users where ids.Contains(user.Id) select user).ToList();
        }

        public IEnumerable<string> GetFullNames(IEnumerable<string> UserId)
        {
            return (from names in db.Users where UserId.Contains(names.Id) select names.FullName).ToList();
        }

        public IEnumerable<string> GetAllUsers()
        {
            return (from users in db.Users select users.Id).ToList();
        }
            
        
    }
}