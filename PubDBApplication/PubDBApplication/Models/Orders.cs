//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PubDBApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }
    
        public int id { get; set; }
        public int warehouse_id { get; set; }
        public Nullable<int> pub_id { get; set; }
        public Nullable<int> producer_id { get; set; }
        public string Incoming_Outcoming { get; set; }
        public string status { get; set; }
        public System.DateTime date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Producers Producers { get; set; }
        public virtual Pubs Pubs { get; set; }
        public virtual Warehouses Warehouses { get; set; }
    }
}
