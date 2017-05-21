using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheArmedairProject.Startup))]
namespace TheArmedairProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
