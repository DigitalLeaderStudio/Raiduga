namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using System.ComponentModel.DataAnnotations;
	using System.Web;

	public class SliderItemViewModel : IGeneratable<SliderItem, SliderItemViewModel>
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

		public int? ImageId { get; set; }

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

		public SliderItemViewModel FromDbModel(SliderItem model)
		{
			var result = new SliderItemViewModel
			{
				Id = model.Id,
				Title = model.Title,
				SubTitle = model.SubTitle,
				ImageId = model.ImageId
			};

			return result;
		}
	}
}