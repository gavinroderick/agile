using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgileWebsite.Startup))]
namespace AgileWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
