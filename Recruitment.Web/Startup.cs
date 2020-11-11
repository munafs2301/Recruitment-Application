using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recruitment.Web.Startup))]
namespace Recruitment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
