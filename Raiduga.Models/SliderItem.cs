namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class SliderItem : IKey<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(24)]
		public string Title { get; set; }

		[StringLength(128)]
		public string SubTitle { get; set; }

		public virtual File Image { get; set; }
	}
}
