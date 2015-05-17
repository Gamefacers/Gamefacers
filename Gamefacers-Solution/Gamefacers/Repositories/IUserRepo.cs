using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    interface IUserRepo
    {
        string GetFullName(string UserId);
        string GetEmail(string UserId);
        IEnumerable<ApplicationUser> GetUsersFromIds(IEnumerable<string> ids);
        IEnumerable<string> GetFullNames(IEnumerable<string> UserId);
        IEnumerable<string> GetUsersIds(string UserId);
        IEnumerable<string> GetAllUsers();
    }
}
