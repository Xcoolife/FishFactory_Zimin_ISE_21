using FishFactoryBusinessLogic.Attributes;
using FishFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FishFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Почта", width: 150)]
        public string Email { get; set; }
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ClientFIO",
            "Email"
        };
    }
}