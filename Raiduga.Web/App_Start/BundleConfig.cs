namespace Raiduga.Web
{
	using Raiduga.Web.App_Start;
	using System.Web;
	using System.Web.Optimization;

	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));

			bundles.Add(new LessBundle("~/Content/less")
				.Include("~/Content/less/lib.less",
						 "~/Content/less/site.less"));

			bundles.Add(new LessBundle("~/Content/slider-less")
			.Include("~/Content/less/slider.less"));

			bundles.Add(new StyleBundle("~/Content/fonts").Include(
				"~/Content/font-awesome-4.7.0/css/font-awesome.css"
				));

			RegisterAdminBundles(bundles);
		}

		public static void RegisterAdminBundles(BundleCollection bundles)
		{
			bundles.Add(new LessBundle("~/Content/Admin/less")
			.Include("~/Areas/Admin/Content/admin.less"));
		}
	}
}
