using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Classes
{
    public class AdminUser
    {
        [PrimaryKey, AutoIncrement]
        public int AdminId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }


        public override string ToString()
        {
            return $"{AdminId} - {AdminUserName} - {AdminPassword}";
        }
    }
}
