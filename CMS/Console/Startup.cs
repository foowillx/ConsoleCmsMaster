using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsoleCMS.Startup))]
namespace ConsoleCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
