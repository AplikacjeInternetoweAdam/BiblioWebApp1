using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiblioWebApp.Startup))]
namespace BiblioWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
