namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Models.UserFeedback;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class UserFeedbackController : BaseController
	{
		public UserFeedbackController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		public ActionResult Index()
		{
			var dbData = DbContext.UserFeedbacks.ToArray();
			var viewModel = new List<UserFeedbackViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_modelTransformer.GetViewModel<UserFeedbackViewModel>(dbItem));
			}

			return View(viewModel);
		}

		public ActionResult _UserFeedbackHomePartial()
		{
			var dbData = DbContext.Set<UserFeedback>()
				.Where(userFeedback => userFeedback.IsActive)
				.Take(3)
				.ToArray();

			var viewModel = new List<UserFeedbackViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_modelTransformer.GetViewModel<UserFeedbackViewModel>(dbItem));
			}

			return PartialView(viewModel);
		}
	}
}