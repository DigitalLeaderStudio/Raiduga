namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Affiliate : IKey<int>, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

		[StringLength(64)]
		public string Name { get; set; }

		[StringLength(64)]

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsPrimary { get; set; }

		public virtual Address Address { get; set; }

		public virtual ICollection<Phone> Phones { get; set; }

		public virtual ICollection<Email> Emails { get; set; }

		public virtual ICollection<Hours> Hours { get; set; }

		/// <summary>
		/// Hides each field solution. Short (easy) solution
		/// </summary>
		public string HtmlDataContacts { get; set; }

		public virtual ICollection<Service> Services { get; set; }

		public virtual ICollection<Course> Courses { get; set; }
	}
}
