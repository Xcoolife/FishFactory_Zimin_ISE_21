using System.Collections.Generic;
using System;

namespace FishFactoryBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CannedBindingModel
    {
        public int? Id { get; set; }
        public string CannedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> CannedComponents { get; set; }
    }
}