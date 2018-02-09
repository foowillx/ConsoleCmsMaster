using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCMS.Domain.Dominio
{
    public class ContentsDomain
    {
        public List<Models.POCOs.ContentsModel> GetAll()
        {
            var result = new List<Models.POCOs.ContentsModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Contents select x).ToList();
                    foreach (var reg in search)
                    {
                        var newItem = new Util.ConvertEFtoModel().Contents(reg);
                        newItem.Categoria = new Util.ConvertEFtoModel().Categories(reg.Categories);
                        var fileName = string.Format("{0}_{1}.{2}", newItem.Id.ToString(), Encrypt(newItem.Id.ToString()), newItem.ThumbExtension);
                        newItem.imgUrl = "/Assets/Contents/Thumbs/" + fileName;
                        var fileName2 = string.Format("{0}_{1}.{2}", newItem.Id.ToString(), Encrypt(newItem.Id.ToString()), newItem.Extension);
                        newItem.imgUrl = "/Assets/Contents/Contents/" + fileName2;
                        result.Add(newItem);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.POCOs.ContentsModel GetById(long id)
        {
            var result = new Models.POCOs.ContentsModel();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Contents where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        result = new Util.ConvertEFtoModel().Contents(search);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.ViewModels.vmResult AddOrUpdate(Models.POCOs.ContentsModel model)
        {
            var result = new Models.ViewModels.vmResult();
            try
            {
                bool exist = false;
                var newReg = new Data.EntityFramework.Contents();
                using (var db = new Data.EntityFramework.Entities())
                {
                    if (db.Contents.Any(x => x.Id == model.Id))
                    {
                        exist = true;
                        newReg = (from x in db.Contents where x.Id == model.Id select x).FirstOrDefault();
                    }

                    newReg.SigninRequired = model.SigninRequired;
                    if (model.Published != null)
                    {
                        newReg.Published = Convert.ToBoolean(model.Published);
                    }
                    else
                    {
                        newReg.Published = false;
                    }
                    newReg.Audience = model.Audience.Value;
                    newReg.CategoryId = model.CategoryId.Value;
                    newReg.PublishedAt = DateTime.Now;
                    newReg.Name = model.Name;
                    newReg.Description = model.Description;
                    if (model.imgPost != null)
                    {
                        newReg.ThumbExtension = Path.GetExtension(model.imgPost.FileName).Replace(".", "");
                    }

                    if (model.contPost != null)
                    {
                        newReg.Extension = Path.GetExtension(model.contPost.FileName).Replace(".", "");
                    }

                    if (!exist)
                    {
                        db.Contents.Add(newReg);
                    }
                    db.SaveChanges();

                    if (model.imgPost != null)
                    {
                        string ruta = System.Web.HttpContext.Current.Server.MapPath("/Assets/Contents/Thumbs/");
                        if (!Directory.Exists(ruta))
                            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/Assets/Contents/Thumbs/"));

                        string extension = Path.GetExtension(model.imgPost.FileName);
                        var fileName = string.Format("{0}_{1}{2}", newReg.Id.ToString(), Encrypt(newReg.Id.ToString()), extension);
                        model.imgPost.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Assets/Contents/Thumbs/") + fileName);
                        //Nota.Image_Abstract = String.Format("/images/abstract/{0}{1}", Nota.ID.ToString(), extension);
                    }

                    if (model.contPost != null)
                    {
                        string ruta = System.Web.HttpContext.Current.Server.MapPath("/Assets/Contents/Contents/");
                        if (!Directory.Exists(ruta))
                            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/Assets/Contents/Contents/"));

                        string extension = Path.GetExtension(model.contPost.FileName);
                        var fileName = string.Format("{0}_{1}{2}", newReg.Id.ToString(), Encrypt(newReg.Id.ToString()), extension);
                        model.imgPost.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Assets/Contents/Contents/") + fileName);
                        //Nota.Image_Abstract = String.Format("/images/abstract/{0}{1}", Nota.ID.ToString(), extension);
                    }

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
                    var search = (from x in db.Contents where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        db.Contents.Remove(search);
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
