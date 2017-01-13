namespace Raiduga.Web.Models.Interfaces
{
	using Raiduga.Models;
	using Raiduga.Web.Localization;
	using System.ComponentModel.DataAnnotations;
	using System.Web;

	public abstract class AFileViewModel
	{
		[Display(ResourceType = typeof(Translations), Name = "Image_Caption")]
		public virtual HttpPostedFileBase File { get; set; }

		public virtual int? ImageId { get; set; }

		public File GetFile()
		{
			File result = null;

			if (this.File != null && this.File.ContentLength > 0)
			{
				using (var reader = new System.IO.BinaryReader(this.File.InputStream))
				{
					result = new File
					{
						FileName = System.IO.Path.GetFileName(this.File.FileName),
						ContentType = this.File.ContentType,
						Content = reader.ReadBytes(this.File.ContentLength)
					};
				}
			}

			return result;
		}
	}
}