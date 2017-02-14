namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class HtmlContentViewModel : IDateExtented, IViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Content_Name")]
		[MapToValue]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Content_BodyHtml")]
		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[MapToValue]
		public string BodyHtml { get; set; }

		[MapToValue]
		public DateTime? CreationDate { get; set; }

		[MapToValue]
		public DateTime? UpdationDate { get; set; }
	}
}