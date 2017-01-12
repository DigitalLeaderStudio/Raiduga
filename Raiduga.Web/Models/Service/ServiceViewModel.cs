namespace Raiduga.Web.Models.Service
{
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Models.Common;
	using System.Collections.Generic;
	using System.Web;

	public class ServiceViewModel : IBodyHtml, IGeneratable<Service, ServiceViewModel>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string BodyHtml { get; set; }

		public List<CourseViewModel> Courses { get; set; }

		public HttpPostedFileBase File { get; set; }

		public int? ImageId { get; set; }

		public ServiceViewModel FromDbModel(Service model)
		{
			this.Id = model.Id;
			this.Name = model.Name;
			this.Description = model.Description;
			this.BodyHtml = model.BodyHtml;
			this.ImageId = model.ImageId;
			this.Courses = new List<CourseViewModel>();

			foreach (var course in model.Courses)
			{
				this.Courses.Add(new CourseViewModel().FromDbModel(course));
			}

			return this;
		}

		public Service ToDbModel()
		{
			var result = new Service
			{
				Id = this.Id,
				Name = this.Name,
				Description = this.Description,
				BodyHtml = this.BodyHtml,
			};

			if (this.File != null && this.File.ContentLength > 0)
			{
				using (var reader = new System.IO.BinaryReader(this.File.InputStream))
				{
					result.Image = new File
					{
						FileName = System.IO.Path.GetFileName(this.File.FileName),
						ContentType = this.File.ContentType,
						Content = reader.ReadBytes(this.File.ContentLength)
					};
				}
			}

			return result;
		}
	}
}