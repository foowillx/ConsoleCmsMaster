using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCMS.Models.POCOs
{
    [Table("Categories")]
    public class CategoriesModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Color { get; set; }
    }
}
