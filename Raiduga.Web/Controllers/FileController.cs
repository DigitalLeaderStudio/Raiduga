namespace Raiduga.Web.Controllers
{
	using System.Web.Mvc;

	public class FileController : BaseController
	{
		public ActionResult Show(int id)
		{
			var dbFile = DbContext.Files.Find(id);

			return File(dbFile.Content, dbFile.ContentType);
		}
	}
}