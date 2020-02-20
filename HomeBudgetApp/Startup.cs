using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeBudgetApp.Startup))]
namespace HomeBudgetApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
