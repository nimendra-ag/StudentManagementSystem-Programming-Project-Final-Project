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
    /// Interaction logic for ChangeStaffInfoWindow.xaml
    /// </summary>
    public partial class ChangeStaffInfoWindow : Window
    {
        AcadStaffMember acadStaffMember;
        public ChangeStaffInfoWindow(AcadStaffMember acadStaffMember)
        {
            InitializeComponent();
            this.acadStaffMember = acadStaffMember;
            firstName.Text = acadStaffMember.StaffFirstName;
            lastName.Text = acadStaffMember.StaffLastName;
            phoneNumber.Text = acadStaffMember.PhoneNumber;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            acadStaffMember.StaffFirstName = firstName.Text;
            acadStaffMember.StaffLastName = lastName.Text;
            acadStaffMember.PhoneNumber = phoneNumber.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<AcadStaffMember>(); //creates the table. if the table already exits it ignores.
                connection.Update(acadStaffMember);
                Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<AcadStaffMember>(); //creates the table. if the table already exits it ignores.
                connection.Delete(acadStaffMember);
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
