namespace Raiduga.Models
{
	using Raiduga.Interface;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Lesson : IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string TeacherFullName { get; set; }

		public TimeSpan StartTime { get; set; }

		public string GroupName { get; set; }

		public int WeekDay { get; set; }

		public int CourseId { get; set; }

		public virtual Course Course { get; set; }

		public int? AgeGroupId { get; set; }

		public virtual AgeGroup AgeGroup { get; set; }
	}
}
