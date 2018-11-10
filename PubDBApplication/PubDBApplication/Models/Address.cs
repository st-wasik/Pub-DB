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
    using System.ComponentModel.DataAnnotations;

    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.Producers = new HashSet<Producers>();
            this.Pubs = new HashSet<Pubs>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Building number cannot be zero or negative")]
        public int building_no { get; set; }

        [Required(ErrorMessage = "Required")]
        public string street { get; set; }

        [Required(ErrorMessage = "Required")]
        public string city { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[1-9][0-9]\-[0-9]{3}$",
        ErrorMessage = "Provide correct postal code (e.g. 45-654)")]
        public string postal_code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producers> Producers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pubs> Pubs { get; set; }
    }
}
