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
    
    public partial class zipcl_claims_report
    {
        public int ID_Заявки { get; set; }
        public string Дата_Заявки { get; set; }
        public string Модель { get; set; }
        public string Серийный_номер { get; set; }
        public string Контрагент { get; set; }
        public string Город { get; set; }
        public string Состояние_оборудования { get; set; }
        public string Инженер { get; set; }
        public string Сервисный_администратор { get; set; }
        public string Оператор { get; set; }
        public string Менеджер { get; set; }
        public string Текущий_статус_заявки { get; set; }
        public Nullable<int> Количество_ЗИП_в_данной_заявке { get; set; }
        public string Причина_отклонения { get; set; }
        public Nullable<System.DateTime> Передано { get; set; }
        public Nullable<System.DateTime> Назначено { get; set; }
        public Nullable<System.DateTime> Запрошены_цены { get; set; }
        public Nullable<System.DateTime> Проставлены_цены { get; set; }
        public Nullable<System.DateTime> Не_согласованы_цены { get; set; }
        public Nullable<System.DateTime> Согласованы_цены { get; set; }
        public Nullable<System.DateTime> Оформлено { get; set; }
        public Nullable<System.DateTime> Указан_номер_требования { get; set; }
        public Nullable<System.DateTime> Заказано { get; set; }
        public Nullable<System.DateTime> Готово_к_отгрузке { get; set; }
        public Nullable<System.DateTime> Отгружено { get; set; }
        public Nullable<System.DateTime> Завершена { get; set; }
        public string Номер_требования { get; set; }
    }
}
