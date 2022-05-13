using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for UniLoginWin.xaml
    /// </summary>
    public partial class UniLoginWin : Window
    {
        public UniLoginWin()
        {
            
            InitializeComponent();
            LoginVM lvm = new LoginVM();
            this.DataContext = lvm;
            if(lvm.closeAction == null)
            {
                lvm.closeAction = new Action(this.Close);
            }
            //DataContext = new LoginVM();
        }

        /*
        private void btnEntry_Click(object sender, RoutedEventArgs e) {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            StudentValidation val = new StudentValidation();

            User user = UserData.IsUserPassCorrect(username, password);
            if (user.role == UserRoles.STUDENT)
            {
                foreach (var std in StudentData.TestStudents)
                {
                    if (std.facultyNumber.Equals(user.facultyNumber))
                    {
                        MainWindow mainWindow = new MainWindow(std);
                        mainWindow.Show();
                    }
                }

            }
            else
            {
                MessageBox.Show("Ivalid input or user not a student!");
            }

        } */
    }
    
}
