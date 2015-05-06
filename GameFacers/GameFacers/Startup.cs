using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameFacers.Startup))]
namespace GameFacers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
