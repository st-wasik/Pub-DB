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
    
    public partial class OrderDetailsView
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int quantity { get; set; }
        public string product_name { get; set; }
        public Nullable<decimal> partial_price { get; set; }
    }
}
