using StudentManagementSystem.Classes;
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
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        StudentUser studentUser;
        public StudentDashboard(StudentUser studentUser)
        {
            InitializeComponent();
            this.studentUser = studentUser;
            userName.Text = studentUser.StudentUserName;
            firstName.Text = studentUser.FirstName;
            lastName.Text = studentUser.LastName;
            password.Text = studentUser.StudentPassword;
            department.Text = studentUser.Department;
            gpa.Text = studentUser.GPA;
            fFirstName.Text = studentUser.FirstName;
            fLastName.Text = studentUser.LastName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentChangeLogInInfoWindow studentChangeLogInInfoWindow = new StudentChangeLogInInfoWindow(studentUser);
            studentChangeLogInInfoWindow.ShowDialog();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }
    }
}
