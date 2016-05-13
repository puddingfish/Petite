using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Petite.Web.Startup))]
namespace Petite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
        }
    }
}
