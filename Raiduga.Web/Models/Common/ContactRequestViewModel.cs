namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class ContactRequestViewModel : IDateExtented, IViewModel
	{
		public ContactRequestViewModel()
		{
			SuccessfullySent = false;
		}

		[MapToEntityValue]
		public int Id { get; set; }

		[MapToEntityValue]
		public string FirstName { get; set; }

		[MapToEntityValue]
		public string LastName { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "ContactsForm_Phone")]
		[Phone(ErrorMessageResourceName = "ContactsForm_Phone_Type", ErrorMessageResourceType = typeof(Translations))]
		[MapToEntityValue]
		public string Phone { get; set; }

		[Required(ErrorMessageResourceName = "ContactsForm_Email_Required", ErrorMessageResourceType = typeof(Translations))]
		[Display(ResourceType = typeof(Translations), Name = "ContactsForm_Email")]
		[EmailAddress(ErrorMessageResourceName = "ContactsForm_Email_Type", ErrorMessageResourceType = typeof(Translations))]
		[MapToEntityValue]
		public string Email { get; set; }

		[Required(ErrorMessageResourceName = "ContactsForm_Message_Required", ErrorMessageResourceType = typeof(Translations))]
		[Display(ResourceType = typeof(Translations), Name = "ContactsForm_Message")]
		[MapToEntityValue]
		public string Message { get; set; }

		[MapToEntityValue]
		public DateTime? CreationDate { get; set; }

		[MapToEntityValue]
		public DateTime? UpdationDate { get; set; }

		public List<string> Errors { get; set; }

		public bool SuccessfullySent { get; set; }

		public string RedirectLink { get; set; }

		//public ContactRequestViewModel FromDbModel(ContactRequest model)
		//{
		//	this.Id = model.Id;
		//	this.Message = model.Message;
		//	this.Email = model.Email;
		//	this.Phone = model.Phone;
		//	this.LastName = model.LastName;
		//	this.FirstName = model.FirstName;
		//	this.CreationDate = model.CreationDate;
		//	this.UpdationDate = model.UpdationDate;

		//	return this;
		//}

		//public ContactRequest ToDbModel()
		//{
		//	var result = new ContactRequest
		//	{
		//		Id = this.Id,
		//		FirstName = this.FirstName,
		//		LastName = this.LastName,
		//		Phone = this.Phone,
		//		Email = this.Email,
		//		Message = this.Message,
		//		CreationDate = this.CreationDate,
		//		UpdationDate = this.UpdationDate
		//	};

		//	return result;
		//}
	}
}