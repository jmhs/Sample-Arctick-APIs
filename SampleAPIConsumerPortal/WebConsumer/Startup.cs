using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebConsumer.Startup))]
namespace WebConsumer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
