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
    
    public partial class zipcl_claim_units
    {
        public int id_claim_unit { get; set; }
        public int id_claim { get; set; }
        public string catalog_num { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public string nomenclature_num { get; set; }
        public Nullable<decimal> price_in { get; set; }
        public Nullable<decimal> price_out { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public int id_creator { get; set; }
        public string delivery_time { get; set; }
        public Nullable<bool> no_nomenclature_num { get; set; }
        public string nomenclature_claim_num { get; set; }
        public Nullable<bool> price_request { get; set; }
        public Nullable<int> id_supply_man { get; set; }
        public Nullable<int> old_id_claim_unit { get; set; }
        public Nullable<int> id_resp_supply { get; set; }
        public Nullable<bool> is_return { get; set; }
        public Nullable<int> id_zip_item { get; set; }
        public string supply_descr { get; set; }
        public bool erp_handled { get; set; }
        public bool system_handle { get; set; }
    }
}
