using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleCMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["DaTa"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Dashboard", "Home");
            }
        }

        public ActionResult Login()
        {
            if (Session["LockedAt"] == null || Convert.ToDateTime(Session["LockedAt"]) < DateTime.Now)
            {
                ViewBag.RecapKey = ConfigurationManager.AppSettings["recaptchaPublicKey"];
            }
            
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(Models.POCOs.UsersModel model)
        {
            ViewBag.RecapKey = ConfigurationManager.AppSettings["recaptchaPublicKey"];
            if (Session["LockedAt"] == null || Convert.ToDateTime(Session["LockedAt"]) < DateTime.Now)
            {
                var encodedResponse = Request.Form["g-recaptcha-response"];
                var user = model.Mail;
                var password = model.Password;
                var usermodel = new Domain.Dominio.UserDomain().Authenticate(user, password);
                if (usermodel.Name != null)
                {
                    var iscaptchaValid = Models.POCOs.ReCaptchaModel.Validate(encodedResponse);
                    if (iscaptchaValid)
                    {
                        Domain.Dominio.UserDomain.UpdateLastLogin(usermodel);
                        Session["Data"] = usermodel.Mail;
                        Session["Info"] = usermodel.Name;
                        Session["Info2"] = usermodel.Type;
                        Session["Expires"] = DateTime.Now.AddMinutes(19);
                        Session["AttemptCount"] = null;
                        Session["LockedAt"] = null;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        if (Session["AttemptCount"] == null)
                        {
                            Session["AttemptCount"] = 1;
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["AttemptCount"]) < 10)
                            {
                                Session["AttemptCount"] = Convert.ToInt32(Session["AttemptCount"]) + 1;
                            }
                            else
                            {
                                Session["AttemptCount"] = 10;
                                Session["LockedAt"] = DateTime.Now.AddMinutes(60);
                            }
                        }
                    }
                }
                else
                {
                    if (Session["AttemptCount"] == null)
                    {
                        Session["AttemptCount"] = 1;
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["AttemptCount"]) < 10)
                        {
                            Session["AttemptCount"] = Convert.ToInt32(Session["AttemptCount"]) + 1;
                        }
                        else
                        {
                            Session["AttemptCount"] = 10;
                            Session["LockedAt"] = DateTime.Now.AddMinutes(60);
                        }
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            if (Response.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-1);
            }
            return RedirectToAction("Login");
        }

        public ActionResult ForgetPassword()
        {
            ViewBag.RecapKey = ConfigurationManager.AppSettings["recaptchaPublicKey"];
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PassRecoverRequest()
        {
            var mail = Request.Form["Mail"];
            var encodedResponse = Request.Form["g-recaptcha-response"];
            var iscaptchaValid = Models.POCOs.ReCaptchaModel.Validate(encodedResponse);
            if (iscaptchaValid)
            {
                var result = new Domain.Dominio.UserDomain().SetRecoverTokenByMail(mail);
                if (result.Status)
                {
                    var user = new Domain.Dominio.UserDomain().GetById(result.Id);
                    Mailers.UserMailer mailer = new Mailers.UserMailer();
                    mailer.PasswordResetAdmin(user, result.Message).Send();
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult Profile()
        {
            ViewBag.Role = Session["Info2"].ToString();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangePassword()
        {
            var oldPss = Request.Form["OldPassword"];
            var pss = Request.Form["Password"];
            var confirmPss = Request.Form["ConfirmPassword"];
            var user = Session["Data"].ToString();
            ViewBag.Role = Session["Info2"].ToString();

            var result = new Domain.Dominio.UserDomain().ChangePassword(oldPss, pss, confirmPss, user);
            if (!result.Status)
            {
                ViewBag.Error = "Error";
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}