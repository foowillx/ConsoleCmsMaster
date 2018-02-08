using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class PostsController : MasterController
    {
        // GET: Posts
        public ActionResult Index()
        {
            var model = new Models.ViewModels.vmPosts();
            model.AllPosts = new Domain.Dominio.PostsDomain().GetAll();
            
            return View(model);
        }

        public ActionResult Form(long? id)
        {
            ViewBag.Categories = new Domain.Dominio.CategoriesDomain().GetAll();
            var model = new Models.POCOs.PostsModel();
            if (id != null)
            {
                model = new Domain.Dominio.PostsDomain().GetById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Form(Models.POCOs.PostsModel model)
        {
            if (model != null)
            {
                var result = new Domain.Dominio.PostsDomain().AddOrUpdate(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult deletePost(string id)
        {
            long idL = Convert.ToInt64(id);
            var result = new Domain.Dominio.PostsDomain().DeleteById(idL);
            return Json(" ", JsonRequestBehavior.AllowGet);
        }
    }
}