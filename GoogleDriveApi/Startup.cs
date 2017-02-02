using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoogleDriveApi.Startup))]
namespace GoogleDriveApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
