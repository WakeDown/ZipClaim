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
    
    public partial class zipcl_srvpl_contract_spec_prices
    {
        public int id_contract_spec_price { get; set; }
        public int id_srvpl_contract { get; set; }
        public Nullable<int> id_nomenclature { get; set; }
        public string nomenclature_name { get; set; }
        public string catalog_num { get; set; }
        public decimal price { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public Nullable<int> id_creator { get; set; }
    }
}