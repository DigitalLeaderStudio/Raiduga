namespace Raiduga.Web.Models.Service
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using System;
	using System.Collections.Generic;

	public class AgeGroupViewModel : IViewModel
	{
		[MapToValue]
		public int Id { get; set; }

		[MapToValue]

		public string Name { get; set; }

		[MapToValue]
		public string Description { get; set; }

		public List<CourseViewModel> Courses { get; set; }
	}
}