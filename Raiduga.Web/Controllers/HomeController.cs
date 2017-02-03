namespace Raiduga.Web.Controllers
{
	using Raiduga.Interface;
	using System.Web.Mvc;

	public class HomeController : BaseController
	{
		public HomeController()
		{
		}

		[Route("")]
		public ActionResult Index()
		{
			return View();
		}
	}
}