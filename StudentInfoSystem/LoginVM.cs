using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem
{
    internal class LoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Action closeAction { get; set; }

        public ICommand enterBtnLoginCommand
        {
            get { return new LoginCommand(LoginAction); }
        }

        private void LoginAction()
        {
           

            StudentValidation val = new StudentValidation();

            User user = UserData.IsUserPassCorrect(Username, Password);
            if (user.role == UserRoles.STUDENT)
            {
                foreach (var std in StudentData.TestStudents)
                {
                    if (std.facultyNumber.Equals(user.facultyNumber))
                    {
                        MainWindow mainWindow = new MainWindow(std);
                        mainWindow.Show();
                        closeAction();
                    }
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Ivalid input or user not a student!");
            }
        }
    }
}
