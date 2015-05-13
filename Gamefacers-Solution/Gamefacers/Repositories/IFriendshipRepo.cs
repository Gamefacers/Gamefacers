using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    interface IFriendshipRepo
    {
        IEnumerable<Friendship> GetAllFriends(string UserId);
        void AddFriend(string UserId, string FriendId);
    }
}
