using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_456.Startup))]
namespace Lab_456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
