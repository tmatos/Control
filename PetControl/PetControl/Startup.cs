using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetControl.Startup))]
namespace PetControl
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
