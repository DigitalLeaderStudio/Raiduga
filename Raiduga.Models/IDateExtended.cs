namespace Raiduga.Models
{
	using System;

	/// <summary>
	/// Extends type with CreationDate and UpdateionDate
	/// </summary>
	public interface IDateExtented
	{
		DateTime? CreationDate { get; set; }

		DateTime? UpdationDate { get; set; }
	}
}
