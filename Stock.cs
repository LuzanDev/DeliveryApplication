using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    internal class Stock
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"Відділення №{Number}: {Address}";
        }
    }
}
