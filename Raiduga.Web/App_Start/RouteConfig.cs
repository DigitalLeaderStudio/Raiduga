namespace Raiduga.Web
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;

	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Service",
				url: "{Service}",
				defaults: new { controller = "Service", action = "Index" },
				namespaces: new[] { "Raiduga.Web.Controllers" }
			);

			routes.MapRoute(
				name: "Service_Id",
				url: "{Service}/{id}",
				defaults: new { controller = "Service", action = "CoursesList", id = UrlParameter.Optional },
				namespaces: new[] { "Raiduga.Web.Controllers" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				namespaces: new[] { "Raiduga.Web.Controllers" }
			);
		}
	}
}
