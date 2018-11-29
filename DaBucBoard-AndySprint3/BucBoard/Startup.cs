using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BucBoard.Startup))]
namespace BucBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
