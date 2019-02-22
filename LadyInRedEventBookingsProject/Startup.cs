using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LadyInRedEventBookingsProject.Startup))]
namespace LadyInRedEventBookingsProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
