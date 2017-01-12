using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(userAuthentication.Startup))]
namespace userAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
