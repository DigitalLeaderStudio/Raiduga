namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Hours : IKey<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public TimeSpan Start { get; set; }

		public TimeSpan End { get; set; }

		public virtual ICollection<Affiliate> Affiliates { get; set; }

	}
}
