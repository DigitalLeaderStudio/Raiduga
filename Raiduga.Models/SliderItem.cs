namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class SliderItem : IKey<int>, IImageble, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(24)]
		public string Title { get; set; }

		[StringLength(128)]
		public string SubTitle { get; set; }

		public int? ImageId { get; set; }

		public virtual File Image { get; set; }
	}
}
