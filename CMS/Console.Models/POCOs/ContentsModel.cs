using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ConsoleCMS.Models.POCOs
{
    [Table("Contents")]
    public class ContentsModel
    {
        public long Id { get; set; }
        public int SigninRequired { get; set; }
        public int? Audience { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string ThumbExtension { get; set; }
        public string SmallThumbExtension { get; set; }
        public DateTime? PublishedAt { get; set; }
        public HttpPostedFileBase ContentUpload { get; set; }
        public HttpPostedFileBase ThumbUpload { get; set; }
        public HttpPostedFileBase SmallThumbUpload { get; set; }
        public int Published { get; set; }

        public string imgUrl { get; set; }
        public HttpPostedFileBase imgPost { get; set; }
        public string contUrl { get; set; }
        public HttpPostedFileBase contPost { get; set; }
        public Models.POCOs.CategoriesModel Categoria { get; set; }
        public string AudienceName { get; set; }
    }
}
