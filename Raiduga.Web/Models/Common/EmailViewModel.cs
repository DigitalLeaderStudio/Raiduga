namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;

	public class EmailViewModel : IGeneratable<Email, EmailViewModel>
	{
		public int Id { get; set; }

		public string Value { get; set; }

		public EmailViewModel FromDbModel(Email model)
		{
			this.Id = model.Id;
			this.Value = model.Value;

			return this;
		}

		public Email ToDbModel()
		{
			return new Email
			{
				Id = this.Id,
				Value = this.Value
			};
		}
	}
}