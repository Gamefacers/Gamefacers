using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamefacers.Startup))]
namespace Gamefacers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
