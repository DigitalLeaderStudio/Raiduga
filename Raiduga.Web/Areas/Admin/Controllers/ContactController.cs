namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class ContactController : BaseAdminController
	{
		public ContactController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/Admin
		public ActionResult Index()
		{
			var dbData = DbContext.Affiliates.ToArray();
			var model = new List<AffiliateViewModel>();

			foreach (var item in dbData)
			{
				model.Add(_modelTransformer.GetViewModel<AffiliateViewModel>(item));
			}

			return View(model);
		}

		// GET: Admin/Contact/Edit/5
		public ActionResult Edit(int id)
		{
			var dbItem = DbContext.Set<Affiliate>().Find(id);

			return View(_modelTransformer.GetViewModel<AffiliateViewModel>(dbItem));
		}

		// POST: Admin/Contact/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, AffiliateViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var originalItem = DbContext.Set<Affiliate>().Find(viewModel.Id);

					//If affiliate goes to be primary, reset the others affiliates IsPrimary to false
					if (viewModel.IsPrimary)
					{
						if (!originalItem.IsPrimary)
						{
							foreach (var affiliate in DbContext.Affiliates.ToArray())
							{
								affiliate.IsPrimary = false;
							}
							originalItem.IsPrimary = viewModel.IsPrimary;
						}
					}

					originalItem.Address = _modelTransformer.GetEntity<Address>(viewModel.Address);

					var originalHours = originalItem.Hours.First();
					originalHours.Start = viewModel.Hours.Start;
					originalHours.End = viewModel.Hours.End;

					originalItem.HtmlDataContacts = viewModel.HtmlDataContacts;
					originalItem.Description = viewModel.Description;

					DbContext.SaveChanges();

					return RedirectToAction("Edit", new { id = id });
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}
	}
}