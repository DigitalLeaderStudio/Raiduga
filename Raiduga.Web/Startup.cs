using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Raiduga.Web.Startup))]
namespace Raiduga.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
