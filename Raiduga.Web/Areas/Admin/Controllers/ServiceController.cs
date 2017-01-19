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
			var model = new CourseViewModel
			{
				ServiceId = serviceId
			};

			return View(model);
		}

		// POST: Admin/Service/Create
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

		// POST: Admin/Service/5/CreateCourse
		[HttpPost]
		public ActionResult CreateCourse(CourseViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					DbContext.Set<Course>().Add(item);
					DbContext.SaveChanges();

					return RedirectToAction("Edit", new { id = item.ServiceId });
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/Service/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Set<Service>().Find(id);

			return View(new ServiceViewModel().FromDbModel(originalItem));
		}

		// GET: Admin/Service/EditCourse/5
		public ActionResult EditCourse(int id)
		{
			var item = DbContext.Set<Course>().Find(id);

			return View(new CourseViewModel().FromDbModel(item));
		}

		// POST: Admin/Service/Edit/5
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

		// POST: Admin/Service/EditCourse/5
		[HttpPost]
		public ActionResult EditCourse(int id, CourseViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					var originalItem = DbContext.Set<Course>().Find(id);

					originalItem.Name = model.Name;
					originalItem.Duration = model.Duration;
					originalItem.Description = model.Description;
					originalItem.Price = model.Price;
					originalItem.UpdationDate = DateTime.Now;
					originalItem.BodyHtml = model.BodyHtml;

					DbContext.SaveChanges();

					return RedirectToAction("Edit", new { id = originalItem.ServiceId });
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/Service/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Set<Service>().Find(id);

			return View(new ServiceViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Service/Delete/5
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

		// GET: Admin/Service/DeleteCourse/5
		public ActionResult DeleteCourse(int id)
		{
			var originalItem = DbContext.Set<Course>().Find(id);

			return View(new CourseViewModel().FromDbModel(originalItem));
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
