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
    
    public partial class payment
    {
        public int pay_id { get; set; }
        public Nullable<int> book_id { get; set; }
        public Nullable<long> ticket_id { get; set; }
    
        public virtual bookingdetail bookingdetail { get; set; }
        public virtual ticket ticket { get; set; }
    }
}
