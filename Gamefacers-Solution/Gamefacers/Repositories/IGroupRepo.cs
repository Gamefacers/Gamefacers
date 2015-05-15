using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public interface IGroupRepo
    {
        IEnumerable<string> GetGroupMembersIds(int GroupId);
        void JoinGroup(GroupMember Member);
        IEnumerable<Group> GetAllGroups(int PlatformId);
        string GetPhotoUrl(int GroupId);
        string GetGroupDesc(int GroupId);
        IEnumerable<int> GetMyGroupId(string UserId);
        IEnumerable<Group> GetMyGroupNames(IEnumerable<int> GroupId);        

        


        void CreateGroup(Group newGroup);
    }
}
