using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCMS.Domain.Dominio
{
    public class PostsDomain
    {
        public List<Models.POCOs.PostsModel> GetAll()
        {
            var result = new List<Models.POCOs.PostsModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Posts select x).ToList();
                    foreach (var reg in search)
                    {
                        var newItem = new Util.ConvertEFtoModel().Posts(reg);
                        newItem.Categoria = new Util.ConvertEFtoModel().Categories(reg.Categories);
                        var fileName = string.Format("{0}_{1}.{2}", newItem.Id.ToString(), Encrypt(newItem.Id.ToString()), newItem.Extension);
                        newItem.imgUrl = "/Assets/Posts/Images/"+fileName;
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

        public Models.POCOs.PostsModel GetById(long id)
        {
            var result = new Models.POCOs.PostsModel();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Posts where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        result = new Util.ConvertEFtoModel().Posts(search);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.ViewModels.vmResult AddOrUpdate(Models.POCOs.PostsModel model)
        {
            var result = new Models.ViewModels.vmResult();
            try
            {
                bool exist = false;
                var newReg = new Data.EntityFramework.Posts();
                using (var db = new Data.EntityFramework.Entities())
                {
                    if (db.Posts.Any(x => x.Id == model.Id))
                    {
                        exist = true;
                        newReg = (from x in db.Posts where x.Id == model.Id select x).FirstOrDefault();
                    }

                    newReg.Abstract = model.Abstract;
                    newReg.Title = model.Title;
                    newReg.PublishedAt = DateTime.Now;
                    newReg.Post = model.Post;
                    newReg.Audience = model.Audience.Value;
                    newReg.CategoryId = model.CategoryId.Value;
                    if (model.IsActive != null)
                    {
                        newReg.IsActive = model.IsActive;
                    }
                    else
                    {
                        newReg.IsActive = 0;
                    }
                    
                    if (model.imgPost != null)
                    {
                        newReg.Extension = Path.GetExtension(model.imgPost.FileName).Replace(".","");
                    }

                    if (!exist)
                    {
                        db.Posts.Add(newReg);
                    }
                    db.SaveChanges();

                    if (model.imgPost != null)
                    {
                        string ruta = System.Web.HttpContext.Current.Server.MapPath("/Assets/Posts/Images/");
                        if (!Directory.Exists(ruta))
                            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/Assets/Posts/Images/"));

                        string extension = Path.GetExtension(model.imgPost.FileName);
                        var fileName = string.Format("{0}_{1}{2}", newReg.Id.ToString(), Encrypt(newReg.Id.ToString()), extension);
                        model.imgPost.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Assets/Posts/Images/") + fileName);
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
                    var search = (from x in db.Posts where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        db.Posts.Remove(search);
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
