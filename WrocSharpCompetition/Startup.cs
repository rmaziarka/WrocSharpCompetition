using System.Globalization;
using System.Threading;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WrocSharpCompetition.Startup))]
namespace WrocSharpCompetition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");

            System.Data.Entity.Database.SetInitializer(new ApplicatioDbInitializer());

            ConfigureAuth(app);
        }
    }
}
