namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Interface;
	using Raiduga.Models;
	using Raiduga.Web.Models.Article;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class ArticleController : BaseController
	{
		private IModelTransformer<Article, ArticleViewModel> _articleTransformer;

		public ArticleController(IComponentContext componentContext)
			: base(componentContext)
		{
			_articleTransformer = componentContext.Resolve<IModelTransformer<Article, ArticleViewModel>>();
		}

		[Route("~/Новини")]
		public ActionResult Index()
		{
			var dbData = DbContext.Articles.Where(a => a.IsPublished);

			var viewModel = new List<ArticleViewModel>();

			foreach (var dbItem in dbData)
			{
				viewModel.Add(_articleTransformer.GetViewModel(dbItem));
			}

			return View(viewModel);
		}

		[Route("~/Новини/{title}")]
		public ActionResult Details(string title)
		{
			var dbItem = DbContext.Articles.Where(art => art.Title == title && art.IsPublished).First();
			var viewModel = _articleTransformer.GetViewModel(dbItem);

			return View(viewModel);
		}
	}
}