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
    
    public partial class cdet_call_details
    {
        public int id_call_details { get; set; }
        public string CITY_SOURC { get; set; }
        public string IN { get; set; }
        public string AUTH { get; set; }
        public string LOCATION { get; set; }
        public string SVC { get; set; }
        public string TERMINAT { get; set; }
        public string ZONE { get; set; }
        public string COUNTRY { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public string TIME { get; set; }
        public Nullable<System.TimeSpan> DURA { get; set; }
        public Nullable<double> SECONDS { get; set; }
        public Nullable<double> RATE { get; set; }
        public Nullable<double> CHARGE { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.Guid id_load { get; set; }
    }
}
