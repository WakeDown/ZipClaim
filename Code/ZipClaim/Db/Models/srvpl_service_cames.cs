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
    
    public partial class srvpl_service_cames
    {
        public int id_service_came { get; set; }
        public int id_service_claim { get; set; }
        public System.DateTime date_came { get; set; }
        public string descr { get; set; }
        public Nullable<int> counter { get; set; }
        public int id_service_engeneer { get; set; }
        public int id_service_action_type { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public int id_creator { get; set; }
        public Nullable<int> counter_colour { get; set; }
        public Nullable<int> id_akt_scan { get; set; }
        public bool no_pay { get; set; }
        public Nullable<bool> process_enabled { get; set; }
        public Nullable<bool> device_enabled { get; set; }
        public Nullable<bool> need_zip { get; set; }
        public Nullable<bool> no_counter { get; set; }
        public Nullable<bool> counter_unavailable { get; set; }
        public string zip_descr { get; set; }
        public string date_work_start { get; set; }
        public string date_work_end { get; set; }
    
        public virtual srvpl_service_action_types srvpl_service_action_types { get; set; }
    }
}
