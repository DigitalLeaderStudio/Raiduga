namespace Raiduga.Models.Interfaces
{
	public interface IImageble
	{
		int? ImageId { get; set; }

		File Image { get; set; }
	}
}
