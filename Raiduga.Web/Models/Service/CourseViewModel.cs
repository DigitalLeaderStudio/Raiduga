namespace Raiduga.Web.Models.Service
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class CourseViewModel : IBodyHtml, IViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		[MapToValue]
		public int PriorityOrder { get; set; }

		[StringLength(128)]
		[Display(ResourceType = typeof(Translations), Name = "Course_Name")]
		[MapToValue]
		public string Name { get; set; }

		[MapToValue]
		public int ServiceId { get; set; }

		[MapToEntity]
		public ServiceViewModel Service { get; set; }

		[StringLength(500)]
		[Display(ResourceType = typeof(Translations), Name = "Course_Description")]
		[MapToValue]
		public string Description { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Course_Price")]
		[MapToValue]
		public string Price { get; set; }

		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[Display(ResourceType = typeof(Translations), Name = "Course_BodyHtml")]
		[MapToValue]
		public string BodyHtml { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Course_Duration")]
		[MapToValue]
		public TimeSpan Duration { get; set; }

		[MapToValue]
		public DateTime? CreationDate { get; set; }

		[MapToValue]
		public DateTime? UpdationDate { get; set; }

		[MapToList]
		public List<LessonViewModel> Lessons { get; set; }

		[MapToValue]
		public int AffiliateId { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Schedule_Affiliate_Name")]
		public List<SelectListItem> Affiliates { get; set; }
	}
}