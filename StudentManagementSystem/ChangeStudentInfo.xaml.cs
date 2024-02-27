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
    /// Interaction logic for ChangeStudentInfo.xaml
    /// </summary>
    public partial class ChangeStudentInfo : Window
    {
        StudentUser studentUser;
        public ChangeStudentInfo(StudentUser studentUser)
        {
            InitializeComponent();
            this.studentUser = studentUser;

            photo.Text = studentUser.Photo;
            firstName.Text = studentUser.FirstName;
            lastName.Text = studentUser.LastName;
            gpa.Text = studentUser.GPA;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<StudentUser>(); //creates the table. if the table already exits it ignores.
                connection.Delete(studentUser);
                Close();
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            studentUser.Photo = photo.Text;
            studentUser.FirstName = firstName.Text;
            studentUser.LastName = lastName.Text;
            studentUser.GPA = gpa.Text;
            

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<StudentUser>(); //creates the table. if the table already exits it ignores.
                connection.Update(studentUser);
                Close();
            }
        }

       

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
