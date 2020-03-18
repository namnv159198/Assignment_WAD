using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assigment_WAD.Startup))]
namespace Assigment_WAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
