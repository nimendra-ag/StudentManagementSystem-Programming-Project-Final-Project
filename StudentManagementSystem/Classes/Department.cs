using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Classes
{
    public class Department
    {
        [PrimaryKey, AutoIncrement]
        public int DeptID { get; set; }
        public string DepartmentName{ get; set; }
        public string DepartmentHead{ get; set; }
        public DateTime EstablisgedOn { get; set; }
        public string NumberofStaff {  get; set; }
        public string PhoneNumber { get; set; }

    }
}
