using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Domain.Dominio
{
    public class AppUsersDomain
    {
        public List<Models.POCOs.AppusersModel> GetAll()
        {
            var result = new List<Models.POCOs.AppusersModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.AppUsers select x).ToList();
                    //var search = (from x in db.AppUsers where x.UserName.Contains("Batdir") select x).ToList().Take(100);
                    foreach (var reg in search)
                    {
                        var item = new Util.ConvertEFtoModel().Appuser(reg);
                        item.State = new Util.ConvertEFtoModel().States(reg.States);
                        result.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public List<Models.POCOs.AppusersModel> ByDates(DateTime MinDate, DateTime MaxDate)
        {
            var result = new List<Models.POCOs.AppusersModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.AppUsers where (x.FechaRegistro > MinDate && x.FechaRegistro < MaxDate) select x).ToList();
                    foreach (var reg in search)
                    {
                        var item = new Util.ConvertEFtoModel().Appuser(reg);
                        item.State = new Util.ConvertEFtoModel().States(reg.States);
                        result.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.POCOs.AppusersModel GetById(long id)
        {
            var result = new Models.POCOs.AppusersModel();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.AppUsers where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        result = new Util.ConvertEFtoModel().Appuser(search);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
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
