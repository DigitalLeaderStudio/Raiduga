namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class UserFeedback : IKey<int>, IDateExtented, IImageble
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Text { get; set; }

		public bool IsActive { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public int? ImageId { get; set; }

		public virtual File Image { get; set; }
	}
}
