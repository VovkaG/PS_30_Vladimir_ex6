using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem mike = new ListBoxItem();
            mike.Content = "Mike";
            peopleListBox.Items.Add(mike);

            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            peopleListBox.SelectedItem = james;

            ListBoxItem lisa = new ListBoxItem();
            lisa.Content = "Lisa";
            peopleListBox.Items.Add(lisa);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
            }
            if (txtName.Text.Length >= 2)
            {
                MessageBox.Show("Hello," + s + ".This is your first program in VS 2022.");
            }
            else
            {
                MessageBox.Show("Please, enter a valid name with atleast 2 characters.");
            }

        }

        public void Window_Close(object sender, CancelEventArgs e)
        {
            string msg = "Data is dirty. Close without saving?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Data App",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure
                e.Cancel = true;
            }

        }

        private void btnGreetings_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}
