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
    /// Interaction logic for AddAcadStaffMemberWindow.xaml
    /// </summary>
    public partial class AddAcadStaffMemberWindow : Window
    {
        public AddAcadStaffMemberWindow()
        {
            InitializeComponent();
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            //save data to database


            AcadStaffMember acadStaffMember = new AcadStaffMember()
            {
                StaffFirstName = firstName.Text,
                StaffLastName = lastName.Text,
                Department = department.Text,
                JoinedDate = (DateTime)datePickerJoinedData.SelectedDate,
                PhoneNumber= phoneNumber.Text,
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<AcadStaffMember>(); //creates the table. if the table already exits it ignores.
                connection.Insert(acadStaffMember);
            }

            MessageBox.Show($"Academic Member added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
