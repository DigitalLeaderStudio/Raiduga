namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.DAL;
	using System.Web.Mvc;

	public class BaseController : Controller
	{
		#region fields and props

		private readonly IComponentContext _componentContext;

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

		#endregion

		#region constructors

		public BaseController()
		{

		}

		public BaseController(IComponentContext componentContext)
		{
			_componentContext = componentContext;
		}

		#endregion

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
		}

		protected override void Dispose(bool disposing)
		{
			dbContext = null;
			base.Dispose(disposing);
		}
	}
}