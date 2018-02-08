using ConsoleCMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class AppUsersController : MasterController
    {
        // GET: AppUsers
        public ActionResult Index()
        {
            var model = new vmAppUsers()
            {
                AllAppUsers = new Domain.Dominio.AppUsersDomain().GetAll(),
                MaxDate = DateTime.UtcNow.Date,
                MinDate = DateTime.UtcNow.AddMonths(-1).Date
            };
            return View(model);
        }

        // Post: AppUsers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(vmAppUsers Model)
        {
            var model = new vmAppUsers()
            {
                AllAppUsers = new Domain.Dominio.AppUsersDomain().ByDates(Model.MinDate, Model.MaxDate)
            };
            return View(model);
        }
        //public ActionResult AppUsersLocations(string id)
        //{
        //    var model = new Models.ViewModels.vmAppUsersLocations();
        //    model.AllAppUsersLocations = new Domain.Dominio.AppUsersDomain().GetLocationsByAppUserId(Convert.ToInt64(id));
        //    return View(model);
        //}

        //public ActionResult AppUsersSections(string id)
        //{
        //    var model = new Models.ViewModels.vmAppUsersSections();
        //    model.AllAppUsersSections = new Domain.Dominio.AppUsersDomain().GetAppUserSectionsById(Convert.ToInt64(id));
        //    return View(model);
        //}

        //public ActionResult AppUsersSectionsContent(string id)
        //{
        //    var model = new Models.ViewModels.vmAppUsersSectionsContents();
        //    model.AllContents = new Domain.Dominio.AppUsersDomain().GetSections(Convert.ToInt64(id));
        //    return View(model);
        //}
    }
}