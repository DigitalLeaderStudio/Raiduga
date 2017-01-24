using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Raiduga.Web.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        [Route("Розклад")]
        public ActionResult Index()
        {
            return View();
        }
    }
}