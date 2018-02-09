using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class ChangelogController : MasterController
    {
        // GET: Changelog
        public ActionResult Index()
        {
            var model = new Models.ViewModels.vmChangeLog();
            model.AllChangeLog = new Domain.Dominio.ChangeLogDomain().GetAll();
            return View(model);
        }
    }
}