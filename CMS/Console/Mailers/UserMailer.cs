using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using ConsoleCMS.Models.POCOs;

namespace ConsoleCMS.Mailers
{
    public class UserMailer : MailerBase, IUserMailer
    {
        public virtual MvcMailMessage PasswordResetAdmin(UsersModel user, string token)
        {
            ViewBag.Token = token;
            ViewBag.Title = "Recupera Contraseña";
            ViewBag.Legend = "Nestlé Nutrir";
            return Populate(x =>
            {
                x.Subject = "Recuperar Contraseña";
                x.ViewName = "PasswordResetAdmin";
                x.To.Add(user.Mail);
            });
        }
    }
}