using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class FriendshipRepo
    {
        public bool AddFriend(string UserId, int FriendId)
        {
            return false;
        }

        public IEnumerable<Friendship> GetAllFriends(string UserId)
        {
            return null;
        }

        public bool DeleteFriend(string UserId, int FriendId)
        {
            return true;
        }

    }
}