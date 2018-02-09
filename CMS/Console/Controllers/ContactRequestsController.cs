using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class ContactRequestsController : MasterController
    {
        // GET: ContactRequests
        public ActionResult Index()
        {
            var model = new Models.ViewModels.vmContactRequests();
            model.AllContactRequests = new Domain.Dominio.ContactRequestsDomain().GetAll();
            return View(model);
        }

        public ActionResult deleteCR(string id)
        {
            long idL = Convert.ToInt64(id);
            var result = new Domain.Dominio.ContactRequestsDomain().DeleteById(idL);
            return Json(" ", JsonRequestBehavior.AllowGet);
        }
    }
}