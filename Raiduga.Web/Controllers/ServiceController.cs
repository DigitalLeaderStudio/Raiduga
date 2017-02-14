namespace Raiduga.Web.Controllers
{
	using Autofac;
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
		public ServiceController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("Наші-послуги")]
		public ActionResult Index()
		{
			var entities = DbContext.Services.OrderBy(s => s.Id).ToArray();
			var viewModel = new List<ServiceViewModel>();

			foreach (var entity in entities)
			{
				viewModel.Add(new ServiceViewModel
				{
					Id = entity.Id,
					Name = entity.Name,
					Description = entity.Description,
					ImageId = entity.ImageId
				});
			}

			return View(viewModel);
		}

		[Route("Наші-послуги/{name}")]
		public ActionResult CourseList(string name)
		{
			var viewModel = new ServiceViewModel();

			viewModel = DbContext.Set<Affiliate>()
				.Where(affiliate => affiliate.IsPrimary)
				.Select(affiliate =>
					affiliate.Courses
						.Where(course => course.Service.Name == name)
						.OrderBy(course => course.Name)
						.GroupBy(course => new
						{
							course.ServiceId,
							course.Service.Name
						})
						.Select(courses =>
							new ServiceViewModel
							{
								Id = courses.Key.ServiceId,
								Name = courses.Key.Name,
								Courses = courses
									.Select(course => new CourseViewModel
									{
										Id = course.Id,
										Name = course.Name,
										Description = course.Description,
										Price = course.Price,
										Duration = course.Duration
									})
									.ToList()
							}
						).ToList()
					)
					.First()
					.First();

			return View(viewModel);
		}

		[Route("Наші-послуги/{serviceName}/{courseName}")]
		public ActionResult CourseView(string serviceName, string courseName)
		{
			var dbItem = DbContext.Services
				.Where(srv => srv.Name == serviceName)
				.Select(x => x.Courses.Where(course => course.Name == courseName))
				.First()
				.First();

			var viewModel = _modelTransformer.GetViewModel<CourseViewModel>(dbItem);

			return View(viewModel);
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

					var adminEmialAddress = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString();
					var courseLink = Url.Action(
						"CourseView",
						"Service",
						new { serviceName = serviceName.Name, courseName = course.Name },
						this.Request.Url.Scheme);
					await MailSender.Default.SendAsync(
						adminEmialAddress,
						adminEmialAddress,
						Translations.ApplyToCourse_EmailTitle,
						string.Format(@"<h1>{0}</h1>
										<p><strong>{1}:</strong> {5}</p>
                                        <p><strong>{2}:</strong> {6}</p>
                                        <p><strong>{3}:</strong> <a href=""tel:{7}"">{7}</a></p>                                        
                                        <p><strong>{4}:</strong> <a href=""mailto:{8}"">{8}</a></p>
<p><strong>{9}</strong> <a href=""{10}"">{11}</a></p>
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
							courseLink,
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
			var viewModel = new List<ServiceViewModel>();

			viewModel = DbContext.Set<Affiliate>()
				.Where(affiliate => affiliate.IsPrimary)
				.Select(affiliate =>
					affiliate.Courses
						.GroupBy(course => new
						{
							course.ServiceId,
							course.Service.Name,
							course.Service.ImageId
						})
						.OrderBy(serviceGroup => serviceGroup.Key.ServiceId)
						.Select(courses =>
							new ServiceViewModel
							{
								Name = courses.Key.Name,
								ImageId = courses.Key.ImageId,
								Courses = courses
									.Take(5)
									.Select(course => new CourseViewModel { Name = course.Name })
									.ToList()
							}
						).ToList()
					).First();

			return PartialView(viewModel);
		}

		public ActionResult _ServicesMenuPartial()
		{
			var viewModel = new List<ServiceViewModel>();

			viewModel = DbContext.Set<Affiliate>()
				.Where(affiliate => affiliate.IsPrimary)
				.Select(affiliate =>
					affiliate.Courses
						.GroupBy(course => new
						{
							course.ServiceId,
							course.Service.Name,
							course.Service.ImageId
						})
						.OrderBy(serviceGroup => serviceGroup.Key.ServiceId)
						.Select(courses =>
							new ServiceViewModel
							{
								Name = courses.Key.Name,
								ImageId = courses.Key.ImageId
							}
						).ToList()
					).First();

			return PartialView(viewModel);
		}
	}
}