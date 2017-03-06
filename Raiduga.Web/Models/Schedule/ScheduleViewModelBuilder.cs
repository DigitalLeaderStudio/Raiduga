namespace Raiduga.Web.Models.Schedule
{
	using Raiduga.Models;
	using Raiduga.Web.Models.Common;
	using Raiduga.Web.Models.Service;
	using System.Collections.Generic;
	using System.Linq;

	public class ScheduleViewModelBuilder
	{
		public List<AffiliateViewModel> BuildSchedule(Affiliate[] affiliates)
		{
			var result = affiliates
				.Select(affiliate => new AffiliateViewModel
				{
					Id = affiliate.Id,
					Name = affiliate.Address.Name,
					IsPrimary = affiliate.IsPrimary,
					Services = affiliate.Courses
						.GroupBy(c => new { c.ServiceId, c.Service.Name })
						.Select(serviceGroup =>
						{
							#region age groups flat selection
							var ageGroups = serviceGroup
								.SelectMany(c => c.Lessons)
								.GroupBy(l => new
								{
									l.AgeGroup.Id,
									l.AgeGroup.Name
								})
								.OrderBy(ag => ag.Key.Name)
								.ToArray();
							#endregion

							var ageGroupsViewModel = new List<AgeGroupViewModel>();

							foreach (var ageGroup in ageGroups)
							{
								var coursesViewModel = new List<CourseViewModel>();

								var lessonsGroupedByCourse = ageGroup
									.GroupBy(l => new { l.Course.Name, l.Course.Id, l.Course.Duration })
									.ToList();

								foreach (var courseGroup in lessonsGroupedByCourse)
								{
									#region course view model creating

									coursesViewModel.Add(new CourseViewModel
									{
										Id = courseGroup.Key.Id,
										Name = courseGroup.Key.Name,
										Duration = courseGroup.Key.Duration,
										Lessons = courseGroup.Select(lesson => new LessonViewModel
										{
											Id = lesson.Id,
											TeacherFullName = lesson.TeacherFullName,
											StartTime = lesson.StartTime,
											GroupName = lesson.GroupName,
											WeekDay = lesson.WeekDay
										}).ToList()
									});

									#endregion
								}

								#region age group view model creation
								ageGroupsViewModel.Add(new AgeGroupViewModel
								{
									Id = ageGroup.Key.Id,
									Name = ageGroup.Key.Name,
									Courses = coursesViewModel
								});
								#endregion
							}

							return new ServiceViewModel
							{
								Name = serviceGroup.Key.Name,
								AgeGroups = ageGroupsViewModel
							};
						}).ToList()
				}).ToList();

			return result;
		}
	}
}