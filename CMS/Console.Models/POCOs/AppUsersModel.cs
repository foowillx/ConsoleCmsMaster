using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCMS.Models.POCOs
{
    [Table("AppUsers")]
    public class AppusersModel
    {
        public long Id { get; set; }
        public long StateId { get; set; }
        public string FbId { get; set; }
        public int Audience { get; set; }
        public int IsInterested { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastNames { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Extension { get; set; }
        public int ChildrenCount { get; set; }
        public int? ChildrenCount05x { get; set; }
        public int? ChildrenCount68x { get; set; }
        public int? ChildrenCount912x { get; set; }
        public int? ChildrenCount12xx { get; set; }
        public int LocationCount { get; set; }
        public DateTime? LockedAt { get; set; }
        public int EsTitular { get; set; }
        public int? IsBlocked { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IsAdult { get; set; }
        public int? AcceptedTerms { get; set; }
        public int? AcceptedPrivacy { get; set; }

        public Models.POCOs.StatesModel State { get; set; }
    }
}
