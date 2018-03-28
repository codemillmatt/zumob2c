using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ZumoB2C.Startup))]

namespace ZumoB2C
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}