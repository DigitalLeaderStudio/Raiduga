namespace Raiduga.Web.Models.Service
{
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Common;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class ApplyToCourseViewModel : IGeneratable<ApplyToCourseRequest, ApplyToCourseViewModel>, IDateExtented
	{
		public ApplyToCourseViewModel()
		{
			BirthDateConstructor = new DateConstructorViewModel();
		}

		public int Id { get; set; }

		public int CourseId { get; set; }

		public string CourseName { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "ApplyToCourse_ChildName")]
		[Required(ErrorMessageResourceName = "ApplyToCourse_ChildName_Required", ErrorMessageResourceType = typeof(Translations))]
		public string ChildName { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "ApplyToCourse_Phone")]
		[Phone(ErrorMessageResourceName = "ContactsForm_Phone_Type", ErrorMessageResourceType = typeof(Translations))]
		[Required(ErrorMessageResourceName = "ApplyToCourse_Phone_Required", ErrorMessageResourceType = typeof(Translations))]
		public string Phone { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "ApplyToCourse_Email")]
		[EmailAddress(ErrorMessageResourceName = "ContactsForm_Email_Type", ErrorMessageResourceType = typeof(Translations))]
		public string Email { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "ApplyToCourse_ChildBirthDate")]
		public DateConstructorViewModel BirthDateConstructor { get; set; }

		public DateTime? BirthDate { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public bool SuccessfullySent { get; set; }

		public List<string> Errors { get; set; }

		public ApplyToCourseViewModel FromDbModel(ApplyToCourseRequest model)
		{
			this.BirthDate = model.BirthDate;
			this.ChildName = model.ChildName;
			this.CreationDate = model.CreationDate;
			this.Email = model.Email;
			this.Id = model.Id;
			this.Phone = model.Phone;
			this.UpdationDate = model.UpdationDate;
			this.CourseId = model.CourseId;
			this.CourseName = model.Course.Name;

			return this;
		}

		public ApplyToCourseRequest ToDbModel()
		{
			var birthDate = new DateTime(
				this.BirthDateConstructor.Year,
				this.BirthDateConstructor.Month,
				this.BirthDateConstructor.Day);

			var result = new ApplyToCourseRequest
			{
				BirthDate = birthDate,
				ChildName = this.ChildName,
				CourseId = this.CourseId,
				CreationDate = this.CreationDate,
				Email = this.Email,
				Id = this.Id,
				Phone = this.Phone,
				UpdationDate = this.UpdationDate
			};

			return result;
		}
	}
}