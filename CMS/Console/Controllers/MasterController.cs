using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class MasterController : Controller
    {
        [NonAction]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Expires"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Home");
            }
            else
            {
                if (Convert.ToDateTime(Session["Expires"]) < DateTime.Now)
                {
                    filterContext.Result = RedirectToAction("Login", "Home");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}