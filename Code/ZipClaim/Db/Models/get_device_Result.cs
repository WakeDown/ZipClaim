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
    
    public partial class get_device_Result
    {
        public int id { get; set; }
        public string serial_num { get; set; }
        public string model_name { get; set; }
        public string vendor { get; set; }
        public Nullable<int> id_classifier_category { get; set; }
        public Nullable<int> age { get; set; }
    }
}