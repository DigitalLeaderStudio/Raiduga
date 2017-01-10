namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class SliderController : BaseAdminController
	{
		// GET: Admin/Slider
		public ActionResult Index()
		{
			var model = new List<SliderItemViewModel>();

			foreach (var dbItem in DbContext.SliderItems.Include(si => si.Image).ToArray())
			{
				model.Add(new SliderItemViewModel().FromDbModel(dbItem));
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
		public ActionResult Create(SliderItemViewModel item)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var sliderItem = item.ToDbModel();

					DbContext.SliderItems.Add(sliderItem);
					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(item);
		}

		// GET: Admin/Slider/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Set<SliderItem>().Find(id);

			return View(new SliderItemViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Slider/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, SliderItemViewModel item)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var sliderItem = item.ToDbModel();

					var originalItem = DbContext.Set<SliderItem>().Find(item.Id);

					originalItem.Title = sliderItem.Title;
					originalItem.SubTitle = sliderItem.SubTitle;
					originalItem.Image = sliderItem.Image;

					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(item);
		}

		// GET: Admin/Slider/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Set<SliderItem>().Find(id);

			return View(new SliderItemViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Slider/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, SliderItemViewModel item)
		{
			try
			{
				var removableItem = DbContext.Set<SliderItem>().Find(id);
				DbContext.SliderItems.Remove(removableItem);
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
