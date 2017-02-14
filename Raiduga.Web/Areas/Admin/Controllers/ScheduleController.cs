namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Article;
	using Raiduga.Web.Models.Schedule;
	using Raiduga.Web.Models.Service;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class ScheduleController : BaseAdminController
	{
		public ScheduleController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/Schedule
		public ActionResult Index()
		{
			var affiliates = DbContext.Affiliates.ToArray();

			var viewModel = new ScheduleViewModelBuilder().BuildSchedule(affiliates);

			return View(viewModel);
		}

		// GET: Admin/Schedule/Create
		public ActionResult Create()
		{
			var viewModel = new LessonViewModel();

			var ageGroups = DbContext.Set<AgeGroup>().ToArray();
			var ageGroupsListItems = new List<SelectListItem>();
			foreach (var ageGroup in ageGroups)
			{
				ageGroupsListItems.Add(new SelectListItem
				{
					Text = ageGroup.Name,
					Value = ageGroup.Id.ToString()
				});
			}

			var allAffiliates = DbContext.Set<Affiliate>().ToArray();
			var affiliatesListItems = new List<SelectListItem>();
			foreach (var affiliate in allAffiliates)
			{
				affiliatesListItems.Add(new SelectListItem
				{
					Text = affiliate.Address.Name,
					Value = affiliate.Id.ToString()
				});
			}

			var allServices = DbContext.Services.ToArray();
			var servicesListItems = new List<SelectListItem>();
			foreach (var service in allServices)
			{
				servicesListItems.Add(new SelectListItem
				{
					Text = service.Name,
					Value = service.Id.ToString()
				});
			}

			viewModel.Services = servicesListItems;
			viewModel.AgeGroups = ageGroupsListItems;
			viewModel.Affiliates = affiliatesListItems;
			viewModel.CoursesCustom = GetCoursesSelectListItems(allAffiliates.First().Id, allAffiliates.First().Id);

			return View(viewModel);
		}

		// POST: Admin/Schedule/Create
		[HttpPost]
		public ActionResult Create(LessonViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var entity = _modelTransformer.GetEntity<Lesson>(viewModel);
					DbContext.Set<Lesson>().Add(entity);

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

		// GET: Admin/Schedule/Edit/5
		public ActionResult Edit(int id)
		{
			var entity = DbContext.Set<Lesson>().Find(id);
			var viewModel = _modelTransformer.GetViewModel<LessonViewModel>(entity);

			var ageGroups = DbContext.Set<AgeGroup>().ToArray();
			var ageGroupsListItems = new List<SelectListItem>();
			foreach (var ageGroup in ageGroups)
			{
				ageGroupsListItems.Add(new SelectListItem
				{
					Text = ageGroup.Name,
					Value = ageGroup.Id.ToString()
				});
			}

			var allAffiliates = DbContext.Set<Affiliate>().ToArray();
			var affiliatesListItems = new List<SelectListItem>();
			foreach (var affiliate in allAffiliates)
			{
				affiliatesListItems.Add(new SelectListItem
				{
					Text = affiliate.Address.Name,
					Value = affiliate.Id.ToString()
				});
			}

			var allServices = DbContext.Services.ToArray();
			var servicesListItems = new List<SelectListItem>();
			foreach (var service in allServices)
			{
				servicesListItems.Add(new SelectListItem
				{
					Text = service.Name,
					Value = service.Id.ToString()
				});
			}

			viewModel.Services = servicesListItems;
			viewModel.AgeGroups = ageGroupsListItems;
			viewModel.Affiliates = affiliatesListItems;
			viewModel.CoursesCustom = GetCoursesSelectListItems(allAffiliates.First().Id, allAffiliates.First().Id);

			return View(viewModel);
		}

		// POST: Admin/Schedule/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, LessonViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var entity = _modelTransformer.GetEntity<Lesson>(viewModel);
					var originalEntity = DbContext.Set<Lesson>().Find(id);

					originalEntity.StartTime = entity.StartTime;
					originalEntity.WeekDay = entity.WeekDay;
					originalEntity.CourseId = entity.CourseId;
					originalEntity.AgeGroupId = entity.AgeGroupId;
					originalEntity.TeacherFullName = entity.TeacherFullName;
					originalEntity.GroupName = entity.GroupName;

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

		// GET: Admin/Schedule/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Set<Lesson>().Find(id);
			var viewModel = _modelTransformer.GetViewModel<LessonViewModel>(originalItem);

			return View(viewModel);
		}

		// POST: Admin/Schedule/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, LessonViewModel viewModel)
		{
			try
			{
				var removableItem = DbContext.Set<Lesson>().Find(id);
				DbContext.Set<Lesson>().Remove(removableItem);
				DbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		public JsonResult GetCourses(int affiliateId, int serviceId)
		{
			var coursesListItems = GetCoursesSelectListItems(affiliateId, serviceId);

			return new JsonResult
			{
				Data = coursesListItems,
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};
		}

		#region Helpers

		private List<CourseViewModel> GetCoursesSelectListItems(int affiliateId, int serviceId)
		{
			List<CourseViewModel> result = DbContext.Set<Course>()
				.Where(c => c.AffiliateId == affiliateId && c.ServiceId == serviceId)
				.ToArray()
				.Select(course => new CourseViewModel
				{
					Id = course.Id,
					Name = course.Name,
					Duration = course.Duration
				})
				.ToList();


			return result;
		}

		#endregion
	}
}
