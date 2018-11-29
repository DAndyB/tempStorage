using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdvisorSideKickMVC.Startup))]
namespace AdvisorSideKickMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
