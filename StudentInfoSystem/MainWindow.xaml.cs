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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{

    public partial class MainWindow : Window
    {
        Student studenta = StudentData.TestStudents[0];

        public List<string> StudStatusChoices { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                  FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }

        }


        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this;
        }

        public MainWindow(Student student) : this()
        {
            displayData(student);
        }

        private void fillFieldWithData(Student students)
        {
            foreach (var item in prsDataGrid.Children)
            {

                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    switch (textBox.Name)
                    {
                        case "txtFName":
                            {

                                textBox.Text = students.firstName;
                                break;
                            }
                        case "txtMName":
                            {
                                textBox.Text = students.middleName;
                                break;
                            }
                        case "txtLName":
                            {
                                textBox.Text = students.lastName;
                                break;
                            }
                    }
                }
            }

            foreach (var item in stdInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    switch (textBox.Name)
                    {
                        case "txtFac":
                            {
                                textBox.Text = students.facultyNumber;
                                break;
                            }
                        case "txtSpec":
                            {
                                textBox.Text = students.speciality;
                                break;
                            }
                        case "txtOks":
                            {
                                textBox.Text = students.degree;
                                break;
                            }
                        case "txtStat":
                            {
                                textBox.Text = students.status;
                                break;
                            }
                        case "txtFNum":
                            {
                                textBox.Text = students.facultyNumber;
                                break;
                            }
                        case "txtCourse":
                            {
                                textBox.Text = students.course.ToString();
                                break;
                            }
                        case "txtStream":
                            {
                                textBox.Text = students.stream.ToString();
                                break;
                            }
                        case "txtGroup":
                            {
                                textBox.Text = students.group.ToString();
                                break;
                            }
                    }
                }
            }

        }
        private void clearAllTxtBoxes()
        {
            foreach (var item in prsDataGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    textBox.Text = "";
                }
            }
            foreach (var item in stdInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    textBox.Text = "";
                }
            }
        }

        private void enableOrDisableGridCtrls(bool isEnabled)
        {
            foreach (var item in prsDataGrid.Children)
            {
                UIElement element = item as UIElement;
                element.IsEnabled = isEnabled;
                if (element is Button)
                {
                    btnEnable.IsEnabled = true;
                }
            }
            foreach (var item in stdInfoGrid.Children)
            {
                UIElement element = item as UIElement;
                element.IsEnabled = isEnabled;
                if (element is Button)
                {
                    btnEnable.IsEnabled = true;
                }
            }
        }

        private void btnNames_Click(object sender, RoutedEventArgs e)
        {
            fillFieldWithData(studenta);
        }

        private void btnStudInfo_Click(object sender, RoutedEventArgs e)
        {
            fillFieldWithData(studenta);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearAllTxtBoxes();
        }

        private void btnEnable_Click(object sender, RoutedEventArgs e)
        {
            enableOrDisableGridCtrls(true);
        }

        private void btnDisable_Click(object sender, RoutedEventArgs e)
        {
            enableOrDisableGridCtrls(false);
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in prsDataGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    textBox.Visibility = Visibility.Visible;

                }
                if (item is Label)
                {
                    var lab = (Label)item;
                    lab.Visibility = Visibility.Visible;
                }
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visibility = Visibility.Visible;
                }
            }
            foreach (var item in stdInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    textBox.Visibility = Visibility.Visible;

                }
                if (item is Label)
                {
                    var lab = (Label)item;
                    lab.Visibility = Visibility.Visible;
                }
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visibility = Visibility.Visible;
                }
            }
            
            fillFieldWithData(studenta);
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in prsDataGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    textBox.Visibility = Visibility.Hidden;

                }
                if (item is Label)
                {
                    var lab = (Label)item;
                    lab.Visibility = Visibility.Hidden;
                }
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visibility = Visibility.Hidden;
                }

            }

            foreach (var item in stdInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    var textBox = (TextBox)item;
                    textBox.Visibility = Visibility.Hidden;

                }
                if (item is Label)
                {
                    var lab = (Label)item;
                    lab.Visibility = Visibility.Hidden;
                }
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visibility = Visibility.Hidden;
                }

            }
        }

        public void displayData(Student student)
        {
            txtFName.Text = student.firstName;
            txtMName.Text = student.middleName;
            txtLName.Text = student.lastName;
            txtFac.Text = student.faculty;
            txtFNum.Text = student.facultyNumber;
            txtOks.Text = student.degree;
            txtSpec.Text = student.speciality;
            txtStream.Text = student.stream.ToString();
            txtCourse.Text = student.course.ToString();
            txtGroup.Text = student.group.ToString();

            foreach (var item in prsDataGrid.Children)
            {
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visibility = Visibility.Hidden;
                }
            }

            foreach (var item in stdInfoGrid.Children)
            {
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visibility = Visibility.Hidden;
                }
            }
        }

        public Boolean testStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
            {
                MessageBox.Show(" TRUE !");
                return true;
            }
            else
            {
                MessageBox.Show(" FALSE !");

                return false;
            }

        }

        public Boolean testUsersIfEmpty()
        {
            UserContext context = new UserLogin.UserContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            if (countUsers == 0)
            {
                MessageBox.Show(" TRUE !");
                return true;
            }
            else
            {
                MessageBox.Show(" FALSE !");

                return false;
            }

        }


        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            testStudentsIfEmpty();
        }

        public void copyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
            if (testStudentsIfEmpty())
                copyTestStudents();


        }

        public void copyTestUsers()
        {
            UserContext context = new UserLogin.UserContext();

            foreach (User u in UserLogin.UserData.TestUsers)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
            if (testUsersIfEmpty())
                copyTestUsers();


        }

        private void btnTestt_Click(object sender, RoutedEventArgs e)
        {
            testUsersIfEmpty();
        }
    }
}
