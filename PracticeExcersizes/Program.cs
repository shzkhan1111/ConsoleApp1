using PracticeExcersizes;
using System.Collections.Generic;

List<Student> students = new List<Student>
                {
                    new Student { StudentId = 1, Name = "John" },
                    new Student { StudentId = 2, Name = "Jane" },
                    new Student { StudentId = 3, Name = "Joe" },
                    new Student { StudentId = 4, Name = "pope" }
                };

List<Course> courses = new List<Course>
                {
                    new Course { StudentId = 1, CourseName = "Math" },
                    new Course { StudentId = 1, CourseName = "Science" },
                    new Course { StudentId = 2, CourseName = "English" },
                    new Course { StudentId = 0, CourseName = "Spainish" }
                };

List<Employee> employees = new List<Employee>
{
    new Employee { Name = "John", Department = "HR", Salary = 60000 },
    new Employee { Name = "John", Department = "HR", Salary = 60000 },
    new Employee { Name = "Jane", Department = "IT", Salary = 80000 },
    new Employee { Name = "Jake", Department = "HR", Salary = 55000 },
    new Employee { Name = "Jill", Department = "IT", Salary = 90000 },
    new Employee { Name = "Tam", Department = "Finance", Salary = 75000 },
    new Employee { Name = "Jam", Department = "Finance", Salary = 85000 },
    new Employee { Name = "Ram", Department = "Finance", Salary = 85000 },
    new Employee { Name = "Ham", Department = "IT", Salary = 95000 },
    new Employee { Name = "Cam", Department = "HR", Salary = 1750000 }
};
HelperClass.PerformGroupBy(employees);
//HelperClass.stdcoursesNameJoin(students, courses);
//HelperClass.stdcoursesNameLeftJoin(students, courses);
//HelperClass.stdCourseNameCrossJoin(students, courses);
//HelperClass.stdCourseNameFullJoin(students, courses);