using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public Employee(int iD, string login, string name, string surname, string patronymic, string email, string phone)
        {
            ID = iD;
            Login = login;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            Phone = phone;
        }

        public int ID { get; private set; }
        public string Login { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
