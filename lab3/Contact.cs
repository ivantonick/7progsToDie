using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iantonov
{
    public class Contact
    {
        [Key]
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set;  }

        public Contact()
        {

        }

        public Contact(string name, string surname, string phoneNumber, string email)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string? ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nPhone: {PhoneNumber}\nE-mail: {Email}"; 
        }
    }
}
