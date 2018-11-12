using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMediaServer.Startup))]
namespace WebMediaServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
