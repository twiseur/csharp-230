using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningCenterWebApp.Startup))]
namespace LearningCenterWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
