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
    [Table("Posts")]
    public class PostsModel
    {
        public long Id { get; set; }
        public int? Audience { get; set; }
        public long? CategoryId { get; set; }
        public int IsActive { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Post { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Extension { get; set; }
        public int Published { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public string imgUrl { get; set; }
        public HttpPostedFileBase imgPost { get; set; }
        public Models.POCOs.CategoriesModel Categoria { get; set; }
        public string AudienceName { get; set; }
    }
}
