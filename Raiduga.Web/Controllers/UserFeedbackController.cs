namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Service;
	using Raiduga.Web.Models.UserFeedback;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class UserFeedbackController : BaseController
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

		public ActionResult _UserFeedbackHomePartial()
		{
			var dbData = DbContext.UserFeedbacks
				.Where(uf => uf.IsActive)
				.Take(3)
				.ToArray();

			var model = new List<UserFeedbackViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new UserFeedbackViewModel().FromDbModel(dbItem));
			}

			return PartialView(model);
		}
	}
}