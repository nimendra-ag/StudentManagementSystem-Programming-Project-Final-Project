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
    /// Interaction logic for DisplayAcadStaffWindow.xaml
    /// </summary>
    public partial class DisplayAcadStaffWindow : Window
    {
        List<AcadStaffMember> acadStaffMembers;
        public DisplayAcadStaffWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        void ReadDatabase()
        {

            using (SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<AcadStaffMember>();
                acadStaffMembers = conn.Table<AcadStaffMember>().ToList();
            }

            if (acadStaffMembers != null)
            {
                academicStaff.ItemsSource = acadStaffMembers;

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = acadStaffMembers.Where(s => s.StaffFirstName.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            academicStaff.ItemsSource = filteredList;
        }

        private void academicStaff_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

                if (row != null)
                {
                    // Get the data object bound to the clicked row
                    AcadStaffMember rowData = (AcadStaffMember)row.Item;

                    // Display a message box with information about the clicked row
                    MessageBox.Show($"Clicked on row with data: ", "Row Clicked", MessageBoxButton.OK, MessageBoxImage.Information);

                    ChangeStaffInfoWindow changeStaffInfoWindow = new ChangeStaffInfoWindow(rowData);
                    changeStaffInfoWindow.ShowDialog();

                    ReadDatabase();
                }
            }
        }

        private void addNewStaffButton_Click(object sender, RoutedEventArgs e)
        {
            AddAcadStaffMemberWindow addAcadStaffMemberWindow = new AddAcadStaffMemberWindow();
            addAcadStaffMemberWindow.ShowDialog();
            ReadDatabase();
        }
    }
}
