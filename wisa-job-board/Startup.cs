using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WisaJobBoard.Startup))]
namespace WisaJobBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
