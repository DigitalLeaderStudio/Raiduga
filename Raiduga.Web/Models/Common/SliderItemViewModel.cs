namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.Web;

	public class SliderItemViewModel : AFileViewModel, IGeneratable<SliderItem, SliderItemViewModel>
	{
		public int Id { get; set; }

		[Required]
		[Display(ResourceType = typeof(Translations), Name = "Slider_Title")]
		public string Title { get; set; }

		[Required]
		[Display(ResourceType = typeof(Translations), Name = "Slider_SubTitle")]
		public string SubTitle { get; set; }

		public SliderItem ToDbModel()
		{
			var result = new SliderItem
			{
				Id = this.Id,
				Title = this.Title,
				SubTitle = this.SubTitle,
				Image = this.GetFile()
			};

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