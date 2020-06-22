using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab02.Startup))]
namespace Lab02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
