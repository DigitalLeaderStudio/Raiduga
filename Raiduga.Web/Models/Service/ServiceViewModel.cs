namespace Raiduga.Web.Models.Service
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Models.Interfaces;
	using System.Collections.Generic;

	public class ServiceViewModel : AbstractFileViewModel, IBodyHtml, IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[MapToEntityValue]
		public string Name { get; set; }

		[MapToEntityValue]
		public string Description { get; set; }

		[MapToEntityValue]
		public string BodyHtml { get; set; }

		[MapToListAttribute]
		public List<CourseViewModel> Courses { get; set; }

		//public ServiceViewModel FromDbModel(Service model)
		//{
		//	this.Id = model.Id;
		//	this.Name = model.Name;
		//	this.Description = model.Description;
		//	this.BodyHtml = model.BodyHtml;
		//	this.ImageId = model.ImageId;
		//	this.Courses = new List<CourseViewModel>();

		//	foreach (var course in model.Courses)
		//	{
		//		this.Courses.Add(new CourseViewModel().FromDbModel(course));
		//	}

		//	return this;
		//}

		//public Service ToDbModel()
		//{
		//	var result = new Service
		//	{
		//		Id = this.Id,
		//		Name = this.Name,
		//		Description = this.Description,
		//		BodyHtml = this.BodyHtml,
		//		Image = this.GetFile()
		//	};

		//	return result;
		//}
	}
}