namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using System.Web.Mvc;
	using System.Linq;
	using Raiduga.Web.Models.Common;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System;

	public class ContactController : BaseAdminController
	{
		// GET: Admin/Admin
		public ActionResult Index()
		{
			var dbData = DbContext.Affiliates.ToArray();
			var model = new List<AffiliateViewModel>();

			foreach (var item in dbData)
			{
				model.Add(new AffiliateViewModel().FromDbModel(item));
			}

			return View(model);
		}

		// GET: Admin/Contact/Edit/5
		public ActionResult Edit(int id)
		{
			var dbItem = DbContext.Set<Affiliate>().Find(id);

			return View(new AffiliateViewModel().FromDbModel(dbItem));
		}

		// POST: Admin/Contact/Edit/5
		[HttpPost]		
		public ActionResult Edit(int id, AffiliateViewModel item)
		{
			try
			{
				if (ModelState.IsValid)
				{					
					var originalItem = DbContext.Set<Affiliate>().Find(item.Id);

					//If affiliate goes to be primary, reset the others affiliates IsPrimary to false
					if (item.IsPrimary)
					{
						if (!originalItem.IsPrimary)
						{
							foreach (var affiliate in DbContext.Affiliates.ToArray())
							{
								affiliate.IsPrimary = false;
							}
							originalItem.IsPrimary = item.IsPrimary;
						}
					}

					originalItem.Address = item.Address.ToDbModel();
					var originalHours = originalItem.Hours.First();
					originalHours.Start = item.Hours.Start;
					originalHours.End = item.Hours.End;

					originalItem.HtmlDataContacts = item.HtmlDataContacts;
					originalItem.Description = item.Description;

					DbContext.SaveChanges();

					return RedirectToAction("Edit", new { id = id });
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(item);
		}
	}
}