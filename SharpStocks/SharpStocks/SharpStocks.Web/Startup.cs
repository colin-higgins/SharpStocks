using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharpStocks.Web.Startup))]
namespace SharpStocks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
