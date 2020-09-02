using FishFactoryBusinessLogic.Attributes;
using FishFactoryBusinessLogic.Enums;
using System;
using System.ComponentModel;
using FishFactoryBusinessLogic.Enums;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.ViewModels
{
    [DataContract]
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel : BaseViewModel
    {
        
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int CannedId { get; set; }
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Консервы", width: 100)]
        [DataMember]
        public string CannedName { get; set; }
        [Column(title: "Исполнитель", width: 100)]
        [DataMember]
        public string ImplementerFIO { get; set; }
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 50)]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 100)]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ClientFIO",
            "CannedName",
            "ImplementerFIO",
            "Count",
            "Sum",
            "Status",
            "DateCreate",
            "DateImplement"
        };
    }
}