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
		[MapToValue]
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_UserName")]
		[MapToValue]
		public string UserName { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_Text")]
		[MapToValue]
		public string Text { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_IsActive")]
		[MapToValue]
		public bool IsActive { get; set; }

		[MapToValue]
		public DateTime? CreationDate { get; set; }

		[MapToValue]
		public DateTime? UpdationDate { get; set; }
	}
}