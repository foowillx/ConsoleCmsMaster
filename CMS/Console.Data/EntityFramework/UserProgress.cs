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
    
    public partial class UserProgress
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Step { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}
