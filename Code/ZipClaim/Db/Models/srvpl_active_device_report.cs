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
    
    public partial class srvpl_active_device_report
    {
        public string Модель { get; set; }
        public string Классификатор { get; set; }
        public Nullable<int> Сложность { get; set; }
        public string S_N_ { get; set; }
        public string Переодичность_обслуживания { get; set; }
        public string C__Договора { get; set; }
        public string Заказчик { get; set; }
        public string Город { get; set; }
        public string Адрес { get; set; }
        public string Объект { get; set; }
        public Nullable<int> Счетчик_общий { get; set; }
        public Nullable<int> Счетчик_ЧБ { get; set; }
        public Nullable<int> Счетчик_ЦВ { get; set; }
        public string Сервисный_администратор { get; set; }
    }
}
