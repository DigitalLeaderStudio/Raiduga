namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Web.Models.Common;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class CommonController : BaseController
	{
		public CommonController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("~/Дякуємо")]
		public ActionResult Thanks()
		{
			return View();
		}

		// GET: Common
		public ActionResult _SliderPartial()
		{
			var model = new List<SliderItemViewModel>();

			foreach (var dbItem in DbContext.SliderItems.ToArray())
			{
				model.Add(_modelTransformer.GetViewModel<SliderItemViewModel>(dbItem));
			}

			return PartialView(model);
		}

		public ActionResult _FooterPartial()
		{
			var dbData = DbContext.Affiliates.First(a => a.IsPrimary);
			var viewModel = _modelTransformer.GetViewModel<AffiliateViewModel>(dbData);

			return PartialView(viewModel);
		}

		public ActionResult _HtmlContentPartial(string contentName)
		{
			var dbData = DbContext.HtmlContents.Where(hc => hc.Name == contentName).First();
			var viewModel = _modelTransformer.GetViewModel<HtmlContentViewModel>(dbData);

			return PartialView(viewModel);
		}
	}
}