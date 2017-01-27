namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ApplyToCourseRequest : IKey<int>, IDateExtented
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string ChildName { get; set; }

		[Required]
		public string Phone { get; set; }

		public string Email { get; set; }

		public virtual int CourseId { get; set; }

		public virtual Course Course { get; set; }

		[Required]
		public DateTime BirthDate { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }
	}
}
