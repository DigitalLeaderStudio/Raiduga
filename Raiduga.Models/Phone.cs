namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Phone : IKey<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Number { get; set; }

		public virtual ICollection<Affiliate> Affiliates { get; set; }
	}
}
