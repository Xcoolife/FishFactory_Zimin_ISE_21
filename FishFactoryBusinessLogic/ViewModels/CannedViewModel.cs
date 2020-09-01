using FishFactoryBusinessLogic.Attributes;
using FishFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FishFactoryBusinessLogic.ViewModels
{
    [DataContract]
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CannedViewModel : BaseViewModel
    {
        [Column(title: "Название двигателя", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string CannedName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> CannedComponents { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "CannedName",
            "Price"
        };
    }
}