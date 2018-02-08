using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Models.POCOs
{
     public class Sumary
    {
       public int Id { get; set; }
       public string Value { get; set; }
       public double Item { get; set; }
       public string Lat { get; set; }
       public string Lon { get; set; }
       public int IsActive { get; set; }
    }
}
