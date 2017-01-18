namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System.Linq;
	using System.Web.Mvc;
	using RouteLocalization.Mvc;
	using RouteLocalization.Mvc.Extensions;
	using RouteLocalization.Mvc.Setup;
	using Raiduga.Web.Localization;
	using System.Collections.Generic;
	using Raiduga.Web.Models.Article;

	public class ArticleController : BaseController
	{
		[Route("~/Новини")]
		public ActionResult Index()
		{
			var dbData = DbContext.Articles.Where(a => a.IsPublished);

			var model = new List<ArticleViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new ArticleViewModel().FromDbModel(dbItem));
			}

			return View(model);
		}

		[Route("~/Новини/{title}")]
		public ActionResult View(string title)
		{
			var dbItem = DbContext.Articles.Where(art => art.Title == title && art.IsPublished).First();

			var model = new ArticleViewModel().FromDbModel(dbItem);
			return View(model);
		}
	}
}