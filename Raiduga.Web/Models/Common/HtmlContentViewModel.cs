namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class HtmlContentViewModel : IDateExtented, IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Content_Name")]
		[MapToEntityValue]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Content_BodyHtml")]
		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[MapToEntityValue]
		public string BodyHtml { get; set; }

		[MapToEntityValue]
		public DateTime? CreationDate { get; set; }

		[MapToEntityValue]
		public DateTime? UpdationDate { get; set; }

		//public HtmlContentViewModel FromDbModel(HtmlContent model)
		//{
		//	this.Id = model.Id;
		//	this.Name = model.Name;
		//	this.BodyHtml = model.BodyHtml;
		//	this.CreationDate = model.CreationDate;
		//	this.UpdationDate = model.UpdationDate;

		//	return this;
		//}

		//public HtmlContent ToDbModel()
		//{
		//	var result = new HtmlContent
		//	{
		//		Id = this.Id,
		//		Name = this.Name,
		//		BodyHtml = this.BodyHtml,
		//		CreationDate = this.CreationDate,
		//		UpdationDate = this.UpdationDate
		//	};

		//	return result;
		//}
	}
}