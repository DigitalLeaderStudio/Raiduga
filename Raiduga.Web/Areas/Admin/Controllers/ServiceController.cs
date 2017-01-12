namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Common;
	using Raiduga.Web.Models.Service;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class ServiceController : BaseAdminController
	{
		// GET: Admin/Serivce
		public ActionResult Index()
		{
			var model = new List<ServiceViewModel>();

			foreach (var dbItem in DbContext.Services.ToArray())
			{
				model.Add(new ServiceViewModel().FromDbModel(dbItem));
			}

			return View(model);
		}

		// GET: Admin/Slider/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Admin/Slider/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Slider/Create
		[HttpPost]
		public ActionResult Create(ServiceViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					DbContext.Services.Add(item);
					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/Slider/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Set<Service>().Find(id);

			return View(new ServiceViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Slider/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, ServiceViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					var originalItem = DbContext.Set<Service>().Find(id);

					originalItem.Name = model.Name;
					originalItem.Description = model.Description;
					originalItem.BodyHtml = model.BodyHtml;
					originalItem.Image = item.Image;

					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/Slider/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Set<Service>().Find(id);

			return View(new ServiceViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Slider/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, ServiceViewModel item)
		{
			try
			{
				var removableItem = DbContext.Set<Service>().Find(id);
				DbContext.Services.Remove(removableItem);
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
