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
    
    public partial class devinst_state_notify_recipients
    {
        public int id_state_notify_recipient { get; set; }
        public int id_state_notify { get; set; }
        public string sys_name { get; set; }
        public Nullable<int> id_user_group { get; set; }
        public bool enabled { get; set; }
        public int order_num { get; set; }
    }
}