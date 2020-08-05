using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shoop.Startup))]
namespace Shoop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
