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
    /// Interaction logic for AddDepartmentWindow.xaml
    /// </summary>
    public partial class AddDepartmentWindow : Window
    {
        public AddDepartmentWindow()
        {
            InitializeComponent();
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            Department department= new Department()
            {
                DepartmentName = departmentName.Text,
                DepartmentHead = departmentHead.Text,
                PhoneNumber = phoneNumber.Text,
                EstablisgedOn = (DateTime)datePickerdepartment.SelectedDate,
                NumberofStaff = numberofStaff.Text,
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Department>(); //creates the table. if the table already exits it ignores.
                connection.Insert(department);
            }

            MessageBox.Show($"The Selected Department{department}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
