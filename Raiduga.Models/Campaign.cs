namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Campaign : IKey<int>, IDateExtented, IBodyHtml, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Title { get; set; }

		public string BodyHtml { get; set; }

		public bool IsActive { get; set; }

		public bool IsContactFormVisible { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public DateTime? DeletionDate { get; set; }
	}
}
