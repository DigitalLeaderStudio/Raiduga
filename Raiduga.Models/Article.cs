namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Article : IKey<int>, IDateExtented, IBodyHtml, IImageble
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public bool IsPublished { get; set; }

		public string Author { get; set; }

		public string Keywords { get; set; }

		[StringLength(100)]
		public string Title { get; set; }

		[StringLength(500)]
		public string Description { get; set; }

		public string BodyHtml { get; set; }

		public System.DateTime? CreationDate { get; set; }

		public System.DateTime? UpdationDate { get; set; }

		public int? ImageId { get; set; }

		public File Image { get; set; }
	}
}
