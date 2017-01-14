namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class CommonController : BaseController
	{
		// GET: Common
		public ActionResult _SliderPartial()
		{
			var model = new List<SliderItemViewModel>();

			foreach (var dbItem in DbContext.SliderItems.ToArray())
			{
				model.Add(new SliderItemViewModel().FromDbModel(dbItem));
			}

			return PartialView(model);
		}

		public ActionResult _FooterPartial()
		{
			var dbData = DbContext.Affiliates.First(a => a.IsPrimary);
			var model = new AffiliateViewModel().FromDbModel(dbData);

			return PartialView(model);
		}
	}
}