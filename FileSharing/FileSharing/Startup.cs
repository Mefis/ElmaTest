using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileSharing.Startup))]
namespace FileSharing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
