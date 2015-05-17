using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class FriendshipRepo : IFriendshipRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void AddFriend(Friendship newFriend)
        {

            db.Friendships.Add(newFriend);
            db.SaveChanges();

        }

        public IEnumerable<String> GetAllFriends(string UserId)
        {
            return (from friend in db.Friendships where UserId.Contains(friend.UserId) select friend.FriendId).ToList();
        }


        

    }
}