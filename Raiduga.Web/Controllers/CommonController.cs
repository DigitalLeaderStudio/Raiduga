namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using System.Data.Entity;
	using System.Threading.Tasks;

	public class CommonController : BaseController
	{
		// GET: Common
		public ActionResult _SliderPartial()
		{
			var model = new List<SliderItemViewModel>();

			foreach (var dbItem in DbContext.SliderItems.ToArray())
			{
				model.Add(new SliderItemViewModel().FromDbModel(dbItem));
			}

			return PartialView(model);
		}

		public ActionResult _FooterPartial()
		{
			var dbData = DbContext.Affiliates.First(a => a.IsPrimary);
			var model = new AffiliateViewModel().FromDbModel(dbData);

			return PartialView(model);
		}

		#region contacts

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

		#endregion
	}
}