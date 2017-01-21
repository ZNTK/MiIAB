using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiIAB.Startup))]
namespace MiIAB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
