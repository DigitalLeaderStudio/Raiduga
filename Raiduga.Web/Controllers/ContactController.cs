namespace Raiduga.Web.Controllers
{
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
		public async Task<PartialViewResult> ContactRequest(ContactRequestViewModel item)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var dbData = item.ToDbModel();
					dbData.CreationDate = DateTime.Now;

					DbContext.ContactRequests.Add(dbData);
					item.SuccessfullySent = true;

					await DbContext.SaveChangesAsync();
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}

			item.Errors = ModelState.Values.SelectMany(m => m.Errors)
								 .Select(e => e.ErrorMessage)
								 .ToList();

			return PartialView("_ContactFormPartial", item);
		}
	}
}