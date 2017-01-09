namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using System.ComponentModel.DataAnnotations;
	using System.Web;

	public class SliderItemViewModel
	{
		public int Id { get; set; }

		[Required]
		[Display(ResourceType = typeof(Translations), Name = "Slider_Title")]
		public string Title { get; set; }

		[Required]
		[Display(ResourceType = typeof(Translations), Name = "Slider_SubTitle")]
		public string SubTitle { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Slider_Image")]
		public HttpPostedFileBase File { get; set; }

		public byte[] Image { get; set; }

		public SliderItem ToDbModel()
		{
			var result = new SliderItem
			{
				Id = this.Id,
				Title = this.Title,
				SubTitle = this.SubTitle
			};

			if (this.File != null && this.File.ContentLength > 0)
			{
				using (var reader = new System.IO.BinaryReader(this.File.InputStream))
				{
					result.Image = new File
					{
						FileName = System.IO.Path.GetFileName(this.File.FileName),
						ContentType = this.File.ContentType,
						Content = reader.ReadBytes(this.File.ContentLength)
					};
				}
			}

			return result;
		}

		public static SliderItemViewModel FromDbModel(SliderItem dbModel)
		{
			var result = new SliderItemViewModel
			{
				Id = dbModel.Id,
				Title = dbModel.Title,
				SubTitle = dbModel.SubTitle,
				Image = dbModel.Image == null ? null : dbModel.Image.Content
			};

			return result;
		}
	}
}