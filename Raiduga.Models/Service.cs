namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Service : IKey<int>, IBodyHtml, IImageble, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string BodyHtml { get; set; }

		public string Description { get; set; }

		public int? ImageId { get; set; }

		public virtual File Image { get; set; }

		public virtual ICollection<Course> Courses { get; set; }

		public int? AffiliateId { get; set; }

		public virtual Affiliate Affiliate { get; set; }
	}
}
