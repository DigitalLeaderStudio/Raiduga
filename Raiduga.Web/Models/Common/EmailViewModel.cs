namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;

	public class EmailViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[MapToEntityValue]
		public string Value { get; set; }
	}
}