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
    /// Interaction logic for DisplayDepartmentInfoWindow.xaml
    /// </summary>
    public partial class DisplayDepartmentInfoWindow : Window
    {
        List<Department> departments;
        public DisplayDepartmentInfoWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            AddDepartmentWindow addDepartmentWindow = new AddDepartmentWindow();
            addDepartmentWindow.ShowDialog();
            ReadDatabase();

        }

        void ReadDatabase()
        {


            using (SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Department>();
                departments = conn.Table<Department>().ToList();
            }

            if (departments != null)
            {
                departmentDataGrid.ItemsSource = departments;

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = departments.Where(s => s.DepartmentName.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            departmentDataGrid.ItemsSource = filteredList;
        }

        private void departmentDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

                if (row != null)
                {
                    // Get the data object bound to the clicked row
                    Department rowData = (Department)row.Item;

                    // Display a message box with information about the clicked row
                    MessageBox.Show($"Clicked on row with data: ", "Row Clicked", MessageBoxButton.OK, MessageBoxImage.Information);

                    ChangeDeptInfo changeDeptInfo = new ChangeDeptInfo(rowData);
                    changeDeptInfo.ShowDialog();

                    ReadDatabase();
                }
            }
        }
    }
}
