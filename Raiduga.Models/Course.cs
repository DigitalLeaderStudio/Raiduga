namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Course : IKey<int>, IDateExtented, IBodyHtml, IEntity
	{
		public Course()
		{
			PriorityOrder = 1000;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int PriorityOrder { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Price { get; set; }

		public string BodyHtml { get; set; }

		public TimeSpan Duration { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public int ServiceId { get; set; }

		public virtual Service Service { get; set; }
	}
}
