using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Models.ViewModels
{
    public class vmResult
    {
        public int ErrorCount { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public long Id { get; set; }
    }
}
