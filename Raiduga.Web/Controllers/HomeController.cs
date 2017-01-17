namespace Raiduga.Web.Controllers
{
	using System.Web.Mvc;

	public class HomeController : BaseController
	{
		[Route("")]
		public ActionResult Index()
		{
			return View();
		}
	}
}