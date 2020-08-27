using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryListImplement.Models
{
    public class CannedComponent
    {
        public int Id { get; set; }
        public int CannedId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}