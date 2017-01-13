namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class AffiliateViewModel : IGeneratable<Affiliate, AffiliateViewModel>
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsPrimary { get; set; }

		[AllowHtml]
		public string HtmlDataContacts { get; set; }

		public AddressViewModel Address { get; set; }

		#region Profi mod solution

		//public List<PhoneViewModel> Phones { get; set; }

		//public List<EmailViewModel> Emails { get; set; }

		#endregion

		public HoursViewModel Hours { get; set; }

		public AffiliateViewModel FromDbModel(Affiliate model)
		{
			var result = new AffiliateViewModel
			{
				Id = model.Id,
				IsPrimary = model.IsPrimary,
				Title = model.Title,
				Description = model.Description,
				Address = new AddressViewModel().FromDbModel(model.Address),
				Hours = new HoursViewModel().FromDbModel(model.Hours.First()),
				HtmlDataContacts = model.HtmlDataContacts
				//Profi mod solution
				//Phones = new List<PhoneViewModel>(),
				//Emails = new List<EmailViewModel>()
			};

			//Profi mod solution
			//foreach (var phone in model.Phones)
			//{
			//	result.Phones.Add(new PhoneViewModel().FromDbModel(phone));
			//}
			//foreach (var email in model.Emails)
			//{
			//	result.Emails.Add(new EmailViewModel().FromDbModel(email));
			//}

			return result;
		}

		public Affiliate ToDbModel()
		{
			var result = new Affiliate
			{
				Id = this.Id,
				IsPrimary = this.IsPrimary,
				Description = this.Description
			};

			return result;
		}
	}
}