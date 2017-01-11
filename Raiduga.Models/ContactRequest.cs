namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ContactRequest : IKey<int>, IDateExtented
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Phone { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Message { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }
	}
}
