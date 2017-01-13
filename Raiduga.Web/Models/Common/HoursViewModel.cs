namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;
	using System;

	public class HoursViewModel : IGeneratable<Hours, HoursViewModel>
	{
		public int Id { get; set; }

		public TimeSpan Start { get; set; }

		public TimeSpan End { get; set; }

		public HoursViewModel FromDbModel(Hours model)
		{
			this.Id = model.Id;
			this.Start = model.Start;
			this.End = model.End;

			return this;
		}

		public Hours ToDbModel()
		{
			var result = new Hours
			{
				Id = this.Id,
				Start = this.Start,
				End = this.End
			};

			return result;
		}
	}
}