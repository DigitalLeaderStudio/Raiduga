﻿namespace Raiduga.Web
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

			bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
					  "~/Scripts/jquery.unobtrusive-ajax.js",
					  "~/Scripts/jquery.validate.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/site.js",
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/momentJs").Include(
				"~/Scripts/moment.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap-timepicker").Include(
					  "~/Scripts/bootstrap-timepicker/bootstrap-timepicker.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker").Include(
					  "~/Scripts/bootstrap-datetimepicker.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
                      "~/Content/compaign.css",
                      "~/Content/font-awesome.css"));

			bundles.Add(new LessBundle("~/Content/less/styles")
				.Include("~/Content/less/lib.less",
						 "~/Content/less/site.less",
                         "~/Content/less/compaign.less"));

			bundles.Add(new LessBundle("~/Content/slider-less/styles")
				.Include("~/Content/less/slider.less"));

			bundles.Add(new LessBundle("~/Content/timepicker-less/styles").Include(
				"~/Content/less/timepicker.less"));

			RegisterAdminBundles(bundles);
		}

		public static void RegisterAdminBundles(BundleCollection bundles)
		{
			bundles.Add(new LessBundle("~/Content/Admin/less")
			.Include("~/Areas/Admin/Content/admin.less"));
		}
	}
}
