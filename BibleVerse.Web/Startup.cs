using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BibleVerse.Web.Startup))]
namespace BibleVerse.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
