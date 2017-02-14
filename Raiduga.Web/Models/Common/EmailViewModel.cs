namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Web.Models.Interfaces;

	public class EmailViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		[MapToValue]
		public string Value { get; set; }
	}
}