using SQLite;
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
    /// Interaction logic for StudentChangeLogInInfoWindow.xaml
    /// </summary>
    public partial class StudentChangeLogInInfoWindow : Window
    {
        StudentUser studentUser;
        public StudentChangeLogInInfoWindow(StudentUser studentUser)
        {
            InitializeComponent();
            this.studentUser = studentUser;
            //MessageBox.Show("You are going to change your log in info", "Row Clicked", MessageBoxButton.OK, MessageBoxImage.Information);

            newUserName.Text = studentUser.StudentUserName;
            newPassword.Text = studentUser.StudentPassword;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            studentUser.StudentUserName = newUserName.Text;
            studentUser.StudentPassword = newPassword.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<StudentUser>(); //creates the table. if the table already exits it ignores.
                connection.Update(studentUser);
                Close();
            }
        }
    }
}
