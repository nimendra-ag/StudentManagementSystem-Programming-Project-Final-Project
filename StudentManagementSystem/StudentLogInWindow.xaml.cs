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
    /// Interaction logic for StudentLogInWindow.xaml
    /// </summary>
    public partial class StudentLogInWindow : Window
    {
        public StudentLogInWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {

                conn.CreateTable<StudentUser>();
                var studentUser = conn.Table<StudentUser>()
                        .FirstOrDefault(u => u.StudentUserName == Student_Name.Text && u.StudentPassword == Student_Password.Password);

                if (studentUser != null)
                {
                    // Authentication successful, perform further actions
                    StudentDashboard studentDashboard = new StudentDashboard(studentUser);
                    Close();
                    studentDashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }

        }
    }
}
