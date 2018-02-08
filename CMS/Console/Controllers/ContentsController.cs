using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class ContentsController : MasterController
    {
        // GET: Contents
        public ActionResult Index()
        {
            var model = new Models.ViewModels.vmContents();
            model.AllContents = new Domain.Dominio.ContentsDomain().GetAll();

            return View(model);
        }

        public ActionResult Form(long? id)
        {
            ViewBag.Categories = new Domain.Dominio.CategoriesDomain().GetAll();
            var model = new Models.POCOs.ContentsModel();
            if (id != null)
            {
                model = new Domain.Dominio.ContentsDomain().GetById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Form(Models.POCOs.ContentsModel model)
        {
            if (model != null)
            {
                var result = new Domain.Dominio.ContentsDomain().AddOrUpdate(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult deleteContent(string id)
        {
            long idL = Convert.ToInt64(id);
            var result = new Domain.Dominio.ContentsDomain().DeleteById(idL);
            return Json(" ", JsonRequestBehavior.AllowGet);
        }
    }
}