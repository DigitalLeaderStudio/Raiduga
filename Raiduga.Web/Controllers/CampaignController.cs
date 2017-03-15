namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Common;
	using Simplify.Mail;
	using System.Data.Entity;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class CampaignController : BaseController
	{
		public CampaignController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("Акції/{compaignName}")]
		public async Task<ActionResult> Index(string compaignName)
		{
			var dbData = await DbContext.HtmlContents.Where(hc => hc.Name == compaignName).FirstOrDefaultAsync();

			var viewModel = _modelTransformer.GetViewModel<HtmlContentViewModel>(dbData);

			return View(viewModel);
		}
	}
}