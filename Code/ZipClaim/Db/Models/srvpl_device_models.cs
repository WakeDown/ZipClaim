//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZipClaim.Db.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class srvpl_device_models
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public srvpl_device_models()
        {
            this.srvpl_devices = new HashSet<srvpl_devices>();
        }
    
        public int id_device_model { get; set; }
        public int id_device_type { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public Nullable<decimal> speed { get; set; }
        public Nullable<int> id_device_imprint { get; set; }
        public Nullable<int> id_print_type { get; set; }
        public Nullable<int> id_cartridge_type { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public string vendor { get; set; }
        public Nullable<int> max_volume { get; set; }
        public Nullable<int> id_classifier_category { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<srvpl_devices> srvpl_devices { get; set; }
    }
}