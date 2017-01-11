namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Email : IKey<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Value { get; set; }

		public virtual ICollection<Affiliate> Affiliates { get; set; }
	}
}
