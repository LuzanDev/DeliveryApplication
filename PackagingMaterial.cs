﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    /// <summary>
    /// Упаковочный материал
    /// </summary>
    public class PackagingMaterial
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
