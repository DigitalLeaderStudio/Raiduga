namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.Security.AccessControl;

	public class AddressViewModel : IGeneratable<Address, AddressViewModel>
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Contacts_Address")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Contacts_Latitude")]
		public double Latitude { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Contacts_Longitude")]
		public double Longitude { get; set; }

		public AddressViewModel FromDbModel(Address model)
		{
			this.Id = model.Id;
			this.Name = model.Name;
			this.Latitude = model.Latitude;
			this.Longitude = model.Longitude;

			return this;
		}

		public Address ToDbModel()
		{
			var result = new Address
			{
				Id = this.Id,
				Name = this.Name,
				Latitude = this.Latitude,
				Longitude = this.Longitude
			};

			return result;
		}
	}
}