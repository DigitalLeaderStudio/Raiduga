namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class HtmlContent : IKey<int>, IDateExtented, IBodyHtml, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string BodyHtml { get; set; }
		
		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }
	}
}
