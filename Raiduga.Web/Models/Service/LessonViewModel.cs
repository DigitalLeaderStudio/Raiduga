namespace Raiduga.Web.Models.Service
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Web.Mvc;

	public class LessonViewModel : IViewModel
	{
		public LessonViewModel()
		{
			this.WeekDays = new List<SelectListItem>();

			byte[] daysIndexes = new byte[] { 1, 2, 3, 4, 5, 6, 0 };
			foreach (byte dayIndex in daysIndexes)
			{
				this.WeekDays.Add(new SelectListItem
				{
					Text = DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)dayIndex),
					Value = dayIndex.ToString()
				});
			}
			this.WeekDays[0].Selected = true;
			this.WeekDay = 1;
		}

		[MapToValue]
		public int Id { get; set; }

		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Schedule_Teacher_Name")]
		public string TeacherFullName { get; set; }

		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Schedule_StartTime_Name")]
		public TimeSpan StartTime { get; set; }

		[MapToValue]
		[Display(ResourceType = typeof(Translations), Name = "Schedule_Group_Name")]
		public string GroupName { get; set; }

		[MapToValue]
		public int WeekDay { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Day")]
		public List<SelectListItem> WeekDays { get; set; }

		[MapToValue]
		public int CourseId { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Schedule_Course_Name")]
		public List<SelectListItem> Courses { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Schedule_Course_Name")]
		public List<CourseViewModel> CoursesCustom { get; set; }

		[MapToEntity]
		public CourseViewModel Course { get; set; }

		[MapToValue]
		public int AgeGroupId { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Schedule_AgeGroup_Name")]
		public List<SelectListItem> AgeGroups { get; set; }

		[MapToEntity]
		public AgeGroupViewModel AgeGroup { get; set; }

		public int ServiceId { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Schedule_Service_Name")]
		public List<SelectListItem> Services { get; set; }

		public int AffiliateId { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Schedule_Affiliate_Name")]
		public List<SelectListItem> Affiliates { get; set; }
	}
}