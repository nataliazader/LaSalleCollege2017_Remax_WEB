//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppRemax
{
    using System;
    using System.Collections.Generic;
    
    public partial class NumBedrooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NumBedrooms()
        {
            this.Houses = new HashSet<Houses>();
        }
    
        public int refNumBedrooms { get; set; }
        public string Bedrooms { get; set; }
        public double Number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Houses> Houses { get; set; }
    }
}
