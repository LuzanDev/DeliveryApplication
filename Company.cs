﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
