using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        Student GetStudentDataByUser(UserLogin.User user)
        {
            Student student = new Student();   
            if(user.facultyNumber == null || !user.facultyNumber.Equals(user.facultyNumber))
            {
                Console.WriteLine("No such student with this fac number!");
                return null;
            }
                return (from s in StudentData.TestStudents
                        where s.facultyNumber == user.facultyNumber select s).First();
        }

        public User validateLogin(String username, String password)
        {
            
            foreach (var user in UserLogin.UserData.TestUsers)
            {
                if( (!username.Equals(user.username)) || (!password.Equals(user.password) )){
                    Console.WriteLine("No such user or pass!");
                    return null;
                }
                else
                {
                    return user;
                }
            }
            return null;

        }

    }
}
