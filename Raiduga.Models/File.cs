namespace Raiduga.Models
{
	using Raiduga.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class File : IKey<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string FileName { get; set; }

		public string ContentType { get; set; }

		public byte[] Content { get; set; }
	}
}
