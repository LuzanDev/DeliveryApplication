using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    internal class Client 
    {
        public int ID { get; set; }
        public string NumberPhone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<Company> Companies { get; set; }
        public string City { get; set; }
        public string LastNumberStock { get; set; }

        public Client()
        {
            Companies = new List<Company>();
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}
