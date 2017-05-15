namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Web.Models.Campaign;
	using System.Data.Entity;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class CampaignController : BaseController
	{
		public CampaignController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("Акції/{compaignName}")]
		public async Task<ActionResult> Index(string compaignName)
		{
			try
			{
				var entity = await DbContext.Campaigns
					.Where(c => c.Name == compaignName && c.IsActive)
					.FirstOrDefaultAsync();

				var viewModel = entity == null
					? null
					: _modelTransformer.GetViewModel<CampaignViewModel>(entity);

				return View(viewModel);
			}
			catch
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public ActionResult Index()
		{

			return View();

		}

        public ActionResult Test()
		{
			return View();
		}
	}
}