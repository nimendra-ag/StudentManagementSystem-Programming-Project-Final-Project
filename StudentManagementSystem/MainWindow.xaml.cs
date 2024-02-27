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

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            //AddAdminUser addAdminUser = new AddAdminUser();
            //addAdminUser.ShowDialog();

            AdminLogInWindow adminLogInWindow = new AdminLogInWindow();
            Close();
            adminLogInWindow.ShowDialog();
            
        }

        private void Student_Button_Click(object sender, RoutedEventArgs e)
        {
            StudentLogInWindow studentLogInWindow = new StudentLogInWindow();
            Close();
            studentLogInWindow.ShowDialog();
         
        }
    }
}
