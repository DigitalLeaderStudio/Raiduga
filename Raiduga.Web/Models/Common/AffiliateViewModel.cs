namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;
	using Raiduga.Web.Models.Service;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class AffiliateViewModel : IViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		public string Name { get; set; }

		[MapToValue]
		public string Title { get; set; }

		[MapToValue]
		public string Description { get; set; }

		[MapToValue]
		public bool IsPrimary { get; set; }

		[AllowHtml]
		[MapToValue]
		public string HtmlDataContacts { get; set; }

		[MapToEntity]
		public AddressViewModel Address { get; set; }

		#region Profi mod solution

		//public List<PhoneViewModel> Phones { get; set; }

		//public List<EmailViewModel> Emails { get; set; }

		#endregion

		[MapToEntity]
		public HoursViewModel Hours { get; set; }

		[MapToList]
		public List<CourseViewModel> Courses { get; set; }

		public List<ServiceViewModel> Services { get; set; }
	}
}