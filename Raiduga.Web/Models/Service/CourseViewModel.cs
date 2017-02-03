namespace Raiduga.Web.Models.Service
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class CourseViewModel : IBodyHtml, IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[MapToEntityValue]
		public int PriorityOrder { get; set; }

		[StringLength(128)]
		[Display(ResourceType = typeof(Translations), Name = "Course_Name")]
		[MapToEntityValue]
		public string Name { get; set; }

		[MapToEntityValue]
		public int ServiceId { get; set; }

		public string ServiceName { get; set; }

		[StringLength(500)]
		[Display(ResourceType = typeof(Translations), Name = "Course_Description")]
		[MapToEntityValue]
		public string Description { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Course_Price")]
		[MapToEntityValue]
		public string Price { get; set; }

		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[Display(ResourceType = typeof(Translations), Name = "Course_BodyHtml")]
		[MapToEntityValue]
		public string BodyHtml { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Course_Duration")]
		[MapToEntityValue]
		public TimeSpan Duration { get; set; }

		[MapToEntityValue]
		public DateTime? CreationDate { get; set; }

		[MapToEntityValue]
		public DateTime? UpdationDate { get; set; }
	}
}