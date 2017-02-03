namespace Raiduga.Web.Models.UserFeedback
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;

	public class UserFeedbackViewModel : AbstractFileViewModel, IDateExtented, IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_UserName")]
		[MapToEntityValue]
		public string UserName { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_Text")]
		[MapToEntityValue]
		public string Text { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_IsActive")]
		[MapToEntityValue]
		public bool IsActive { get; set; }

		[MapToEntityValue]
		public DateTime? CreationDate { get; set; }

		[MapToEntityValue]
		public DateTime? UpdationDate { get; set; }
	}
}