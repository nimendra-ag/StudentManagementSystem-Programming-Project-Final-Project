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
    /// Interaction logic for StudentInformationWindow.xaml
    /// </summary>
    public partial class StudentInformationWindow : Window
    {
        List<StudentUser> studentUsers;
        public StudentInformationWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow studentWindow = new AddStudentWindow();
            studentWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            

            using (SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<StudentUser>();
                studentUsers = conn.Table<StudentUser>().ToList();
            }

            if (studentUsers != null)
            {
                studentDataGrid.ItemsSource = studentUsers;

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = studentUsers.Where(s => s.FirstName.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            studentDataGrid.ItemsSource = filteredList;
        }


        private void membersDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

                if (row != null)
                {
                    // Get the data object bound to the clicked row
                    StudentUser rowData = (StudentUser)row.Item;

                    // Display a message box with information about the clicked row
                    ///MessageBox.Show($"Clicked on row with data: {rowData.ToString()}", "Row Clicked", MessageBoxButton.OK, MessageBoxImage.Information);

                    ChangeStudentInfo changeStudentInfo = new ChangeStudentInfo(rowData);
                    changeStudentInfo.ShowDialog();

                    ReadDatabase();
                }
            }
        }
    }
}
