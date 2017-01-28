namespace Raiduga.Web.Areas.Admin.Controllers.Base
{
	using Raiduga.DAL;
	using System.Data.Entity;
	using System.Web.Mvc;
	using System.Linq;

	[Authorize(Roles = "Admin")]
	public class BaseAdminController : Controller
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

		protected override void Dispose(bool disposing)
		{
			dbContext = null;
			base.Dispose(disposing);
		}

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);

			ViewBag.NewMessagesCount = DbContext.ContactRequests.Count(cr => !cr.UpdationDate.HasValue);

			ViewBag.ApplyToCourseRequestsCount = DbContext.ApplyToCourseRequests.Count(acr => !acr.UpdationDate.HasValue);
		}
	}
}