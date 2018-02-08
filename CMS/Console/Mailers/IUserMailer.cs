using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using ConsoleCMS.Models.POCOs;

namespace ConsoleCMS.Mailers
{
    public interface IUserMailer
    {
        MvcMailMessage PasswordResetAdmin(UsersModel user, string token);
    }
}