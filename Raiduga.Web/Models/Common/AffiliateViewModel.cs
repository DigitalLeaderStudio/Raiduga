namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class AffiliateViewModel : IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[MapToEntityValue]
		public string Title { get; set; }

		[MapToEntityValue]
		public string Description { get; set; }

		[MapToEntityValue]
		public bool IsPrimary { get; set; }

		[AllowHtml]
		[MapToEntityValue]
		public string HtmlDataContacts { get; set; }

		[MapToEntityComplex]
		public AddressViewModel Address { get; set; }

		#region Profi mod solution

		//public List<PhoneViewModel> Phones { get; set; }

		//public List<EmailViewModel> Emails { get; set; }

		#endregion

		[MapToEntityComplex]
		public HoursViewModel Hours { get; set; }
	}
}