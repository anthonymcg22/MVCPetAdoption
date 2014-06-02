using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetAdoption.Web.Startup))]
namespace PetAdoption.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
