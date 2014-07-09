using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using Web.DataAccess;
using Web.Migrations;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
