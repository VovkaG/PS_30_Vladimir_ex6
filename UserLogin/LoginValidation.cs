using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string _username;
        private string _password;
        private string _existingError;
        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserUsername { get; private set; }
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError _onError;

        public LoginValidation(string Username, string Password, ActionOnError onError)
        {
            _username = Username;
            _password = Password;
            _onError = new ActionOnError(onError);
        }

        public Boolean validateUserInput(ref User user1)
        {
            Boolean emptyUserName;
            emptyUserName = _username.Equals(String.Empty);
            if (emptyUserName)
            {
                _existingError = "Username not specified.";
                _onError(_existingError);
                return false;
            }
            Boolean shortUsername;
            shortUsername = _username.Length < 5;
            if (shortUsername)
            {
                _existingError = "Username too short";
                _onError(_existingError);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = _password.Equals(String.Empty);
            if (emptyPassword)
            {
                _existingError = "Password not specified";
                _onError(_existingError);
                return false;
            }
            Boolean shortPassword;
            shortPassword = _password.Length < 5;
            if (shortPassword)
            {
                _existingError = "Password too short";
                _onError(_existingError);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            user1 = UserData.IsUserPassCorrect(_username, _password);
            if (user1 != null)
            {
                currentUserRole = (UserRoles)user1.role;
                currentUserUsername = _username;
                Logger.LogActivity("Successful Login");
                return true;
            }
            else
            {
                _existingError = "Not such user found!";
                _onError(_existingError);
                currentUserUsername = null;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

        }

    }
}
