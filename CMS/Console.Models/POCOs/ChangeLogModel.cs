using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCMS.Models.POCOs
{
    [Table("ChangeLog")]
    public class ChangeLogModel
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public DateTime DateAction { get; set; }
        public string Description { get; set; }
    }
}
