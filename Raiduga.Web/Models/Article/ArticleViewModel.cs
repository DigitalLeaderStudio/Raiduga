namespace Raiduga.Web.Models.Article
{
	using Raiduga.Models;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class ArticleViewModel : AFileViewModel, IGeneratable<Article, ArticleViewModel>, IDateExtented, IBodyHtml
	{
		public int Id { get; set; }

		[StringLength(100)]
		[Display(ResourceType = typeof(Translations), Name = "Article_Title")]
		public string Title { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Article_Author")]
		public string Author { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Article_Keywords")]
		public string Keywords { get; set; }

		[StringLength(500)]
		[Display(ResourceType = typeof(Translations), Name = "Article_Description")]
		public string Description { get; set; }

		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[Display(ResourceType = typeof(Translations), Name = "Article_BodyHtml")]
		public string BodyHtml { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Article_IsPublished")]
		public bool IsPublished { get; set; }

		public System.DateTime? CreationDate { get; set; }

		public System.DateTime? UpdationDate { get; set; }

		public ArticleViewModel FromDbModel(Article model)
		{
			this.Id = model.Id;
			this.Title = model.Title;
			this.Author = model.Author;
			this.BodyHtml = model.BodyHtml;
			this.Keywords = model.Keywords;
			this.Description = model.Description;

			this.ImageId = model.ImageId;

			this.IsPublished = model.IsPublished;

			this.CreationDate = model.CreationDate;
			this.UpdationDate = model.UpdationDate;

			return this;

		}

		public Article ToDbModel()
		{
			var result = new Article
			{
				Id = this.Id,
				Author = this.Author,
				BodyHtml = this.BodyHtml,
				CreationDate = this.CreationDate,
				Description = this.Description,
				IsPublished = this.IsPublished,
				Keywords = this.Keywords,
				Title = this.Title,
				UpdationDate = this.UpdationDate,
				Image = this.GetFile()
			};

			return result;
		}
	}
}