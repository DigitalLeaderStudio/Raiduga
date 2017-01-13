namespace Raiduga.Web.Models.UserFeedback
{
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;

	public class UserFeedbackViewModel : AFileViewModel, IGeneratable<UserFeedback, UserFeedbackViewModel>, IDateExtented
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_UserName")]
		public string UserName { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_Text")]
		public string Text { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "UserFeedback_IsActive")]
		public bool IsActive { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? UpdationDate { get; set; }

		public UserFeedbackViewModel FromDbModel(UserFeedback model)
		{
			this.Id = model.Id;
			this.Text = model.Text;
			this.UserName = model.UserName;
			this.IsActive = model.IsActive;
			this.ImageId = model.ImageId;
			this.CreationDate = model.CreationDate;
			this.UpdationDate = model.UpdationDate;

			return this;
		}

		public UserFeedback ToDbModel()
		{
			var result = new UserFeedback
			{
				Id = this.Id,
				Text = this.Text,
				UserName = this.UserName,
				IsActive = this.IsActive,
				CreationDate = this.CreationDate,
				UpdationDate = this.UpdationDate,
				Image = this.GetFile()
			};

			return result;
		}
	}
}