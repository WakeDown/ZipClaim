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
    
    public partial class srvpl_service_interval_plan_groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public srvpl_service_interval_plan_groups()
        {
            this.srvpl_service_intervals = new HashSet<srvpl_service_intervals>();
        }
    
        public int id_service_interval_plan_group { get; set; }
        public string name { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public int order_num { get; set; }
        public string sys_name { get; set; }
        public string color { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<srvpl_service_intervals> srvpl_service_intervals { get; set; }
    }
}
