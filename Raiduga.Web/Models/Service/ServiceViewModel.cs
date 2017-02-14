namespace Raiduga.Web.Models.Service
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Models.Interfaces;
	using System.Collections.Generic;

	public class ServiceViewModel : AbstractFileViewModel, IBodyHtml, IViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		[MapToValue]
		public string Name { get; set; }

		[MapToValue]
		public string Description { get; set; }

		[MapToValue]
		public string BodyHtml { get; set; }

		[MapToListAttribute]
		public List<CourseViewModel> Courses { get; set; }

		public List<AgeGroupViewModel> AgeGroups { get; set; }

	}
}