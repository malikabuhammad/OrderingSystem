using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; } = "";
        public string PasswordHash { get; private set; } = "";
        public bool IsActive { get; private set; }
        public List<UserRole> Roles { get; private set; } = new();
        private User() { }

        public static User Create(string username, string passwordHash)
        {
            return new User
            {
                Username = username,
                PasswordHash = passwordHash,
                IsActive = true
            };
        }
        public void AssignRole(int roleId)
        {
            Roles.Add(new UserRole(Id, roleId));
        }
    }

}
