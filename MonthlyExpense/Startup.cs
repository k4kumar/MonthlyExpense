using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonthlyExpense.Startup))]
namespace MonthlyExpense
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
