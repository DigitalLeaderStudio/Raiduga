namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System.Linq;
	using System.Web.Mvc;
	using RouteLocalization.Mvc;
	using RouteLocalization.Mvc.Extensions;
	using RouteLocalization.Mvc.Setup;

	public class AboutController : BaseController
	{
		[Route("~/Про-нас")]
		public ActionResult Index()
		{
			var dbData = DbContext.HtmlContents.Where(hc => hc.Name == "About").First();
			var model = new HtmlContentViewModel().FromDbModel(dbData);

			return View(model);
		}
	}
}