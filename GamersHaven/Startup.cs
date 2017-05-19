using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamersHaven.Startup))]
namespace GamersHaven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
