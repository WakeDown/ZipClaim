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
    
    public partial class srvpl_get_service_claims_Result
    {
        public int id_service_claim { get; set; }
        public int id_contract { get; set; }
        public int id_device { get; set; }
        public Nullable<int> id_service_admin { get; set; }
        public Nullable<System.DateTime> planing_date { get; set; }
        public Nullable<int> id_service_type { get; set; }
        public string number { get; set; }
        public Nullable<int> id_service_engeneer { get; set; }
        public string descr { get; set; }
        public int id_service_claim_status { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public int id_creator { get; set; }
        public int order_num { get; set; }
        public int id_contract2devices { get; set; }
        public Nullable<int> id_service_claim_type { get; set; }
    }
}