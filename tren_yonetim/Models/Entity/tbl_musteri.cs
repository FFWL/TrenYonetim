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
    
    public partial class tbl_musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_musteri()
        {
            this.tbl_rezervasyon = new HashSet<tbl_rezervasyon>();
        }
    
        public int musteriid { get; set; }
        public string yolcuad { get; set; }
        public string dob { get; set; }
        public string mail { get; set; }
        public Nullable<int> vagonid { get; set; }
        public string sifre { get; set; }
    
        public virtual tbl_vagon tbl_vagon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_rezervasyon> tbl_rezervasyon { get; set; }
    }
}
