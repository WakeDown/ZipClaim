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
    
    public partial class srvpl_getPlanExecuteServManagerContractorList_curr_month_cache
    {
        public string contractor { get; set; }
        public int id_contractor { get; set; }
        public int id_manager { get; set; }
        public Nullable<int> plan_cnt { get; set; }
        public Nullable<int> done_cnt { get; set; }
        public Nullable<int> residue { get; set; }
        public Nullable<decimal> done_percent { get; set; }
        public System.DateTime date_cache { get; set; }
    }
}
