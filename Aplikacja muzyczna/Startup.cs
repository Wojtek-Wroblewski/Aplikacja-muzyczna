using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aplikacja_muzyczna.Startup))]
namespace Aplikacja_muzyczna
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
