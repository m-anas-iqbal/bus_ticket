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
    
    public partial class ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ticket()
        {
            this.cancelations = new HashSet<cancelation>();
            this.payments = new HashSet<payment>();
        }
    
        public long ticket_Id { get; set; }
        public int schedule_id { get; set; }
        public int user_id { get; set; }
        public int no_seat { get; set; }
        public int fare { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cancelation> cancelations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }
        public virtual shedule shedule { get; set; }
        public virtual user user { get; set; }
    }
}
