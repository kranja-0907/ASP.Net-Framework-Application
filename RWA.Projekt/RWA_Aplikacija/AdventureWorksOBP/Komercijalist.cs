//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RWA_Aplikacija.AdventureWorksOBP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Komercijalist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Komercijalist()
        {
            this.Racuns = new HashSet<Racun>();
        }
    
        public int IDKomercijalist { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Nullable<bool> StalniZaposlenik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns { get; set; }
    }
}
