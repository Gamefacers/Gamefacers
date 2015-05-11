﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public interface IGroupRepo
    {
        IEnumerable<Group> GetYourGroups(string UserId);
    }
}
