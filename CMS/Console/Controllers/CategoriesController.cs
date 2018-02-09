using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class CategoriesController : MasterController
    {
        // GET: Categories
        public ActionResult Index()
        {
            var model = new Models.ViewModels.vmCategories();
            model.AllCategories = new Domain.Dominio.CategoriesDomain().GetAll();
            return View(model);
        }

        public ActionResult Form(long? id)
        {
            var model = new Models.POCOs.CategoriesModel();
            if (id != null)
            {
                model = new Domain.Dominio.CategoriesDomain().GetById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Form(Models.POCOs.CategoriesModel model)
        {
            if (model != null)
            {
                var result = new Domain.Dominio.CategoriesDomain().AddOrUpdate(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult deleteCategory(string id)
        {
            long idL = Convert.ToInt64(id);
            var result = new Domain.Dominio.CategoriesDomain().DeleteById(idL);
            return Json(" ", JsonRequestBehavior.AllowGet);
        }
    }
}