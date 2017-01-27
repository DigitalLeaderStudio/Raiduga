namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Common;
	using Simplify.Mail;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class ContactController : BaseController
	{
		[Route("Контакти")]
		public ActionResult Index()
		{
			var model = new List<AffiliateViewModel>();

			foreach (var affiliate in DbContext.Affiliates.OrderByDescending(a => a.IsPrimary).ToArray())
			{
				model.Add(new AffiliateViewModel().FromDbModel(affiliate));
			}

			return View(model);
		}

		public ActionResult _ContactFormPartial()
		{
			return PartialView(new ContactRequestViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<PartialViewResult> ContactRequest(ContactRequestViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var dbData = model.ToDbModel();
					dbData.CreationDate = DateTime.Now;

					DbContext.ContactRequests.Add(dbData);

					await DbContext.SaveChangesAsync();

					await MailSender.Default.SendAsync(
						"admin@raiduga.kiev.ua",
						model.Email,
						Translations.ContactsForm_Email_Subj,
						string.Format(@"<h1>{0}</h1>
                                        <p><strong>{1}:</strong> <a href=""mailto:{4}"">{4}</a></p>
                                        <p><strong>{2}:</strong> <a href=""tel:{5}"">{5}</a></p>                                        
                                        <p><strong>{3}:</strong> {6}</p>",
							Translations.ContactsForm_Email_Subj,
							Translations.ContactsForm_Email,
							Translations.ContactsForm_Phone,
							Translations.ContactsForm_Message,
							model.Email,
							model.Phone,
							model.Message));

					model.RedirectLink = Url.Action("Thanks", "Common");
					model.SuccessfullySent = true;
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}
			else
			{
				model.Errors = ModelState.Values.SelectMany(m => m.Errors)
									 .Select(e => e.ErrorMessage)
									 .ToList();
			}

			return PartialView("_ContactFormPartial", model);
		}
	}
}