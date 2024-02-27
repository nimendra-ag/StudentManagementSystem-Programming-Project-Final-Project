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

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void StudentInfoButton_Click(object sender, RoutedEventArgs e)
        {
            StudentInformationWindow studentInformationWindow = new StudentInformationWindow();
            studentInformationWindow.ShowDialog();  
        }

        private void addAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdminUser addAdminUser = new AddAdminUser();
            addAdminUser.ShowDialog();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }

        private void addDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayDepartmentInfoWindow displayDepartmentInfoWindow = new DisplayDepartmentInfoWindow();
            displayDepartmentInfoWindow.ShowDialog();
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayAcadStaffWindow displayAcadStaffWindow = new DisplayAcadStaffWindow();
            displayAcadStaffWindow.ShowDialog();
        }
    }
}
