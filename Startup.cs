using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocShare.Startup))]
namespace DocShare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
