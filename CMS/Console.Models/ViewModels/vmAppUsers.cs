using System;
using System.Collections.Generic;

namespace ConsoleCMS.Models.ViewModels
{
    public class vmAppUsers
    {
        public List<POCOs.AppusersModel> AllAppUsers { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
    }
}
