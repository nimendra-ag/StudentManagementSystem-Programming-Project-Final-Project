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
    /// Interaction logic for AddAdminUser.xaml
    /// </summary>
    public partial class AddAdminUser : Window
    {
        public AddAdminUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminUser adminUser = new AdminUser()
            {
                AdminUserName = nameTextBox.Text,
                AdminPassword = passwordTextBox.Text,
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<AdminUser>(); //creates the table. if the table already exits it ignores.
                connection.Insert(adminUser);
                MessageBox.Show("A new admin added to the system successfully");

            }




            Close();
        }
    }
}
