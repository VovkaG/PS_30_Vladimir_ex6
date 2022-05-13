using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public System.Int32 UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string facultyNumber { get; set; }
        public DateTime? created { get; set; }
        public DateTime? validUntil { get; set; }
        public UserRoles role { get; set; }


        public User(string username, string password, string facultyNumber, DateTime created,
            DateTime validUntil, UserRoles role)
        {
            this.username = username;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.created = created;
            this.validUntil = validUntil;
            this.role = role;
        }

        public User() { }
    }
}
