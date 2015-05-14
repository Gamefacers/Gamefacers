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
    }
}
