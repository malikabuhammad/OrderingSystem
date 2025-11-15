using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Domain.DbModels
{

    public class Customers
    {
        private Customers() { } // EF Core

        public Customers(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        public static Customers CreateFromDb(
        int id, string name, string email, string phone,
        DateTime createdAt, bool isDeleted)
        {
            return new Customers
            {
                Id = id,
                Name = name,
                Email = email,
                Phone = phone,
                CreatedAt = createdAt,
                IsDeleted = isDeleted
            };
        }
        [Key]

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public bool IsDeleted { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? DeletedAt { get; private set; }

      
    }

}
