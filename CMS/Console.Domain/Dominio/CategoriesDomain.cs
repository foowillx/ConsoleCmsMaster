using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Domain.Dominio
{
    public class CategoriesDomain
    {
        public List<Models.POCOs.CategoriesModel> GetAll()
        {
            var result = new List<Models.POCOs.CategoriesModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Categories select x).ToList();
                    foreach (var reg in search)
                    {
                        result.Add(new Util.ConvertEFtoModel().Categories(reg));
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.POCOs.CategoriesModel GetById(long id)
        {
            var result = new Models.POCOs.CategoriesModel();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Categories where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        result = new Util.ConvertEFtoModel().Categories(search);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.ViewModels.vmResult AddOrUpdate(Models.POCOs.CategoriesModel model)
        {
            var result = new Models.ViewModels.vmResult();
            try
            {
                bool exist = false;
                var newReg = new Data.EntityFramework.Categories();
                using (var db = new Data.EntityFramework.Entities())
                {
                    if (db.Categories.Any(x => x.Id == model.Id))
                    {
                        exist = true;
                        newReg = (from x in db.Categories where x.Id == model.Id select x).FirstOrDefault();
                    }

                    newReg.Name = model.Name;
                    newReg.Color = model.Color;


                    if (!exist)
                    {
                        db.Categories.Add(newReg);
                    }
                    db.SaveChanges();
                    result.Status = true;
                    result.ErrorCount = 0;
                    result.Message = " ";
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.ToString();
                result.ErrorCount = result.ErrorCount + 1;
            }
            return result;
        }

        public bool DeleteById(long id)
        {
            bool result = false;
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Categories where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        db.Categories.Remove(search);
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
