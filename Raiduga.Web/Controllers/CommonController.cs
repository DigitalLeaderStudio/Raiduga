namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Interface;
	using Raiduga.Models;
	using Raiduga.Web.Models.Common;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class CommonController : BaseController
	{
		private IModelTransformer<SliderItem, SliderItemViewModel> _sliderTransformer;
		private IModelTransformer<Affiliate, AffiliateViewModel> _affiliateTransformer;
		private IModelTransformer<HtmlContent, HtmlContentViewModel> _htmlContentTransformer;

		public CommonController(IComponentContext componentContext)
			: base(componentContext)
		{
			_affiliateTransformer = componentContext.Resolve<IModelTransformer<Affiliate, AffiliateViewModel>>();
			_sliderTransformer = componentContext.Resolve<IModelTransformer<SliderItem, SliderItemViewModel>>();
			_htmlContentTransformer = componentContext.Resolve<IModelTransformer<HtmlContent, HtmlContentViewModel>>();
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
				model.Add(_sliderTransformer.GetViewModel(dbItem));
			}

			return PartialView(model);
		}

		public ActionResult _FooterPartial()
		{
			var dbData = DbContext.Affiliates.First(a => a.IsPrimary);
			var viewModel = _affiliateTransformer.GetViewModel(dbData);

			return PartialView(viewModel);
		}

		public ActionResult _HtmlContentPartial(string contentName)
		{
			var dbData = DbContext.HtmlContents.Where(hc => hc.Name == contentName).First();
			var viewModel = _htmlContentTransformer.GetViewModel(dbData);

			return PartialView(viewModel);
		}
	}
}