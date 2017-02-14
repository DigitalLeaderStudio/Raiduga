namespace Raiduga.Interface.Attribute
{
	using System;

	[AttributeUsage(AttributeTargets.Property)]
	public class MapToListAttribute : Attribute
	{
		public string EntityPropertyName { get; set; }
	}
}
