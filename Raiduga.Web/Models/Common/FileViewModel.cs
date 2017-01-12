namespace Raiduga.Web.Models.Common
{
	using Raiduga.Models;
	using System;

	public class FileViewModel : IGeneratable<File, FileViewModel>
	{
		public int Id { get; set; }

		public string FileName { get; set; }

		public string ContentType { get; set; }

		public byte[] Content { get; set; }

		public FileViewModel FromDbModel(File model)
		{
			if (model == null) return null;

			this.Id = model.Id;
			this.FileName = model.FileName;
			this.ContentType = model.ContentType;
			this.Content = model.Content;

			return this;
		}

		public File ToDbModel()
		{
			var result = new File
			{
				Id = this.Id,
				FileName = this.FileName,
				ContentType = this.ContentType,
				Content = this.Content
			};

			return result;
		}

		public string GetBase64()
		{
			var result = string.Empty;

			if (this.Content != null && this.Content.Length > 0)
			{
				result = string.Format("data:{0},base64,{1}", "gif", Convert.ToBase64String(this.Content));
			}

			return result;
		}
	}
}