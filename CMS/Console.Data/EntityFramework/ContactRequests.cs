//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleCMS.Data.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactRequests
    {
        public long Id { get; set; }
        public long StateId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Mail { get; set; }
        public string Comment { get; set; }
        public int IsInterested { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual States States { get; set; }
    }
}
