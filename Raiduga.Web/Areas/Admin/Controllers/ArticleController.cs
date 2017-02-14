namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Article;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class ArticleController : BaseAdminController
	{
		public ArticleController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/Article
		public ActionResult Index()
		{
			var dbData = DbContext.Articles.ToArray();

			var model = new List<ArticleViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(_modelTransformer.GetViewModel<ArticleViewModel>(dbItem));
			}

			return View(model);
		}

		// GET: Admin/Article/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Article/Create
		[HttpPost]
		public ActionResult Create(ArticleViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<Article>(viewModel);
					item.CreationDate = DateTime.Now;

					DbContext.Articles.Add(item);
					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}

		// GET: Admin/Article/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Articles.Find(id);
			var viewModel = _modelTransformer.GetViewModel<ArticleViewModel>(originalItem);

			return View(viewModel);
		}

		// POST: Admin/Article/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, ArticleViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var entity = _modelTransformer.GetEntity<Article>(viewModel);
					var originalItem = DbContext.Articles.Find(id);

					originalItem.Author = viewModel.Author;
					originalItem.BodyHtml = viewModel.BodyHtml;
					originalItem.Description = viewModel.Description;
					originalItem.IsPublished = viewModel.IsPublished;
					originalItem.Keywords = viewModel.Keywords;
					originalItem.Title = viewModel.Title;
					originalItem.UpdationDate = DateTime.Now;
					originalItem.Image = entity.Image;

					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(viewModel);
		}

		// GET: Admin/Article/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.Articles.Find(id);
			var viewModel = _modelTransformer.GetViewModel<ArticleViewModel>(originalItem);

			return View(viewModel);
		}

		// POST: Admin/Article/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, ArticleViewModel viewModel)
		{
			try
			{
				var removableItem = DbContext.Articles.Find(id);
				DbContext.Articles.Remove(removableItem);
				DbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
