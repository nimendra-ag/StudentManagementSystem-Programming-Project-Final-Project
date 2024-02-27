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
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        private string department;

        public AddStudentWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Mena(object sender, RoutedEventArgs e)
        {
            department = "MENA";
        }

        private void Button_Click_Deie(object sender, RoutedEventArgs e)
        {
            department = "DEIE";
        }

        private void Button_Click_Dce(object sender, RoutedEventArgs e)
        {
            department = "DCE";
        }

        private void Button_Click_Dmme(object sender, RoutedEventArgs e)
        {
            department = "DMME";
        }

        private void Button_Click_Dcee(object sender, RoutedEventArgs e)
        {
            department = "DCEE";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            //save data to database
           

            StudentUser studentUser = new StudentUser()
            {
                StudentUserName = studentUserName.Text,
                StudentPassword = studentPassword.Text,
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Photo= photo.Text,
                BirthDay = (DateTime)datePickerBirthday.SelectedDate,
                RegisteredDate = (DateTime)datePickerRegisteredDate.SelectedDate,
                GPA = gpa.Text,
                Department = department,
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<StudentUser>(); //creates the table. if the table already exits it ignores.
                connection.Insert(studentUser);

            }

            MessageBox.Show($"The Selected Department{department}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
