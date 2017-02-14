namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Service;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class ServiceController : BaseAdminController
	{
		public ServiceController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/Serivce
		public ActionResult Index()
		{
			var viewModel = new List<ServiceViewModel>();

			foreach (var dbItem in DbContext.Services.ToArray())
			{
				viewModel.Add(_modelTransformer.GetViewModel<ServiceViewModel>(dbItem));
			}

			return View(viewModel);
		}

		public ActionResult ApplyToCourseRequestList()
		{
			var viewModel = new List<ApplyToCourseViewModel>();

			foreach (var dbItem in DbContext.ApplyToCourseRequests.OrderByDescending(x => x.CreationDate).ToArray())
			{
				viewModel.Add(new ApplyToCourseViewModel().FromDbModel(dbItem));
			}

			return View(viewModel);
		}

		[HttpPost]
		public async Task<ActionResult> MarkAsRead(FormCollection form)
		{
			var itemId = int.Parse(form["cr.Id"]);

			var dbItem = DbContext.ApplyToCourseRequests.Find(itemId);
			dbItem.UpdationDate = DateTime.Now;

			await DbContext.SaveChangesAsync();

			return RedirectToAction("ApplyToCourseRequestList");
		}

		// GET: Admin/Service/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Admin/Service/Create
		public ActionResult Create()
		{
			return View();
		}

		// GET: Admin/Service/5/CreateCourse
		public ActionResult CreateCourse(int serviceId)
		{
			var affiliatesSelectList = DbContext.Set<Affiliate>().Select(affiliate =>
				new SelectListItem { Text = affiliate.Address.Name, Value = affiliate.Id.ToString() })
				.ToList();

			var model = new CourseViewModel
			{
				ServiceId = serviceId,
				Affiliates = affiliatesSelectList
			};

			return View(model);
		}

		// POST: Admin/Service/Create
		[HttpPost]
		public ActionResult Create(ServiceViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<Service>(viewModel);

					DbContext.Services.Add(item);
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

		// POST: Admin/Service/5/CreateCourse
		[HttpPost]
		public ActionResult CreateCourse(CourseViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<Course>(viewModel);

					DbContext.Set<Course>().Add(item);
					DbContext.SaveChanges();

					return RedirectToAction("Edit", new { id = item.ServiceId });
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}

		// GET: Admin/Service/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Set<Service>().Find(id);

			return View(_modelTransformer.GetViewModel<ServiceViewModel>(originalItem));
		}

		// GET: Admin/Service/EditCourse/5
		public ActionResult EditCourse(int id)
		{
			var item = DbContext.Set<Course>().Find(id);
			var viewModel = _modelTransformer.GetViewModel<CourseViewModel>(item);

			return View(viewModel);
		}

		// POST: Admin/Service/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, ServiceViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<Service>(viewModel);

					var originalItem = DbContext.Set<Service>().Find(id);

					originalItem.Name = viewModel.Name;
					originalItem.Description = viewModel.Description;
					originalItem.BodyHtml = viewModel.BodyHtml;
					originalItem.Image = item.Image;

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

		// POST: Admin/Service/EditCourse/5
		[HttpPost]
		public ActionResult EditCourse(int id, CourseViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<Course>(viewModel);

					var originalItem = DbContext.Set<Course>().Find(id);

					originalItem.Name = viewModel.Name;
					originalItem.Duration = viewModel.Duration;
					originalItem.Description = viewModel.Description;
					originalItem.Price = viewModel.Price;
					originalItem.UpdationDate = DateTime.Now;
					originalItem.BodyHtml = viewModel.BodyHtml;

					DbContext.SaveChanges();

					return RedirectToAction("Edit", new { id = originalItem.ServiceId });
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}

		// GET: Admin/Service/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Set<Service>().Find(id);

			return View(_modelTransformer.GetViewModel<ServiceViewModel>(originalItem));
		}

		// POST: Admin/Service/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, ServiceViewModel viewModel)
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

		// GET: Admin/Service/DeleteCourse/5
		public ActionResult DeleteCourse(int id)
		{
			var originalItem = DbContext.Set<Course>().Find(id);
			var viewModel = _modelTransformer.GetViewModel<CourseViewModel>(originalItem);

			return View(viewModel);
		}

		// POST: Admin/Service/DeleteCourse/5
		[HttpPost]
		public ActionResult DeleteCourse(int id, CourseViewModel item)
		{
			try
			{
				var removableItem = DbContext.Set<Course>().Find(id);
				DbContext.Set<Course>().Remove(removableItem);
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
