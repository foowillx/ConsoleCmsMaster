using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Domain.Util
{
    public class ConvertEFtoModel
    {
        public Models.POCOs.AppusersModel Appuser(Data.EntityFramework.AppUsers ef)
        {
            var res = new ConsoleCMS.Models.POCOs.AppusersModel();
            res.Id = ef.Id;
            res.StateId = ef.StateId;
            res.FbId = ef.FbId;
            res.Audience = ef.Audience;
            res.IsInterested = ef.IsInterested;
            res.UserName = ef.UserName;
            res.Name = ef.Name;
            res.LastNames = ef.LastNames;
            res.Mail = ef.Mail;
            res.Password = ef.Password;
            res.Extension = ef.Extension;
            res.ChildrenCount = ef.ChildrenCount;
            res.ChildrenCount05x = ef.ChildrenCount05x;
            res.ChildrenCount68x = ef.ChildrenCount68x;
            res.ChildrenCount912x = ef.ChildrenCount912x;
            res.ChildrenCount12xx = ef.ChildrenCount12xx;
            res.LocationCount = ef.LocationCount;
            res.LockedAt = ef.LockedAt;
            res.EsTitular = ef.EsTitular != null ? Convert.ToInt32(ef.EsTitular.Value) : 0;
            res.IsBlocked = ef.IsBlocked;
            res.FechaRegistro = ef.FechaRegistro;
            return res;
        }

        public Models.POCOs.CategoriesModel Categories(Data.EntityFramework.Categories ef)
        {
            var res = new Models.POCOs.CategoriesModel();
            res.Id = ef.Id;
            res.Name = ef.Name;
            res.Color = ef.Color;
            return res;
        }

        public Models.POCOs.ChangeLogModel ChangeLog(Data.EntityFramework.ChangeLog ef)
        {
            var res = new Models.POCOs.ChangeLogModel();
            res.Id = ef.Id;
            res.AppUserId = ef.AppUserId != null ? ef.AppUserId.Value : 0;
            res.DateAction = ef.DateAction != null ? ef.DateAction.Value : DateTime.MinValue;
            res.Description = ef.Description;
            return res;
        }

        public Models.POCOs.ContactRequestsModel ContactRequests(Data.EntityFramework.ContactRequests ef)
        {
            var res = new Models.POCOs.ContactRequestsModel();
            res.Id = ef.Id;
            res.StateId = ef.StateId;
            res.Name = ef.Name;
            res.MiddleName = ef.MiddleName;
            res.LastName = ef.LastName;
            res.Profession = ef.Profession;
            res.Mail = ef.Mail;
            res.Comment = ef.Comment;
            res.CreatedAt = ef.CreatedAt;
            res.IsInterested = ef.IsInterested;
            return res;
        }

        public Models.POCOs.ContentsModel Contents(Data.EntityFramework.Contents ef)
        {
            var res = new Models.POCOs.ContentsModel();
            res.Id = ef.Id;
            res.SigninRequired = ef.SigninRequired != null ? ef.SigninRequired.Value : 0;
            res.Audience = ef.Audience;
            res.CategoryId = ef.CategoryId;
            res.Name = ef.Name;
            res.Description = ef.Description;
            res.Extension = ef.Extension;
            res.ThumbExtension = ef.ThumbExtension;
            res.Published = Convert.ToInt32(ef.Published.Value);
            res.PublishedAt = ef.PublishedAt;
            return res;
        }

        public Models.POCOs.PostsModel Posts(Data.EntityFramework.Posts ef)
        {
            var res = new Models.POCOs.PostsModel();
            res.Id = ef.Id;
            res.Audience = ef.Audience;
            res.CategoryId = ef.CategoryId;
            res.IsActive = ef.IsActive;
            res.Title = ef.Title;
            res.Abstract = ef.Abstract;
            res.Post = ef.Post;
            res.PublishedAt = ef.PublishedAt;
            res.Extension = ef.Extension;
            res.Published = Convert.ToInt32(ef.Published);
            return res;
        }

        public Models.POCOs.StatesModel States(Data.EntityFramework.States ef)
        {
            var res = new Models.POCOs.StatesModel();
            res.Id = ef.Id;
            res.Name = ef.Name;
            return res;
        }

        public Models.POCOs.UsersModel Users(Data.EntityFramework.Users ef)
        {
            var res = new Models.POCOs.UsersModel();
            res.Id = ef.Id;
            res.Name = ef.Name;
            res.LastNames = ef.LastNames;
            res.Mail = ef.Mail;
            res.Password = ef.Password;
            res.LastLogin = ef.LastLogin;
            res.Type = ef.Type;
            res.LockedAt = ef.LockedAt;
            res.LastChangePassword = ef.LastChangePassword;
            res.LinkDate = ef.LinkDate;
            res.Token = ef.Token;
            return res;
        }
    }
}
