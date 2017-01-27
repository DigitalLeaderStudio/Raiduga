namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class ContactController : BaseController
	{
		[Route("Контакти")]
		public ActionResult Index()
		{
			var model = new List<AffiliateViewModel>();

			foreach (var affiliate in DbContext.Affiliates.OrderByDescending(a => a.IsPrimary).ToArray())
			{
				model.Add(new AffiliateViewModel().FromDbModel(affiliate));
			}

			return View(model);
		}

		public ActionResult _ContactFormPartial()
		{
			return PartialView(new ContactRequestViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<PartialViewResult> ContactRequest(ContactRequestViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var dbData = model.ToDbModel();
					dbData.CreationDate = DateTime.Now;

					DbContext.ContactRequests.Add(dbData);
					model.SuccessfullySent = true;
					
					model.RedirectLink = Url.Action("Thanks", "Common");

					await DbContext.SaveChangesAsync();
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}

			model.Errors = ModelState.Values.SelectMany(m => m.Errors)
								 .Select(e => e.ErrorMessage)
								 .ToList();

			return PartialView("_ContactFormPartial", model);
		}
	}
}