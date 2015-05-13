using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamefacers.Models
{
    public class FrontPageViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }

    }
}