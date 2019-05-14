using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobcardInter.Startup))]
namespace JobcardInter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
