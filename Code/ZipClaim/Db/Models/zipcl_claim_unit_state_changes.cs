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
    
    public partial class zipcl_claim_unit_state_changes
    {
        public int id_claim_unit_state_changes { get; set; }
        public int id_claim_unit { get; set; }
        public Nullable<int> id_creator { get; set; }
        public int id_claim_state { get; set; }
        public System.DateTime dattim1 { get; set; }
        public Nullable<int> id_claim_state_from { get; set; }
        public Nullable<int> id_claim_state_to { get; set; }
    }
}