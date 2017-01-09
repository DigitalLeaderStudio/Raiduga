namespace Raiduga.Web.Areas.Admin.Controllers.Base
{
	using Raiduga.DAL;
	using System.Data.Entity;
	using System.Web.Mvc;

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
	}
}