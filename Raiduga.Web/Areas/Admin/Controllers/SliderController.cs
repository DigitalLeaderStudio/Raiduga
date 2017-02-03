namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Interface;
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
		private IModelTransformer<SliderItem, SliderItemViewModel> _sliderTransformer;

		public SliderController(IComponentContext componentContext)
			: base(componentContext)
		{
			_sliderTransformer = _componentContext.Resolve<IModelTransformer<SliderItem, SliderItemViewModel>>();
		}

		// GET: Admin/Slider
		public ActionResult Index()
		{
			var viewModel = new List<SliderItemViewModel>();

			foreach (var dbItem in DbContext.SliderItems.ToArray())
			{
				viewModel.Add(_sliderTransformer.GetViewModel(dbItem));
			}

			return View(viewModel);
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
		public ActionResult Create(SliderItemViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var sliderItem = _sliderTransformer.GetEntity(viewModel);

					DbContext.SliderItems.Add(sliderItem);
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

		// GET: Admin/Slider/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Set<SliderItem>().Find(id);
			var viewModel = _sliderTransformer.GetViewModel(originalItem);

			return View(viewModel);
		}

		// POST: Admin/Slider/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, SliderItemViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var sliderItem = _sliderTransformer.GetEntity(viewModel);

					var originalItem = DbContext.Set<SliderItem>().Find(viewModel.Id);

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

			return View(viewModel);
		}

		// GET: Admin/Slider/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Set<SliderItem>().Find(id);
			var viewModel = _sliderTransformer.GetViewModel(originalItem);

			return View(viewModel);
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
