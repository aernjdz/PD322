using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public int[] Grades { get; set; }

        public Student(string firstName, string lastName, string specialty, int[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
            Grades = grades;
        }
    }
}
