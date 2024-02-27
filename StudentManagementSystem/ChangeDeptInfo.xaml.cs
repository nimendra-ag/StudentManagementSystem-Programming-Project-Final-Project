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
    /// Interaction logic for ChangeDeptInfo.xaml
    /// </summary>
    public partial class ChangeDeptInfo : Window
    {
        Department department;
        public ChangeDeptInfo(Department department)
        {
            InitializeComponent();
            this.department = department;
            deptName.Text = department.DepartmentName;
            deptHead.Text = department.DepartmentHead;
            deptPhone.Text = department.PhoneNumber;
            deptNumberofStaff.Text = department.NumberofStaff;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            department.DepartmentHead = deptHead.Text;
            department.DepartmentName = deptName.Text;
            department.PhoneNumber= deptPhone.Text;
            department.NumberofStaff = deptNumberofStaff.Text;


            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Department>(); //creates the table. if the table already exits it ignores.
                connection.Update(department);
                Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Department>(); //creates the table. if the table already exits it ignores.
                connection.Delete(department);
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
