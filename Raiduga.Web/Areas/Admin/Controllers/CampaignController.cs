namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Campaign;
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Web.Mvc;

	public class CampaignController : BaseAdminController
	{
		const string CONTACTS_LINK_PATTERN = "{{contacts-link-pattern}}";

		public CampaignController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/Campaign
		public ActionResult Index()
		{
			var dbData = DbContext.Campaigns.ToArray();

			var model = new List<CampaignViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(_modelTransformer.GetViewModel<CampaignViewModel>(dbItem));
			}

			return View(model);
		}

		// GET: Admin/Campaign/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Admin/Campaign/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Campaign/Create
		[HttpPost]
		public ActionResult Create(CampaignViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<Campaign>(viewModel);

					item.Name =
						Regex.Replace(viewModel.Name.ToLower()
						.Replace(@"'", String.Empty), @"[^\w]+", "-");

					item.BodyHtml =
						viewModel.BodyHtml
						.Replace(CONTACTS_LINK_PATTERN, Url.Action("Index", "Contact", new { area = "" }));

					item.CreationDate = DateTime.Now;

					DbContext.Campaigns.Add(item);
					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}

		// GET: Admin/Campaign/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Campaigns.Find(id);

			return View(_modelTransformer.GetViewModel<CampaignViewModel>(originalItem));
		}

		// POST: Admin/Campaign/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, CampaignViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var originalItem = DbContext.Campaigns.Find(id);

					originalItem.Name =
						Regex.Replace(viewModel.Name.ToLower()
						.Replace(@"'", String.Empty), @"[^\w]+", "-");

					originalItem.Title = viewModel.Title;
					originalItem.BodyHtml =
						viewModel.BodyHtml
						.Replace(CONTACTS_LINK_PATTERN, Url.Action("Index", "Contact", new { area = "" }));
					originalItem.EndDate = viewModel.EndDate;
					originalItem.StartDate = viewModel.StartDate;
					originalItem.IsActive = viewModel.IsActive;
					originalItem.IsContactFormVisible = viewModel.IsContactFormVisible;

					originalItem.UpdationDate = DateTime.Now;

					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}

		// GET: Admin/Campaign/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Campaigns.Find(id);

			return View(_modelTransformer.GetViewModel<CampaignViewModel>(originalItem));
		}

		// POST: Admin/Campaign/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, CampaignViewModel item)
		{
			try
			{
				var removableItem = DbContext.Campaigns.Find(id);

				removableItem.IsActive = false;
				removableItem.DeletionDate = DateTime.Now;

				DbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
