using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMB.Startup))]
namespace LMB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
