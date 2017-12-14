using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MissionaryWebsiteP2.Startup))]
namespace MissionaryWebsiteP2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
