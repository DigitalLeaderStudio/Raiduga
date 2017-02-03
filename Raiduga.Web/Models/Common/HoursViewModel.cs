namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;
	using System;

	public class HoursViewModel : IEntity
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[MapToEntityValue]
		public TimeSpan Start { get; set; }

		[MapToEntityValue]
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