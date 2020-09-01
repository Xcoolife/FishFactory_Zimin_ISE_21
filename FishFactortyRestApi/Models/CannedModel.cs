using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFactoryRestApi.Models
{
    public class CannedModel
    {
        public int Id { get; set; }
        public string CannedName { get; set; }
        public decimal Price { get; set; }
    }
}