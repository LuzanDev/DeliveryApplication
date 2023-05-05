using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    /// <summary>
    /// Картонная коробка
    /// </summary>
    internal class Container : PackagingMaterial
    {
        public float Volume { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
    }
}
