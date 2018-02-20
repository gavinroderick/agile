using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agile.Startup))]
namespace Agile
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
