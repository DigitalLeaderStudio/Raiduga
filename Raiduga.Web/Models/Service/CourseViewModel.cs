namespace Raiduga.Web.Models.Service
{
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using System;

	public class CourseViewModel : IBodyHtml, IGeneratable<Course, CourseViewModel>
	{
		public int Id { get; set; }

		public int PriorityOrder { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Price { get; set; }

		public string BodyHtml { get; set; }

		public TimeSpan Duration { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public CourseViewModel FromDbModel(Course model)
		{
			this.Id = model.Id;
			this.Name = model.Name;
			this.Description = model.Description;
			this.BodyHtml = model.BodyHtml;
			this.Price = model.Price;
			this.CreationDate = model.CreationDate;
			this.UpdationDate = model.UpdationDate;
			this.PriorityOrder = model.PriorityOrder;

			return this;
		}

		public Course ToDbModel()
		{
			var result = new Course
			{
				Id = this.Id,
				Name = this.Name,
				Description = this.Description,
				BodyHtml = this.BodyHtml,
				PriorityOrder = this.PriorityOrder,
				Price = this.Price,
				CreationDate = this.CreationDate,
				UpdationDate = this.UpdationDate
			};

			return result;
		}
	}
}