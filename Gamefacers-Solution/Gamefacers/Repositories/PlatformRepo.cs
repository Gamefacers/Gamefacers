using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gamefacers.Models;

namespace Gamefacers.Repositories
{
    public class PlatformRepo : IPlatformRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void CreatePlatform(Platform platform)
        {
            db.Platforms.Add(platform);
            db.SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return (from plat in db.Platforms select plat).ToList();
        }
    }
}