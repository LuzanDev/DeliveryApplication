using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    internal class Client : ICloneable
    {
        public int ID { get; set; }
        public string NumberPhone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public int LastNumberStock { get; set; }

        public object Clone()
        {
            return new Client
            {
                ID = ID,
                NumberPhone = NumberPhone,
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                Company = Company,
                City= City,
                LastNumberStock= LastNumberStock
            };
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic} ->{Company}";
        }
    }
}
