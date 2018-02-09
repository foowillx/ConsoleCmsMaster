using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConsoleCMS.Models.POCOs
{
    public class ReCaptchaModel
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }

        public static bool Validate(string encodedResponse)
        {
            if (string.IsNullOrEmpty(encodedResponse)) return false;

            var client = new System.Net.WebClient();
            var secret = ConfigurationManager.AppSettings["recaptchaPrivateKey"];

            if (string.IsNullOrEmpty(secret)) return false;

            var direccion = string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encodedResponse);
            var googleReply = client.DownloadString(direccion);

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var reCaptcha = serializer.Deserialize<ReCaptchaModel>(googleReply);

            return reCaptcha.Success;
        }
    }
}
