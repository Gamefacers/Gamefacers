using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    interface IStatusCommentRepo
    {
        void PostComment(StatusComment newComment);
        IEnumerable<StatusComment> GetStatusComments(IEnumerable<int> StatusId);
    }
}
