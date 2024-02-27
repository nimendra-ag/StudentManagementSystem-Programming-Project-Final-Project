using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Classes
{
    public class AcadStaffMember
    {
        [PrimaryKey, AutoIncrement]
        public int StaffID { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffLastName { get; set; }
        public string Department { get; set; }
        public DateTime JoinedDate{ get; set; }
        public string PhoneNumber { get; set; }
    }
}
