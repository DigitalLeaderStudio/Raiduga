namespace Raiduga.Web.Controllers
{
	using Raiduga.DAL;
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class BaseController : Controller
	{
		private ApplicationDbContext dbContext = null;
		public ApplicationDbContext DbContext
		{
			set { dbContext = value; }
			get
			{
				if (dbContext == null)
				{
					dbContext = ApplicationDbContext.Create();
				}

				return dbContext;
			}
		}

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var viewModel = new AffiliateViewModel().FromDbModel(DbContext.Affiliates.First(a => a.IsPrimary));
			ViewBag.Affiliate = viewModel;

			base.OnActionExecuting(filterContext);
		}

		protected override void Dispose(bool disposing)
		{
			dbContext = null;
			base.Dispose(disposing);
		}
	}
}