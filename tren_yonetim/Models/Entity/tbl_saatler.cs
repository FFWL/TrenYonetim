//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tren_yonetim.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_saatler
    {
        public int saatid { get; set; }
        public string saat { get; set; }
        public Nullable<int> trenid { get; set; }
    
        public virtual tbl_tren tbl_tren { get; set; }
    }
}
