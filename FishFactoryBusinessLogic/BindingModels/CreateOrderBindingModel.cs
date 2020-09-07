using System;
using System.Runtime.Serialization;

namespace FishFactoryBusinessLogic.BindingModels
{
    [DataContract]
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int CannedId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}