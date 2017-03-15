namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class CampaignViewModel : IDateExtented, IViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Campaign_Name")]
		[MapToValue]		
		public string Name { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Campaign_BodyHtml")]
		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[MapToValue]
		public string BodyHtml { get; set; }

		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Campaign_IsActive")]
		public bool IsActive { get; set; }
		
		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Campaign_IsContactFormVisible")]
		public bool IsContactFormVisible { get; set; }
		
		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Campaign_StartDate")]
		public DateTime StartDate { get; set; }

		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Campaign_EndDate")]
		public DateTime EndDate { get; set; }

		[MapToValue]
		public DateTime? CreationDate { get; set; }

		[MapToValue]
		public DateTime? UpdationDate { get; set; }

		[MapToValue]
		public DateTime? DeletionDate { get; set; }
	}
}