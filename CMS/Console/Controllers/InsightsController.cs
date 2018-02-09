using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsoleCMS.Models;
using System.Web.Script.Serialization;


namespace ConsoleCMS.Controllers
{
    public class InsightsController : MasterController
    {
        //// GET: Insights
        //public ActionResult Index()
        //{
        //    var model = new Models.ViewModels.vmInsights();
        //    model.listGraphs = new Domain.Dominio.InsightsDomain().GetInfo();
        //    return View(model);
        //}


        //[HttpPost]
        //public JsonResult ChartByState()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetStates();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartBytype()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetTypes();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByAge()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetAges();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByAudience()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetAudiences();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByAgeChidrens()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetStatesChildrens();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByModulesCompletes()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetModulesCompletes();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByModulesCompletesTwo()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetModulesCompletesTwo();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByCertificateComplete()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetCertificatesCompletes();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByELearning()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetELearning();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult ChartByImplementation()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetImplementations();
        //    return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult Map()
        //{
        //    var lstSummary = new ConsoleCMS.Domain.Dominio.InsightsDomain().GetLocations();
        //    var jsonSerialiser = new JavaScriptSerializer();
        //    var json = jsonSerialiser.Serialize(lstSummary);
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}
    }
}