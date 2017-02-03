namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using System.ComponentModel.DataAnnotations;

	public class AddressViewModel : IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Contacts_Address")]
		[MapToEntityValue]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Contacts_Latitude")]
		[MapToEntityValue]
		public double Latitude { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Contacts_Longitude")]
		[MapToEntityValue]
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