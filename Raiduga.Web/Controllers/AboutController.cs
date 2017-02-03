namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Interface;
	using Raiduga.Models;
	using Raiduga.Web.Models.Common;
	using System.Linq;
	using System.Web.Mvc;

	public class AboutController : BaseController
	{
		private IModelTransformer<HtmlContent, HtmlContentViewModel> _htmlContentTransformer;

		public AboutController(IComponentContext componentContext)
			: base(componentContext)
		{
			_htmlContentTransformer = componentContext.Resolve<IModelTransformer<HtmlContent, HtmlContentViewModel>>();
		}

		public AboutController()
		{
		}

		[Route("~/Про-нас")]
		public ActionResult Index()
		{
			var dbData = DbContext.HtmlContents.Where(hc => hc.Name == "About").First();
			var viewModel = _htmlContentTransformer.GetViewModel(dbData);

			return View(viewModel);
		}
	}
}