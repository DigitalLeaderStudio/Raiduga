namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.UserFeedback;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class UserFeedbackController : BaseAdminController
	{
		// GET: Admin/UserFeedback
		public ActionResult Index()
		{
			var dbData = DbContext.UserFeedbacks.ToArray();

			var model = new List<UserFeedbackViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new UserFeedbackViewModel().FromDbModel(dbItem));
			}

			return View(model);
		}

		// GET: Admin/UserFeedback/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Admin/UserFeedback/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/UserFeedback/Create
		[HttpPost]
		public ActionResult Create(UserFeedbackViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();
					item.CreationDate = DateTime.Now;

					DbContext.UserFeedbacks.Add(item);
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

		// GET: Admin/UserFeedback/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.UserFeedbacks.Find(id);

			return View(new UserFeedbackViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/UserFeedback/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, UserFeedbackViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					var originalItem = DbContext.UserFeedbacks.Find(id);

					originalItem.UserName = item.UserName;
					originalItem.IsActive = item.IsActive;
					originalItem.Text = item.Text;
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

		// GET: Admin/UserFeedback/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.UserFeedbacks.Find(id);

			return View(new UserFeedbackViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/UserFeedback/Delete/5
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
