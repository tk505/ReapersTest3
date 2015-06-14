using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReapersTest3.Startup))]
namespace ReapersTest3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
