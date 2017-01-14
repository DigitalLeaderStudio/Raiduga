namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System.Linq;
	using System.Web.Mvc;

	public class AboutController : BaseController
	{
		public ActionResult Index()
		{
			var dbData = DbContext.HtmlContents.Where(hc => hc.Name == "About").First();
			var model = new HtmlContentViewModel().FromDbModel(dbData);

			return View(model);
		}
	}
}