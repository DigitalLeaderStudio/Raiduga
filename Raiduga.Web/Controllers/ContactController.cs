namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Interface;
	using Raiduga.Models;
	using Raiduga.ModelTransformers;
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
		private IModelTransformer<Affiliate, AffiliateViewModel> _affiliateTransformer;
		private IModelTransformer<ContactRequest, ContactRequestViewModel> _crTransformer;

		public ContactController(IComponentContext componentContext)
		{
			_affiliateTransformer = componentContext.Resolve<IModelTransformer<Affiliate, AffiliateViewModel>>();
			_crTransformer = componentContext.Resolve<IModelTransformer<ContactRequest, ContactRequestViewModel>>();
		}

		[Route("Контакти")]
		public ActionResult Index()
		{
			var model = new List<AffiliateViewModel>();

			foreach (var affiliate in DbContext.Affiliates.OrderByDescending(a => a.IsPrimary).ToArray())
			{
				model.Add(_affiliateTransformer.GetViewModel(affiliate));
			}

			return View(model);
		}

		public ActionResult _ContactFormPartial()
		{
			return PartialView(new ContactRequestViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<PartialViewResult> ContactRequest(ContactRequestViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var entity = _crTransformer.GetEntity(viewModel);
					entity.CreationDate = DateTime.Now;

					DbContext.ContactRequests.Add(entity);

					await DbContext.SaveChangesAsync();

					var adminEmialAddress = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString();

					await MailSender.Default.SendAsync(
						adminEmialAddress,
						adminEmialAddress,
						Translations.ContactsForm_Email_Subj,
						string.Format(@"<h1>{0}</h1>
                                        <p><strong>{1}:</strong> <a href=""mailto:{4}"">{4}</a></p>
                                        <p><strong>{2}:</strong> <a href=""tel:{5}"">{5}</a></p>                                        
                                        <p><strong>{3}:</strong> {6}</p>",
							Translations.ContactsForm_Email_Subj,
							Translations.ContactsForm_Email,
							Translations.ContactsForm_Phone,
							Translations.ContactsForm_Message,
							viewModel.Email,
							viewModel.Phone,
							viewModel.Message));

					viewModel.RedirectLink = Url.Action("Thanks", "Common");
					viewModel.SuccessfullySent = true;
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}
			else
			{
				viewModel.Errors = ModelState.Values.SelectMany(m => m.Errors)
									 .Select(e => e.ErrorMessage)
									 .ToList();
			}

			return PartialView("_ContactFormPartial", viewModel);
		}
	}
}