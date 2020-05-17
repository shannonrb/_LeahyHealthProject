using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_LeahyHealthProject.Startup))]
namespace _LeahyHealthProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
