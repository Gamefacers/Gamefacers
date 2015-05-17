using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public interface IStatusRepo
    {
        void PostStatus(Status status);
        IEnumerable<Status> GetAllStatuses(int GroupId);
        IEnumerable<Status> GetMyStatuses(string UserId);
        IEnumerable<Status> GetMyGroupStatuses(IEnumerable<int> GroupId);
        IEnumerable<int> GetAllStatusesIds(int GroupId);
        IEnumerable<int> GetAllMyGroupStatusesIds(IEnumerable<int> GroupId);
        IEnumerable<string> GetStatusOwner(IEnumerable<int> StatusId);
    }
}
