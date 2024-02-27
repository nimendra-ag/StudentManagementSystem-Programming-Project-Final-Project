using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Classes
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; } //here it is a misspelling Phote = Photo
        public DateTime BirthDay { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Department { get; set; }
        public string GPA { get; set; }
        

        public override string ToString()
        {
            return $"{StudentId} - {FirstName} - {LastName} - {Photo} - {BirthDay} - {Department} - {GPA} - {RegisteredDate}";
        }
    }
}
