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
    
    public partial class Tokens
    {
        public long Id { get; set; }
        public int Flags { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public string Secret { get; set; }
        public System.DateTime ExpiresAt { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
