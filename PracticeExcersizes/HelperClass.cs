using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace PracticeExcersizes
{
    public class HelperClass
    {
        public static void stdcoursesNameJoin(List<Student> students, List<Course> courses)
        {
            var stdcourses = students.Join(courses, s => s.StudentId, c => c.StudentId,
            (s, c) => new StudentCoursesName { CourseName = c.CourseName, StudentName = s.Name }
            ).ToList();
            Console.WriteLine($"Join");
            foreach (var s in stdcourses)
            {
                Console.WriteLine($"{s.StudentName} studies {s.CourseName}");
            }
        }

        public static void stdCourseNameCrossJoin(List<Student> students, List<Course> courses)
        {
            var stdcourse = students.SelectMany(
                x => courses,
                (i1, i2) => new { CourseName = i2.CourseName, StudentName = i1.Name }
                );

            Console.WriteLine($"Join");
            foreach (var s in stdcourse)
            {
                Console.WriteLine($"{s.StudentName} studies {s.CourseName}");
            }
        }

        public static void stdcoursesNameLeftJoin(List<Student> students, List<Course> courses)
        {
            var stdcourses = students.GroupJoin(courses, s => s.StudentId, c => c.StudentId,
            (x, y) => new { Student = x, Course = y.DefaultIfEmpty() })
                .SelectMany(
                    sc => sc.Course,
                    (sc, c) => new
                    {
                        StudentName = sc.Student.Name,
                        CourseName = c?.CourseName
                    }
                )
                .ToList();
            Console.WriteLine($"Left Join");
            foreach (var s in stdcourses)
            {
                var studies = string.IsNullOrEmpty(s.CourseName) ? "nothing" : s.CourseName;
                Console.WriteLine($"{s.StudentName} studies {studies}");
            }

        }


        public static void stdCourseNameFullJoin(List<Student> students, List<Course> courses)
        {
            var left = students.GroupJoin(
                courses,
                s => s.StudentId,
                c => c.StudentId,
                (s, c) => new { Student = s, Courses = c.DefaultIfEmpty() }
            )
            .SelectMany(
                sc => sc.Courses,
                (sc, c) => new
                {
                    StudentName = sc.Student.Name,
                    CourseName = c?.CourseName // Use null-coalescing operator to handle null values
                }
            );

            var right = courses.GroupJoin(
                            students,
                            c => c.StudentId,
                            s => s.StudentId,
                            (c, s) => new { Course = c, Students = s.DefaultIfEmpty() }
                        )
                        .SelectMany(
                            cs => cs.Students,
                            (cs, s) => new
                            {
                                StudentName = s?.Name, // Use null-coalescing operator to handle null values
                                CourseName = cs.Course.CourseName
                            }
                        );

            var full = left.Union(right).ToList();

            foreach (var item in full)
            {
                Console.WriteLine($"{item.StudentName} studies {item.CourseName}");
            }
        }

        public static void PerformGroupBy(List<Employee> emp)
        {
            //var groupedEmp = emp.GroupBy(e => e.Department);
            //foreach (var e in groupedEmp)
            //{
            //    var firstAppearingName = e.FirstOrDefault()?.Name;
            //    var maxsalaryPerDep = e.Max(x => x.Salary);
            //    Console.WriteLine($"{e.Key} , {firstAppearingName}, {maxsalaryPerDep}");
            //}

            //new grpup will only have names
            //var groupedEmpCust = emp.GroupBy(e => e.Department, e => e.Name);
            //foreach (var e in groupedEmpCust)
            //{
            //    Console.WriteLine($"Names of People in Department {e.Key}");


            //    foreach (var t in e)
            //    {
            //        Console.WriteLine($"Employee Name {t}");
            //    }
            //}

            // group aggregation 

            //var groupedEmpAggre = emp.GroupBy(e => e.Department)
            //    .Select(g => new
            //    {
            //        Department = g.Key,
            //        AvgSal = g.Average(x => x.Salary)
            //    });
            //foreach (var e in groupedEmpAggre)
            //{

            //    Console.WriteLine($"{e.Department} , {e.AvgSal}");
            //}

            //multiple Grouping 
            //var grpByDepAndSal = emp.GroupBy(
            //    e => new { e.Department , salaryRange = e.Salary > 90000 ? "High" : "Low"}
            //    );

            //foreach (var e in grpByDepAndSal)
            //{

            //    Console.WriteLine($"Depart with {e.Key.salaryRange} sal {e.Key.Department} ");
            //    foreach (var t in e)
            //    {
            //        Console.WriteLine($"Name is {t.Name} and Salary is {t.Salary} department = {t.Department}");
            //    }
            //}
            Console.WriteLine("Nested Group by");

            var nestedGroupBy = emp
                .GroupBy(e => e.Department)
                .Select(x => new
                {
                    Department = x.Key,
                    EmpAvgSal = x.GroupBy(x => x.Salary > 6000 ? "High" : "Low")
                }) ;

            foreach (var e in nestedGroupBy)
            {
                Console.WriteLine($"{e.Department}");
                Console.WriteLine("Read This");
                foreach (var x1 in e.EmpAvgSal)
                {
                    var allNames = string.Join(", ", x1.Select(y => y.Name).ToList());
                    Console.WriteLine($"{x1.Key} Salary: {allNames}");
                }
            }
        }

        
    }


}
