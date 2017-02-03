namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Interface;
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
		private IModelTransformer<Service, ServiceViewModel> _serviceTransformer;
		private IModelTransformer<Course, CourseViewModel> _courseTransformer;

		public ServiceController(IComponentContext componentContext)
			: base(componentContext)
		{
			_serviceTransformer = componentContext.Resolve<IModelTransformer<Service, ServiceViewModel>>();
			_courseTransformer = componentContext.Resolve<IModelTransformer<Course, CourseViewModel>>();
		}

		[Route("Наші-послуги")]
		public ActionResult Index()
		{
			var dbData = DbContext.Services.ToArray();
			var viewModel = new List<ServiceViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_serviceTransformer.GetViewModel(dbItem));
			}

			return View(viewModel);
		}

		[Route("Наші-послуги/{name}")]
		public ActionResult CourseList(string name)
		{
			var service = DbContext.Services.Where(s => s.Name == name).First();
			var viewModel = _serviceTransformer.GetViewModel(service);

			return View(viewModel);
		}

		[Route("Наші-послуги/{serviceName}/{courseName}")]
		public ActionResult CourseView(string serviceName, string courseName)
		{
			var dbItem = DbContext.Services
				.Where(srv => srv.Name == serviceName)
				.Select(x => x.Courses.Where(course => course.Name == courseName))
				.First().First();

			var viewModel = _courseTransformer.GetViewModel(dbItem);
			viewModel.ServiceName = serviceName;

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
			var dbData = DbContext.Services.ToArray();

			var viewModel = new List<ServiceViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_serviceTransformer.GetViewModel(dbItem));
			}

			return PartialView(viewModel);
		}
	}
}