namespace Raiduga.Web.Models.Common
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;

	public class SliderItemViewModel : AbstractFileViewModel, IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[Required]
		[Display(ResourceType = typeof(Translations), Name = "Slider_Title")]
		[MapToEntityValue]
		public string Title { get; set; }

		[Required]
		[Display(ResourceType = typeof(Translations), Name = "Slider_SubTitle")]
		[MapToEntityValue]
		public string SubTitle { get; set; }
	}
}