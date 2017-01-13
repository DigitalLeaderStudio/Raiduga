namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;

	public class PhoneViewModel : IGeneratable<Phone, PhoneViewModel>
	{
		public int Id { get; set; }

		public string Number { get; set; }

		public PhoneViewModel FromDbModel(Phone model)
		{
			this.Id = model.Id;
			this.Number = model.Number;

			return this;
		}

		public Phone ToDbModel()
		{
			return new Phone
			{
				Id = this.Id,
				Number = this.Number
			};
		}
	}
}