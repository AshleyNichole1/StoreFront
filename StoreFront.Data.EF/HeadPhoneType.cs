//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreFront.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class HeadPhoneType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HeadPhoneType()
        {
            this.HeadPhoneStores = new HashSet<HeadPhoneStore>();
        }
    
        public int HeadPhoneType1 { get; set; }
        public string HPT_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HeadPhoneStore> HeadPhoneStores { get; set; }
    }
}
