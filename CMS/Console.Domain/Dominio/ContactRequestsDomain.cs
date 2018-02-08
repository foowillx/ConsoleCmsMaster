using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Domain.Dominio
{
    public class ContactRequestsDomain
    {
        public List<Models.POCOs.ContactRequestsModel> GetAll()
        {
            var res = new List<Models.POCOs.ContactRequestsModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.ContactRequests where x.Name != "" && x.MiddleName != "" && x.LastName != "" && x.Mail != "" orderby x.CreatedAt descending select x).ToList();
                    foreach (var reg in search)
                    {
                        res.Add(new Util.ConvertEFtoModel().ContactRequests(reg));
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return res;
        }

        public bool DeleteById(long id)
        {
            bool result = false;
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.ContactRequests where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        db.ContactRequests.Remove(search);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }
    }
}
