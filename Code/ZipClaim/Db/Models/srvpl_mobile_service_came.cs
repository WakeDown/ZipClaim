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
    
    public partial class srvpl_mobile_service_came
    {
        public int id { get; set; }
        public string device_serial_num { get; set; }
        public Nullable<int> id_device { get; set; }
        public string model_name { get; set; }
        public string city_name { get; set; }
        public string address { get; set; }
        public string client_name { get; set; }
        public int id_work_type { get; set; }
        public Nullable<long> counter_mono { get; set; }
        public Nullable<long> counter_color { get; set; }
        public string descr { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string specialist_sid { get; set; }
        public System.DateTime date_create { get; set; }
    }
}