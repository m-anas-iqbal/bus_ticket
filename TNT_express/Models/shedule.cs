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
    
    public partial class shedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public shedule()
        {
            this.tickets = new HashSet<ticket>();
        }
    
        public int shedule_id { get; set; }
        public int bus_id { get; set; }
        public System.DateTime travel_date { get; set; }
        public string departure { get; set; }
        public string destination { get; set; }
        public int duration { get; set; }
        public Nullable<double> Fare { get; set; }
    
        public virtual bus bus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> tickets { get; set; }
    }
}