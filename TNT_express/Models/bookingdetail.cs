//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TNT_express.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bookingdetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bookingdetail()
        {
            this.cancelations = new HashSet<cancelation>();
            this.payments = new HashSet<payment>();
        }
    
        public int book_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<long> acc_no { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> booked_date { get; set; }
    
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cancelation> cancelations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }
    }
}