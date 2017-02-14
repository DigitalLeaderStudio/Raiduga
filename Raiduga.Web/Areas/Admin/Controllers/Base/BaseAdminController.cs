namespace Raiduga.Web.Areas.Admin.Controllers.Base
{
	using Raiduga.DAL;
	using System.Data.Entity;
	using System.Web.Mvc;
	using System.Linq;
	using Autofac;
	using Raiduga.Interface;

	[Authorize(Roles = "Admin")]
	public class BaseAdminController : Controller
	{
		protected readonly IComponentContext _componentContext;
		protected IModelTransformer _modelTransformer;

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

		public BaseAdminController()
		{

		}

		public BaseAdminController(IComponentContext componentContext)
		{
			_componentContext = componentContext;
			_modelTransformer = componentContext.Resolve<IModelTransformer>();
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