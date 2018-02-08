using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConsoleCMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var filepath = Server.MapPath("~/App_Data/Error.txt");
            var Ex = Server.GetLastError();
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                writer.WriteLine("Message :" + Ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + Ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }

            Response.Redirect("~/Error.aspx", true);
        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers.Remove("X-Powered-By");
        }

        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.Request.Path.Contains("Preloader.js"))
        //    {
        //        var hosst = HttpContext.Current.Request.Url.Host;
        //        Response.Redirect(hosst + "/Error/Index");
        //    }
        //}

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
            + HttpContext.Current.Request.RawUrl);
            }
            if (HttpContext.Current.Request.Path.Contains("Preloader.js"))
            {
                var hosst = HttpContext.Current.Request.Url.Host;
                Response.Redirect(hosst + "/Error/Index");
            }
        }

        protected void Application_End()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers.Remove("X-Powered-By");
        }
    }
}
