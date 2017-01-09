namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using System.Web.Mvc;

	public class AdminController : BaseAdminController
	{
		// GET: Admin/Admin
		public ActionResult Index()
		{
			return View();
		}
	}
}