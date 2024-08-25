using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeExcersizes
{
    internal class Models
    {

    }
    #region classes
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
    }
    public class StudentCoursesName
    {
        public string? StudentName { get; set; } = "";
        public string? CourseName { get; set; } = "";
    }

    public class Course
    {
        public int StudentId { get; set; }
        public string? CourseName { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
    #endregion
}
