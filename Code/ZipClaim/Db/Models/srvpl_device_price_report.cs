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
    
    public partial class srvpl_device_price_report
    {
        public string device { get; set; }
        public Nullable<decimal> Итого { get; set; }
        public Nullable<decimal> Тариф_предварительный { get; set; }
        public decimal Коэффициент_скорости { get; set; }
        public decimal Коэффициент_способа_печати { get; set; }
        public decimal Цена_за_скорость { get; set; }
        public decimal Цена_за_формат { get; set; }
        public decimal Цена_за_тип_печати { get; set; }
        public decimal Цена_за_возраст { get; set; }
        public decimal Цена_за_ADF { get; set; }
        public decimal Цена_за_Finisher { get; set; }
        public decimal Цена_за_Tray { get; set; }
    }
}
