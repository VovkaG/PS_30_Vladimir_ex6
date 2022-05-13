using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers = new List<User>();
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static public User IsUserPassCorrect(string username, string password)
        {
           

            UserContext context = new UserContext();

            IEnumerable<User> users = (from user in context.Users
                                       where user.username.Equals(username) && user.password.Equals(user.password)
                                       select user).ToList();

            return users.FirstOrDefault();

        }

        static public void SetUserActiveTo(string username, DateTime dateValidTo)
        {
            foreach (var user in TestUsers)
            {
                if (username.Equals(user.username))
                {
                    user.validUntil = dateValidTo;
                    Logger.LogActivity("Changed expiration date of " + username);
                }
            }
        }

        static public void AssignUserRole(string username, UserRoles newRole)
        {
            UserContext context = new UserContext();
            User usr =
                (from u in context.Users
                 where u.username == username
                 select u).FirstOrDefault();
            if (usr != null)
            {
                usr.role = newRole;
                context.SaveChanges();
                Console.WriteLine("Role of {0} changed to {1}!\n", username, newRole);
                Logger.LogActivity("Changed role of " + username);
                return;
            }
            Console.WriteLine("No such user found!\n");
           

        }

        static public void ResetTestUserData()
        {
            if (_testUsers.Count == 0)
            {
                _testUsers.Add(new User());
                _testUsers[0].username = "Vladimir";
                _testUsers[0].password = "12345";
                _testUsers[0].facultyNumber = "121219006";
                _testUsers[0].created = DateTime.Now;
                _testUsers[0].validUntil = DateTime.MaxValue;
                _testUsers[0].role = UserRoles.ADMIN;

                _testUsers.Add(new User());
                _testUsers[1] = new User();
                _testUsers[1].username = "Kircho";
                _testUsers[1].password = "Kircho";
                _testUsers[1].facultyNumber = "121219006";
                _testUsers[1].created = DateTime.Now;
                _testUsers[1].validUntil = DateTime.MaxValue;
                _testUsers[1].role = UserRoles.STUDENT;

                _testUsers.Add(new User());
                _testUsers[2] = new User();
                _testUsers[2].username = "Boiko";
                _testUsers[2].password = "Boiko";
                _testUsers[2].facultyNumber = "121219007";
                _testUsers[2].created = DateTime.Now;
                _testUsers[2].validUntil = DateTime.MaxValue;
                _testUsers[2].role = UserRoles.STUDENT;
            }






        }
    }
}
