using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogAM.Startup))]
namespace BlogAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
