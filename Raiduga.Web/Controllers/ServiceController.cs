namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Service;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
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