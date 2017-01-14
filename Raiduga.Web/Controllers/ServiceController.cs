namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Service;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class ServiceController : BaseController
	{
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

		public ActionResult CoursesList(int? id)
		{
			return View();
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