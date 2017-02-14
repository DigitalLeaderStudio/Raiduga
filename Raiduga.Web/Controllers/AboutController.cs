namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Web.Models.Common;
	using System.Linq;
	using System.Web.Mvc;

	public class AboutController : BaseController
	{
		public AboutController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("~/Про-нас")]
		public ActionResult Index()
		{
			var dbData = DbContext.HtmlContents.Where(hc => hc.Name == "About").First();
			var viewModel = _modelTransformer.GetViewModel<HtmlContentViewModel>(dbData);

			return View(viewModel);
		}
	}
}