namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Article;
	using Raiduga.Web.Models.UserFeedback;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class ArticleController : BaseAdminController
	{
		// GET: Admin/Article
		public ActionResult Index()
		{
			var dbData = DbContext.Articles.ToArray();

			var model = new List<ArticleViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new ArticleViewModel().FromDbModel(dbItem));
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
		public ActionResult Create(ArticleViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();
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

			return View(model);
		}

		// GET: Admin/Article/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.Articles.Find(id);

			return View(new ArticleViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Article/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, ArticleViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					var originalItem = DbContext.Articles.Find(id);

					originalItem.Author = item.Author;
					originalItem.BodyHtml = item.BodyHtml;
					originalItem.Description = item.Description;
					originalItem.IsPublished = item.IsPublished;
					originalItem.Keywords = item.Keywords;
					originalItem.Title = item.Title;
					originalItem.UpdationDate = DateTime.Now;
					originalItem.Image = item.Image;

					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/Article/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.UserFeedbacks.Find(id);

			return View(new UserFeedbackViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/Article/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, UserFeedbackViewModel item)
		{
			try
			{
				var removableItem = DbContext.UserFeedbacks.Find(id);
				DbContext.UserFeedbacks.Remove(removableItem);
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
