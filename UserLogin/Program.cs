using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            string username, password;

            User user1 = new User();
            Console.WriteLine("Enter a username:");
            username = Console.ReadLine();
            Console.WriteLine("Enter a password:");
            password = Console.ReadLine();
            LoginValidation logVal = new LoginValidation(username, password, errorFunc);

            UserData.ResetTestUserData();

            if (logVal.validateUserInput(ref user1))
            {

                Console.WriteLine("\nUsername:" + user1.username);
                Console.WriteLine("Password:" + user1.password);
                Console.WriteLine("Faculty number:" + user1.facultyNumber);
                Console.WriteLine("Date Created:" + user1.created);
                Console.WriteLine("Date Valid Until:" + user1.validUntil);
            }


            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ANONYMOUS:
                    {
                        Console.WriteLine("Current user has no role or is not logged in.");
                        break;
                    }
                case UserRoles.ADMIN:
                    {
                        Console.WriteLine("Current user is admin.");
                        adminMenu();
                        break;
                    }
                case UserRoles.INSPECTOR:
                    {
                        Console.WriteLine("Current user is inspector.");
                        break;
                    }
                case UserRoles.PROFESSOR:
                    {
                        Console.WriteLine("Current user is professor.");
                        break;
                    }
                case UserRoles.STUDENT:
                    {
                        Console.WriteLine("Current user is student.");
                        break;
                    }
            }
        }

        static void errorFunc(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        static void adminMenu()
        {
            Console.WriteLine("\nChoose option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change user's role");
            Console.WriteLine("2: Change user's expire validation");
            Console.WriteLine("3: Print all users");
            Console.WriteLine("4: Logging activity preview");
            Console.WriteLine("5: Current logging activity preview");



            int choice = new int();

            while (choice != null)
            {
                choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine("Exiting.");
                    break;
                }
                else if (choice == 1)
                {
                    Console.WriteLine("Changing user's role: ");
                    changeRole();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Changing user's expire validation: ");
                    changeDate();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("All users: ");
                    printUser();

                }
                else if (choice == 4)
                {
                    IEnumerable<string> fileLines = Logger.GetFileContent();
                    fileLines = File.ReadLines("test.txt");

                    foreach (string line in fileLines)
                    {
                        Console.WriteLine(line);
                    }

                }
                else if (choice == 5)
                {
                    Console.WriteLine("Please, choose filter :");
                    string filter = Console.ReadLine();
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivity(filter);
                    foreach (string line in currentActs)
                    {
                        sb.Append(line);
                    }
                    Console.WriteLine("\n" + sb.ToString());

                }
                else { Console.WriteLine("Inavlid choice !"); }

            }
            return;
        }

        static void changeRole()
        {
            string username;
            UserRoles newRole;
            Console.Write("\nEnter username of the user: ");
            username = Console.ReadLine();
            Console.Write("Enter the new role of the user (as an integer): ");
            newRole = (UserRoles)int.Parse(Console.ReadLine());
            UserData.AssignUserRole(username, (UserRoles)newRole);
        }

        static void changeDate()
        {
            string username;
            string newValidationDate;
            Console.Write("\nEnter username of the user: ");
            username = Console.ReadLine();
            Console.Write("Enter the new expiration date of the user: ");
            newValidationDate = Console.ReadLine();
            UserData.SetUserActiveTo(username, Convert.ToDateTime(newValidationDate));
        }

       

        static void printUser()
        {
            
            foreach (var user1 in UserLogin.UserData.TestUsers)
            {
                Console.WriteLine("\nUsername:" + user1.username);
                Console.WriteLine("Password:" + user1.password);
                Console.WriteLine("Faculty number:" + user1.facultyNumber);
                Console.WriteLine("User role:" + user1.role);
                Console.WriteLine("Date Created:" + user1.created);
                Console.WriteLine("Date Valid Until:" + user1.validUntil);
            }
        }

    }


}

