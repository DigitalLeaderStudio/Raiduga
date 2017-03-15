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
	using System.Web.Mvc;

	public class CampaignController : BaseAdminController
	{
		public CampaignController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/HtmlContent
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

		// GET: Admin/HtmlContent/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Admin/HtmlContent/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/HtmlContent/Create
		[HttpPost]
		public ActionResult Create(CampaignViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					//var item = model.ToDbModel();
					var item = _modelTransformer.GetEntity<Campaign>(viewModel);
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

		// GET: Admin/HtmlContent/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Campaigns.Find(id);

			return View(_modelTransformer.GetViewModel<CampaignViewModel>(originalItem));
		}

		// POST: Admin/HtmlContent/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, CampaignViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var originalItem = DbContext.Campaigns.Find(id);

					originalItem.UpdationDate = DateTime.Now;
					originalItem.Name = viewModel.Name;
					originalItem.BodyHtml = viewModel.BodyHtml;
					originalItem.EndDate = viewModel.EndDate;
					originalItem.StartDate = viewModel.StartDate;
					originalItem.IsActive = viewModel.IsActive;
					originalItem.IsContactFormVisible = viewModel.IsContactFormVisible;

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

		// GET: Admin/HtmlContent/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Campaigns.Find(id);

			return View(_modelTransformer.GetViewModel<CampaignViewModel>(originalItem));
		}

		// POST: Admin/HtmlContent/Delete/5
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
