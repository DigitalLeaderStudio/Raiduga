namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Interface;
	using Raiduga.Models;
	using Raiduga.Web.Models.UserFeedback;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class UserFeedbackController : BaseController
	{
		private IModelTransformer<UserFeedback, UserFeedbackViewModel> _userFeedbackTransformer;

		public UserFeedbackController(IComponentContext componentContext)
			: base(componentContext)
		{
			_userFeedbackTransformer = componentContext.Resolve<IModelTransformer<UserFeedback, UserFeedbackViewModel>>();
		}

		public ActionResult Index()
		{
			var dbData = DbContext.UserFeedbacks.ToArray();
			var viewModel = new List<UserFeedbackViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_userFeedbackTransformer.GetViewModel(dbItem));
			}

			return View(viewModel);
		}

		public ActionResult _UserFeedbackHomePartial()
		{
			var dbData = DbContext.UserFeedbacks
				.Where(uf => uf.IsActive)
				.Take(3)
				.ToArray();

			var viewModel = new List<UserFeedbackViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_userFeedbackTransformer.GetViewModel(dbItem));
			}

			return PartialView(viewModel);
		}
	}
}