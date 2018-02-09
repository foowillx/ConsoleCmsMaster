using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCMS.Models.POCOs
{
    [Table("ContactRequests")]
    public class ContactRequestsModel
    {
        public long Id { get; set; }
        public long? StateId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Mail { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int IsInterested { get; set; }
    }
}
