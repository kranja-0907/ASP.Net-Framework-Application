using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RWA_Aplikacija.Startup))]
namespace RWA_Aplikacija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
