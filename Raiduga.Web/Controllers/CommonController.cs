namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using System.Data.Entity;

	public class CommonController : BaseController
	{
		// GET: Common
		public ActionResult _SliderPartial()
		{
			var model = new List<SliderItemViewModel>();

			foreach (var dbItem in DbContext.SliderItems.Include(si => si.Image).ToArray())
			{
				model.Add(SliderItemViewModel.FromDbModel(dbItem));
			}

			return PartialView(model);
		}
	}
}