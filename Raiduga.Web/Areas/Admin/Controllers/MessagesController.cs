namespace Raiduga.Web.Areas.Admin.Controllers
{
    using Autofac;
    using Raiduga.Web.Areas.Admin.Controllers.Base;
    using Raiduga.Web.Models.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class MessagesController : BaseAdminController
    {
        public MessagesController(IComponentContext componentContext)
            : base(componentContext)
        {
        }

        // GET: Admin/Admin
        public ActionResult Index()
        {
            var dbData = DbContext.ContactRequests.OrderByDescending(cr => cr.CreationDate);

            var model = new List<ContactRequestViewModel>();
            foreach (var dbItem in dbData)
            {
                model.Add(_modelTransformer.GetViewModel<ContactRequestViewModel>(dbItem));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult MarkAsRead(FormCollection form)
        {
            var itemId = int.Parse(form["cr.Id"]);

            var dbItem = DbContext.ContactRequests.Find(itemId);
            dbItem.UpdationDate = DateTime.Now;

            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}