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
    
    public partial class agr_doc_type2doc_type_options
    {
        public int id_doc_type2doc_type_options { get; set; }
        public int id_doc_type { get; set; }
        public int id_doc_type_option { get; set; }
        public string name { get; set; }
        public bool enabled { get; set; }
    
        public virtual agr_doc_type_options agr_doc_type_options { get; set; }
        public virtual agr_doc_types agr_doc_types { get; set; }
    }
}
