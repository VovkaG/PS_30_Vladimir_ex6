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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for UniTask.xaml
    /// </summary>
    public partial class UniTask : Window
    {
        public UniTask()
        {
            InitializeComponent();

        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();

        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            UniLoginWin loginWindow = new UniLoginWin();
            loginWindow.Show();
            this.Close();
        }
    }
}
