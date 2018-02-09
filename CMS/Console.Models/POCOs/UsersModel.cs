using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace ConsoleCMS.Models.POCOs
{
    [Table("Users")]
    public class UsersModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastNames { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Type { get; set; }
        public DateTime? LockedAt { get; set; }
        public DateTime? LastChangePassword { get; set; }
        public DateTime? LinkDate { get; set; }
        public string Token { get; set; }

        public static class PasswordRegex
        {
            public const string UpperLetter = @"[A-Z]+";
            public const string Number = @"[0-9]+";
            public const string SpecialChar = @"[@#\$%\^&\*!]";
            public const string ConsecutiveChars = @"(.)\1\1";
            public const string Reserved = @"^(?!.*(?i)password).*$";
            //public const string Reserved2 = @"^(?!.*(?i)contrasena).*$";
            public const string Reserved3 = @"^(?!.*(?i)contrase*).*$";
            //public const string Reserved4 = @"^(?!.*(?i)contrasen).*$";
            public const string Reserved5 = @"^(?!.*(?i)senha).*$";
        }

        public static class PasswordErrors
        {
            public const string UpperLetter = "Debe contener al menos una mayúscula";
            public const string Number = "Debe contener al menos un número";
            public const string SpecialChar = "Debe contener al menos un caracter especial (@#$%^&*!)";
            public const string ConsecutiveChars = "No puede contener 3 números o caracteres iguales consecutivos. (Ej: 1111, aaaa)";
            public const string Reserved = "No puede contener la palabra 'password'";
            public const string Reserved2 = "No puede contener la palabra 'contrasena'";
            public const string Reserved3 = "No puede contener la palabra 'contrase', 'contrasena', 'contrasen'";
            public const string Reserved4 = "No puede contener la palabra 'contrasen'";
            public const string Reserved5 = "No puede contener la palabra 'senha'";
        }

        public void Validate(List<Models.ViewModels.vmResult> errorSummary, string UserType, string Password)
        {
            ValidateRegex("Password", PasswordRegex.UpperLetter, Password, PasswordErrors.UpperLetter, errorSummary);
            ValidateRegex("Password", PasswordRegex.Number, Password, PasswordErrors.Number, errorSummary);
            ValidateRegex("Password", PasswordRegex.SpecialChar, Password, PasswordErrors.SpecialChar, errorSummary);
            ValidateNegRegex("Password", PasswordRegex.ConsecutiveChars, Password, PasswordErrors.ConsecutiveChars, errorSummary);
            ValidateRegex("Password", PasswordRegex.Reserved, Password, PasswordErrors.Reserved, errorSummary);
            //ValidateRegex("Password", PasswordRegex.Reserved2, Password, PasswordErrors.Reserved2, errorSummary);
            ValidateRegex("Password", PasswordRegex.Reserved3, Password, PasswordErrors.Reserved3, errorSummary);
            //ValidateRegex("Password", PasswordRegex.Reserved4, Password, PasswordErrors.Reserved4, errorSummary);
            ValidateRegex("Password", PasswordRegex.Reserved5, Password, PasswordErrors.Reserved5, errorSummary);
            if (UserType == "Administrador")
            {
                ValidateString2("Password", Password, 16, errorSummary);
            }
            else
            {
                ValidateString2("Password", Password, 10, errorSummary);
            }

        }

        public static class ValidationValues
        {
            //public const string NonEmpty = "No puede ser vac&iacute;o";
            public const string NonEmpty = "Campo Obligatorio";
            public const string CharRange = "Deben contener entre {0} y {1} caracteres.";
            public const string CharRange2 = "Deben contener mínimo {0} caracteres.";
            public const string Email = "Debe ser un correo v&aacute;lido";
            public const string Integer = "Debe ser un entero";
            public const string Checked = "Se debe aceptar";
            public const string SameAs = "No coincide";
        }

        protected void ValidateRegex(string key, string pattern, string field, string errorMessage, List<Models.ViewModels.vmResult> errors)
        {
            Regex rex = new Regex(pattern);
            if (field != null && !rex.IsMatch(field))
            {
                var error = new Models.ViewModels.vmResult();
                error.Status = false;
                error.Message = errorMessage;
                error.ErrorCount = 1;
                errors.Add(error);
            }
            //IsMatch
            //rex = new Regex(@"data:\w*\/\w*;base64,");
        }

        protected void ValidateNegRegex(string key, string pattern, string field, string errorMessage, List<Models.ViewModels.vmResult> errors)
        {
            Regex rex = new Regex(pattern);
            if (field != null && rex.IsMatch(field))
            {
                var error = new Models.ViewModels.vmResult();
                error.Status = false;
                error.Message = errorMessage;
                error.ErrorCount = 1;
                errors.Add(error);
            }
            //IsMatch
            //rex = new Regex(@"data:\w*\/\w*;base64,");
        }

        protected void ValidateString2(string key, string field, int min, List<Models.ViewModels.vmResult> errors)
        {
            if ((field != null) && (field.Length < min))
            {
                string err = string.Format(ValidationValues.CharRange2, min);

                var error = new Models.ViewModels.vmResult();
                error.Status = false;
                error.Message = err;
                error.ErrorCount = 1;
                errors.Add(error);

            }
        }

        public static string Encrypt(string str)
        {
            string res = string.Empty;
            if (str == null) str = string.Empty;
            SHA256Managed crypt = new SHA256Managed();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (byte bit in crypto)
            {
                res += bit.ToString("x2");
            }
            return res;
        }
    }
}
