namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class AgeGroup : IKey<int>, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Lesson> Lessons { get; set; }
	}
}
