namespace Raiduga.Web.Models.Service
{
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class CourseViewModel : IBodyHtml, IGeneratable<Course, CourseViewModel>
	{
		public int Id { get; set; }

		public int PriorityOrder { get; set; }

		[StringLength(128)]
		[Display(ResourceType = typeof(Translations), Name = "Course_Name")]
		public string Name { get; set; }

		public int ServiceId { get; set; }

		public string ServiceName { get; set; }

		[StringLength(500)]
		[Display(ResourceType = typeof(Translations), Name = "Course_Description")]
		public string Description { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Course_Price")]
		public string Price { get; set; }

		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[Display(ResourceType = typeof(Translations), Name = "Course_BodyHtml")]
		public string BodyHtml { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Course_Duration")]
		public TimeSpan Duration { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public CourseViewModel FromDbModel(Course model)
		{
			this.Id = model.Id;
			this.Name = model.Name;
			this.Description = model.Description;
			this.Duration = model.Duration;
			this.BodyHtml = model.BodyHtml;
			this.Price = model.Price;
			this.CreationDate = model.CreationDate;
			this.UpdationDate = model.UpdationDate;
			this.PriorityOrder = model.PriorityOrder;

			this.ServiceId = model.ServiceId;
			this.ServiceName = model.Service.Name;

			return this;
		}

		public Course ToDbModel()
		{
			var result = new Course
			{
				Id = this.Id,
				Name = this.Name,
				Duration = this.Duration,
				Description = this.Description,
				BodyHtml = this.BodyHtml,
				PriorityOrder = this.PriorityOrder,
				Price = this.Price,
				CreationDate = this.CreationDate,
				UpdationDate = this.UpdationDate,
				ServiceId = this.ServiceId
			};

			return result;
		}
	}
}