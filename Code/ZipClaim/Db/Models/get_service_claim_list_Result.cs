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
    
    public partial class get_service_claim_list_Result
    {
        public int id_service_claim { get; set; }
        public int id_contract { get; set; }
        public int id_device { get; set; }
        public string contract_number { get; set; }
        public string model { get; set; }
        public Nullable<System.DateTime> planing_date { get; set; }
        public string descr { get; set; }
        public string creator { get; set; }
        public string claim_status { get; set; }
        public int id_service_claim_status { get; set; }
        public string contractor { get; set; }
        public string service_engeneer { get; set; }
        public string device { get; set; }
        public Nullable<int> id_service_engeneer_plan { get; set; }
        public int id_contract2devices { get; set; }
        public Nullable<int> id_service_came { get; set; }
        public Nullable<System.DateTime> date_came { get; set; }
        public int has_came { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string city_short { get; set; }
        public Nullable<System.DateTime> contract_date_end { get; set; }
        public int show_date_end { get; set; }
        public string serial_num { get; set; }
        public string inv_num { get; set; }
        public string object_name { get; set; }
        public int id_city { get; set; }
        public int id_contractor { get; set; }
        public string engeneer_sid { get; set; }
        public string engeneer_name { get; set; }
        public int seted { get; set; }
        public int planed { get; set; }
    }
}