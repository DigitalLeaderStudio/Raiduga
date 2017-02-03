namespace Raiduga.Web.Controllers
{
	using Raiduga.Interface;
	using System.Web.Mvc;
	using System.Web.UI;

	public class FileController : BaseController
	{
		public FileController()
		{
		}

		[OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
		public ActionResult Show(int id)
		{
			var dbFile = DbContext.Files.Find(id);

			return File(dbFile.Content, dbFile.ContentType);
		}
	}
}