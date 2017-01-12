namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using Raiduga.Web.Models.Service;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class ServiceController : BaseController
	{
		public ActionResult Index()
		{
			var dbData = DbContext.Services.ToArray();
			var model = new List<ServiceViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new ServiceViewModel().FromDbModel(dbItem));
			}

			return View(model);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			var model = new List<AffiliateViewModel>();

			foreach (var affiliate in DbContext.Affiliates.OrderByDescending(a => a.IsPrimary).ToArray())
			{
				model.Add(new AffiliateViewModel().FromDbModel(affiliate));
			}

			return View(model);
		}
	}
}