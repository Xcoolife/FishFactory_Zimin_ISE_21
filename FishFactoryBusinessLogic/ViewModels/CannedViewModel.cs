using System.Collections.Generic;
using System.ComponentModel;

namespace FishFactoryBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CannedViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название Консервы")]
        public string CannedName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> CannedComponents { get; set; }
    }
}