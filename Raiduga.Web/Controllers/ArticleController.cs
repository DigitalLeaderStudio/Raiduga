namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Web.Models.Article;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class ArticleController : BaseController
	{
		public ArticleController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("~/Новини")]
		public ActionResult Index()
		{
			var dbData = DbContext.Articles
				.Where(a => a.IsPublished)
				.OrderByDescending(a => a.CreationDate);

			var viewModel = new List<ArticleViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_modelTransformer.GetViewModel<ArticleViewModel>(dbItem));
			}

			return View(viewModel);
		}

		[Route("~/Новини/{title}")]
		public ActionResult Details(string title)
		{
			var dbItem = DbContext.Articles.Where(art => art.Title == title && art.IsPublished).First();
			var viewModel = _modelTransformer.GetViewModel<ArticleViewModel>(dbItem);

			return View(viewModel);
		}
	}
}