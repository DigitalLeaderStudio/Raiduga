namespace Raiduga.Web.Controllers
{
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Service;
	using Simplify.Mail;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class ServiceController : BaseController
	{
		[Route("Наші-послуги")]
		public ActionResult Index()
		{
			var dbData = DbContext.Services.ToArray();
			var model = new List<ServiceViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new ServiceViewModel().FromDbModel(dbItem));
			}

			return View(model);
		}

		[Route("Наші-послуги/{name}")]
		public ActionResult CourseList(string name)
		{
			var service = DbContext.Services.Where(s => s.Name == name).First();
			var model = new ServiceViewModel().FromDbModel(service);

			return View(model);
		}

		[Route("Наші-послуги/{serviceName}/{courseName}")]
		public ActionResult CourseView(string serviceName, string courseName)
		{
			var dbItem = DbContext.Services
				.Where(srv => srv.Name == serviceName)
				.Select(x => x.Courses.Where(course => course.Name == courseName))
				.First().First();

			var model = new CourseViewModel().FromDbModel(dbItem);

			return View(model);
		}


		[HttpGet]
		public PartialViewResult _ApplyToCoursePartial(int courseId)
		{
			var course = DbContext.Set<Course>().Find(courseId);

			var model = new ApplyToCourseViewModel
			{
				CourseId = course.Id,
				CourseName = course.Name
			};

			return PartialView(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<PartialViewResult> ApplyToCourse(ApplyToCourseViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var course = DbContext.Set<Course>().Find(model.CourseId);
					var serviceName = DbContext.Services.Find(course.ServiceId);

					model.CourseName = course.Name;
					var dbItem = model.ToDbModel();
					dbItem.CreationDate = DateTime.Now;

					DbContext.ApplyToCourseRequests.Add(dbItem);

					await DbContext.SaveChangesAsync();

					await MailSender.Default.SendAsync(
						"admin@raiduga.kiev.ua",
						model.Email,
						Translations.ApplyToCourse_EmailTitle,
						string.Format(@"<h1>{0}</h1>
										<p><strong>{1}:</strong> {5}</p>
                                        <p><strong>{2}:</strong> {6}</p>
                                        <p><strong>{3}:</strong> <a href=""tel:{7}"">{7}</a></p>                                        
                                        <p><strong>{4}:</strong> <a href=""mailto:{8}"">{8}</a></p>
<p><strong>{9}</strong> <a href=""@{10}"">{11}</a></p>
",
							Translations.ApplyToCourse_EmailTitle,
							Translations.ApplyToCourse_ChildName,
							Translations.ApplyToCourse_ChildBirthDate,
							Translations.ApplyToCourse_Phone,
							Translations.ApplyToCourse_Email,
							model.ChildName,
							dbItem.BirthDate.ToShortDateString(),
							model.Phone,
							model.Email,
							Translations.Course_Name,
							Url.Action("CourseView", "Service", new { serviceName = serviceName, courseName = course.Name }),
							course.Name));

					model.SuccessfullySent = true;
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}
			else
			{
				model.Errors = ModelState.Values.SelectMany(m => m.Errors)
									 .Select(e => e.ErrorMessage)
									 .ToList();
			}

			return PartialView("_ApplyToCoursePartial", model);
		}

		public ActionResult _ServiceHomePartial()
		{
			var dbData = DbContext.Services.ToArray();

			var model = new List<ServiceViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new ServiceViewModel().FromDbModel(dbItem));
			}

			return PartialView(model);
		}
	}
}