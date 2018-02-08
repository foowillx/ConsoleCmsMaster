using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class UsersController : MasterController
    {
        // GET: Users
        public ActionResult Index()
        {
            var model = new Models.ViewModels.vmUsers();
            model.AllUsers = new Domain.Dominio.UserDomain().GetAll();
            return View(model);
        }

        public ActionResult Form(long? id)
        {
            var model = new Models.POCOs.UsersModel();
            if (id != null)
            {
                model = new Domain.Dominio.UserDomain().GetById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Form(Models.POCOs.UsersModel model)
        {
            if (model != null)
            {
                var result = new Domain.Dominio.UserDomain().AddOrUpdate(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult deleteUser(string id)
        {
            long idL = Convert.ToInt64(id);
            var result = new Domain.Dominio.UserDomain().DeleteById(idL);
            return Json(" ", JsonRequestBehavior.AllowGet);
        }

        public bool ValidatePasswordAndRole(string Password, string ConfirmPassword, string Role)
        {
            bool result = false;
            List<Models.ViewModels.vmResult> errorSummaary = new List<Models.ViewModels.vmResult>();
            if ((Password != null && Password != string.Empty) && (ConfirmPassword != null && ConfirmPassword != string.Empty) && (Role != null && Role != string.Empty))
            {
                if (Password == ConfirmPassword)
                {
                    new Models.POCOs.UsersModel().Validate(errorSummaary, Role, Password);
                    if (errorSummaary.Count == 0) result = true;
                }
            }
            return result;
        }
    }
}