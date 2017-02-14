namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Autofac;
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.UserFeedback;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class UserFeedbackController : BaseAdminController
	{
		public UserFeedbackController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Admin/UserFeedback
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
		public ActionResult Create(UserFeedbackViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<UserFeedback>(viewModel);
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

			return View(viewModel);
		}

		// GET: Admin/UserFeedback/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.UserFeedbacks.Find(id);
			var viewModel = _modelTransformer.GetViewModel<UserFeedbackViewModel>(originalItem);

			return View(viewModel);
		}

		// POST: Admin/UserFeedback/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, UserFeedbackViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = _modelTransformer.GetEntity<UserFeedback>(viewModel);

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

			return View(viewModel);
		}

		// GET: Admin/UserFeedback/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.UserFeedbacks.Find(id);
			var viewModel = _modelTransformer.GetViewModel<UserFeedbackViewModel>(originalItem);

			return View(viewModel);
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
