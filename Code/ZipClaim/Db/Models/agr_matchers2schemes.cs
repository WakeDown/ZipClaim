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
    
    public partial class agr_matchers2schemes
    {
        public int id_matchers2schemes { get; set; }
        public int id_agr_matcher { get; set; }
        public int id_agr_scheme { get; set; }
        public int order_num { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public Nullable<int> id_creator { get; set; }
    
        public virtual agr_matchers agr_matchers { get; set; }
        public virtual agr_schemes agr_schemes { get; set; }
    }
}