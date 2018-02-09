using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Domain.Dominio
{
    public class UserDomain
    {
        public List<Models.POCOs.UsersModel> GetAll()
        {
            var result = new List<Models.POCOs.UsersModel>();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Users select x).ToList();
                    foreach (var reg in search)
                    {
                        result.Add(new Util.ConvertEFtoModel().Users(reg));
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.POCOs.UsersModel GetById(long id)
        {
            var result = new Models.POCOs.UsersModel();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Users where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        result = new Util.ConvertEFtoModel().Users(search);
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.ViewModels.vmResult AddOrUpdate(Models.POCOs.UsersModel user)
        {
            var result = new Models.ViewModels.vmResult();
            try
            {
                bool exist = false;
                Data.EntityFramework.Users UserResult = new Data.EntityFramework.Users();
                using (var db = new Data.EntityFramework.Entities())
                {
                    if (db.Users.Any(x => x.Id == user.Id))
                    {
                        exist = true;
                        UserResult = (from x in db.Users where x.Id == user.Id select x).FirstOrDefault();
                    }

                    UserResult.Name = user.Name;
                    UserResult.LastNames = user.LastNames;
                    UserResult.Mail = user.Mail;
                    UserResult.Type = user.Type;

                    if (!exist)
                    {
                        UserResult.Password = Models.POCOs.UsersModel.Encrypt(user.Password);
                        db.Users.Add(UserResult);
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
                    var search = (from x in db.Users where x.Id == id select x).FirstOrDefault();
                    if (search != null)
                    {
                        db.Users.Remove(search);
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

        public Models.POCOs.UsersModel Authenticate(string user, string pass)
        {
            var result = new Models.POCOs.UsersModel();
            var encryptedpass = Models.POCOs.UsersModel.Encrypt(pass);
            var now = DateTime.Now;
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Users where x.Mail == user && x.Password == encryptedpass && (x.LockedAt == null || x.LockedAt < now) && x.LastChangePassword > now select x).FirstOrDefault();
                    if (search != null)
                    {
                        result = new Util.ConvertEFtoModel().Users(search);
                        result.Password = null;
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public static void UpdateLastLogin(Models.POCOs.UsersModel model)
        {
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var user = (from x in db.Users where x.Id == model.Id select x).FirstOrDefault();
                    if (user != null)
                    {
                        user.LastLogin = DateTime.Now;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
        }

        public Models.ViewModels.vmResult SetRecoverTokenByMail(string mail)
        {
            var result = new Models.ViewModels.vmResult();
            result.Status = false;
            result.Message = string.Empty;
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var search = (from x in db.Users where x.Mail == mail select x).FirstOrDefault();
                    if (search != null)
                    {
                        search.Token = Guid.NewGuid().ToString();
                        search.LinkDate = DateTime.Now.AddDays(2);
                        db.SaveChanges();
                        result.Message = search.Token;
                        result.Status = true;
                        result.Id = search.Id;
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
            }
            return result;
        }

        public Models.ViewModels.vmResult ChangePassword(string oldpss, string pss, string confirmpss, string usermail)
        {
            var result = new Models.ViewModels.vmResult();
            try
            {
                using (var db = new Data.EntityFramework.Entities())
                {
                    var user = (from x in db.Users where x.Mail == usermail select x).FirstOrDefault();
                    if (user != null)
                    {
                        var encrypted = Models.POCOs.UsersModel.Encrypt(oldpss);
                        if (user.Password == encrypted)
                        {
                            if (pss == confirmpss)
                            {
                                encrypted = Models.POCOs.UsersModel.Encrypt(pss);
                                user.Password = encrypted;
                                user.LastChangePassword = DateTime.Now.AddDays(90);
                                db.SaveChanges();
                                result.Status = true;
                            }
                        }
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
