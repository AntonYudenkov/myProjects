using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuessTheNumber.Startup))]
namespace GuessTheNumber
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
