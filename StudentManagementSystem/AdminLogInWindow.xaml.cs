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
    /// Interaction logic for AdminLogInWindow.xaml
    /// </summary>
    public partial class AdminLogInWindow : Window
    {
        public AdminLogInWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<AdminUser>();
                var adminUser = conn.Table<AdminUser>()
                        .FirstOrDefault(u => u.AdminUserName == Admin_Name.Text && u.AdminPassword == Admin_Password.Password);

                if (adminUser != null)
                {
                    // Authentication successful, perform further actions
                    AdminDashboard adminDashboard = new AdminDashboard();
                    Close();
                    adminDashboard.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }

            }

        }
    }
}
