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

//HelperClass.stdcoursesNameJoin(students, courses);
//HelperClass.stdcoursesNameLeftJoin(students, courses);
//HelperClass.stdCourseNameCrossJoin(students, courses);
HelperClass.stdCourseNameFullJoin(students, courses);