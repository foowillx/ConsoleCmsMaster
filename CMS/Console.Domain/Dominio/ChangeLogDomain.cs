using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Domain.Dominio
{
    public class ChangeLogDomain
    {
        public List<Models.POCOs.ChangeLogModel> GetAll()
        {
            var res = new List<Models.POCOs.ChangeLogModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.ChangeLog orderby x.DateAction descending select x);
                    foreach (var reg in search)
                    {
                        res.Add(new Util.ConvertEFtoModel().ChangeLog(reg));
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return res;
        }
    }
}
